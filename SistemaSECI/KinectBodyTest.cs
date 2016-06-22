using System;
using System.Collections.Generic;
using Microsoft.Kinect;
using System.Windows.Media;
using System.Windows;

namespace SistemaSECI
{
    class KinectBodyTest
    {

        private const double HandSize = 40;                 /// Radio de los circulos dibujados para las manos
        private const double JointThickness = 4;            /// Grosor de los vertices
        private const double ClipBoundsThickness = 10;      /// Grosor del marco dibujado en el limite de reconocimiento de cuerpos

        private readonly Brush handClosedBrush = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));       /// Peine para dibujar las manos (cerradas)
        private readonly Brush handOpenBrush = new SolidColorBrush(Color.FromArgb(128, 0, 255, 0));         /// Pincel para dibujar las manos (abiertas)
        private readonly Brush handLassoBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));        /// Pincel para dibujar las manos (Lasso, apuntando)
        private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));   /// Pincel para dibujar las intersecciones (vertices)
        private readonly Brush inferredJointBrush = Brushes.Yellow;                                         /// Pincel para dibujar las intersecciones (inferidos)
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);                                    /// Pluma para dibujar los huesos (inferidos)

        private KinectSensor kinectSensor = null;           /// SensorKinect actual
        public KinectSensor KSensor
        {
            get { return this.kinectSensor; }
            set { this.kinectSensor = value; }
        }

        private CoordinateMapper coordinateMapper = null;   /// CoordinateMapper para mapear un punto en otro plano
        public CoordinateMapper CMapper
        {
            get { return this.coordinateMapper; }
            set { this.coordinateMapper = value; }
        }

        private BodyFrameReader bodyFrameReader = null;     /// Lector de los marcos del cuerpo
        public BodyFrameReader BFReader
        {
            get { return this.bodyFrameReader; }
            set { this.bodyFrameReader = value; }
        }
        private Body[] bodies = null;                       /// Arreglo para distintos cuerpos
        public Body[] Bodies
        {
            get { return this.bodies; }
            set { this.bodies = value; }
        }

        private List<Tuple<JointType, JointType>> bones;    /// Lista definida por "enum" para los huesos
        public List<Tuple<JointType, JointType>> Bones
        {
            get { return this.bones; }
            set { this.bones = value; }
        }
        private List<Pen> bodyColors;                       /// Lista de colores para cada cuerpo reconocido
        public List<Pen> BColors
        {
            get { return this.bodyColors; }
            set { this.bodyColors = value; }
        }

        private int displayWidth;                           /// Ancho del display (depth space)
        public int DWidth
        {
            get { return this.displayWidth; }
            set { this.displayWidth = value; }
        }
        private int displayHeight;                          /// Alto del display (depth space)
        public int DHeight
        {
            get { return this.displayHeight; }
            set { this.displayHeight = value; }
        }

        public KinectBodyTest()
        {
        }

        /// Dibuja un cuerpo
        /// <param name="joints">vertices a dibujar</param>
        /// <param name="jointPoints">conversion de la posicion de los vertices a dibujar</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        /// <param name="drawingPen">especifica el color para dibujar un cuerpo en especifico</param>
        public void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, 
                                                                            DrawingContext drawingContext, Pen drawingPen)
        {
            foreach (var bone in Bones)                        // Dibuja los huesos
                this.DrawBone(joints, jointPoints, bone.Item1, bone.Item2, drawingContext, drawingPen);
            foreach (JointType jointType in joints.Keys)            // Dibuja los vertices
            {
                Brush drawBrush = null;
                TrackingState trackingState = joints[jointType].TrackingState;
                if (trackingState == TrackingState.Tracked)
                    drawBrush = this.trackedJointBrush;
                else if (trackingState == TrackingState.Inferred)
                    drawBrush = this.inferredJointBrush;
                if (drawBrush != null)
                    drawingContext.DrawEllipse(drawBrush, null, jointPoints[jointType], JointThickness, JointThickness);
            }
        }

        /// Dibuja un hueso en un cuerpo (vertice a vertice)
        /// <param name="joints">vertices a dibujar</param>
        /// <param name="jointPoints">conversion de la posicion de los vertices a dibujar</param>
        /// <param name="jointType0">primer vertice del hueso a dibujar</param>
        /// <param name="jointType1">segundo vertice del hueso a dibujar</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        /// /// <param name="drawingPen">especifica el color de un hueso especifico a dibujar</param>
        public void DrawBone(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints,
                                    JointType jointType0, JointType jointType1, DrawingContext drawingContext, Pen drawingPen)
        {
            Joint joint0 = joints[jointType0];
            Joint joint1 = joints[jointType1];
            // Si no podemos encontrar alguno de los vertices, exit
            if (joint0.TrackingState == TrackingState.NotTracked || joint1.TrackingState == TrackingState.NotTracked)
                return;
            // Asumimos que todos los huesos dibujados son inferidos a menos que ambos sean leidos (tracked)
            Pen drawPen = this.inferredBonePen;
            if ((joint0.TrackingState == TrackingState.Tracked) && (joint1.TrackingState == TrackingState.Tracked))
                drawPen = drawingPen;
            drawingContext.DrawLine(drawPen, jointPoints[jointType0], jointPoints[jointType1]);
        }

        /// Dibuja el simbolo de la mano si es leida (tracked): circulo rojo = closed, circulo verde = opened; circulo azul = lasso
        /// <param name="handState">estado de la mano</param>
        /// <param name="handPosition">posicion de la mano</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        public void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
        {
            switch (handState)
            {
                case HandState.Closed:
                    drawingContext.DrawEllipse(this.handClosedBrush, null, handPosition, HandSize, HandSize);
                    break;
                case HandState.Open:
                    drawingContext.DrawEllipse(this.handOpenBrush, null, handPosition, HandSize, HandSize);
                    break;
                case HandState.Lasso:
                    drawingContext.DrawEllipse(this.handLassoBrush, null, handPosition, HandSize, HandSize);
                    break;
            }
        }

        /// Dibuja los indicadores para mostrar que edges se acercan al limite de los datos de cuerpo
        /// <param name="body">body para dibujar la informacion de los limites</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        public void DrawClippedEdges(Body body, DrawingContext drawingContext)
        {
            FrameEdges clippedEdges = body.ClippedEdges;

            if (clippedEdges.HasFlag(FrameEdges.Bottom))
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, DHeight - ClipBoundsThickness, DWidth, ClipBoundsThickness));
            if (clippedEdges.HasFlag(FrameEdges.Top))
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, 0, DWidth, ClipBoundsThickness));
            if (clippedEdges.HasFlag(FrameEdges.Left))
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, 0, ClipBoundsThickness, DHeight));
            if (clippedEdges.HasFlag(FrameEdges.Right))
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(DWidth - ClipBoundsThickness, 0, ClipBoundsThickness, DHeight));
        }

        public void IniciaComunicacionKinect()
        {
            KSensor = KinectSensor.GetDefault();                                              // detecta un sensor
            CMapper = KSensor.CoordinateMapper;                                 // detecta su coordinate mapper
            FrameDescription frameDescription = KSensor.DepthFrameSource.FrameDescription;    // get depth (display) extents

            DWidth = frameDescription.Width;                                                 // get tamaño de marco deteccion
            DHeight = frameDescription.Height;
            BFReader = KSensor.BodyFrameSource.OpenReader();                      // open lector de marcos/cuerpo
        }

        public void IniciaFiguraHumana()
        {
            Bones = new List<Tuple<JointType, JointType>>();            // definicion de huesos como lineas entre dos vertices
            // Torso
            Bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
            Bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));
            // Brazo Derecho
            Bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderRight, JointType.ElbowRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.ElbowRight, JointType.WristRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.HandRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.HandRight, JointType.HandTipRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.ThumbRight));
            // Brazo Izquierdo
            Bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderLeft, JointType.ElbowLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.ElbowLeft, JointType.WristLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.HandLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.HandLeft, JointType.HandTipLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.ThumbLeft));
            // Pierna Derecha
            Bones.Add(new Tuple<JointType, JointType>(JointType.HipRight, JointType.KneeRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.KneeRight, JointType.AnkleRight));
            Bones.Add(new Tuple<JointType, JointType>(JointType.AnkleRight, JointType.FootRight));
            // Pierna Izquierda
            Bones.Add(new Tuple<JointType, JointType>(JointType.HipLeft, JointType.KneeLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.KneeLeft, JointType.AnkleLeft));
            Bones.Add(new Tuple<JointType, JointType>(JointType.AnkleLeft, JointType.FootLeft));

            BColors = new List<Pen>();            // almacena un color por cada BodyIndex

            BColors.Add(new Pen(Brushes.Red, 6));
            BColors.Add(new Pen(Brushes.Orange, 6));
            BColors.Add(new Pen(Brushes.Green, 6));
            BColors.Add(new Pen(Brushes.Blue, 6));
            BColors.Add(new Pen(Brushes.Indigo, 6));
            BColors.Add(new Pen(Brushes.Violet, 6));
        }
    }
}
