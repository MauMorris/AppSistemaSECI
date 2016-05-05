//------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="UNAM">
//     Copyright (c) Posgrado en psicologia.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
namespace SistemaSECI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.ComponentModel;
    using System.IO;
    using Microsoft.Kinect;
    
    /// Interaction logic for VentanaBodyBasics.xaml
    public partial class VentanaBodyBasics : Window, INotifyPropertyChanged
    {
        private const double HandSize = 40;                 /// Radio de los circulos dibujados para las manos
        private const double JointThickness = 4;            /// Grosor de los vertices
        private const double ClipBoundsThickness = 10;      /// Grosor del marco dibujado en el limite de reconocimiento de cuerpos

        private const float InferredZPositionClamp = 0.1f;                                                  /// Constante para los vertices inferidos en el eje -Z
        private readonly Brush handClosedBrush = new SolidColorBrush(Color.FromArgb(128, 255, 0, 0));       /// Peine para dibujar las manos (cerradas)
        private readonly Brush handOpenBrush = new SolidColorBrush(Color.FromArgb(128, 0, 255, 0));         /// Pincel para dibujar las manos (abiertas)
        private readonly Brush handLassoBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 255));        /// Pincel para dibujar las manos (Lasso, apuntando)
        private readonly Brush trackedJointBrush = new SolidColorBrush(Color.FromArgb(255, 68, 192, 68));   /// Pincel para dibujar las intersecciones (vertices)
        private readonly Brush inferredJointBrush = Brushes.Yellow;                                         /// Pincel para dibujar las intersecciones (inferidos)
        private readonly Pen inferredBonePen = new Pen(Brushes.Gray, 1);                                    /// Pluma para dibujar los huesos (inferidos)

        private DrawingGroup drawingGroup;                  /// DrawingGroup para la salida del render para el cuerpo
        private DrawingImage imageSource;                   /// DrawingImage para mostrar

        public ImageSource ImageSource                      /// Gets bitmap a mostrar
        {
            get
            {
                return this.imageSource;
            }
        }

        private KinectSensor kinectSensor = null;           /// SensorKinect actual
        private CoordinateMapper coordinateMapper = null;   /// CoordinateMapper para mapear un punto en otro plano
        private BodyFrameReader bodyFrameReader = null;     /// Lector de los marcos del cuerpo
        private Body[] bodies = null;                       /// Arreglo para distintos cuerpos

        private List<Tuple<JointType, JointType>> bones;    /// Lista definida por "enum" para los huesos
        private List<Pen> bodyColors;                       /// Lista de colores para cada cuerpo reconocido

        private int displayWidth;                           /// Ancho del display (depth space)
        private int displayHeight;                          /// Alto del display (depth space)

        private string statusText = String.Empty;           /// Estatus actual del texto a mostrar en la pantalla

        public string StatusText                            /// Gets / Sets el estado actual en un texto en pantalla
        {
            get
            {
                return this.statusText;
            }
            set
            {
                if (this.statusText != value)
                {
                    this.statusText = value;
                    // notificacion debida al cambio de texto de status 
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
                }
            }
        }

        private string nivelText = String.Empty;           /// Estatus actual del nivel jugado

        public string NivelText                            /// Gets / Sets del nivel actual de juego en pantalla
        {
            get
            {
                return this.nivelText;
            }
            set
            {
                if (this.nivelText != value)
                {
                    this.nivelText = value;
                    // notificacion debida al cambio de texto de status 
                    if (this.PropertyChanged != null)
                        this.PropertyChanged(this, new PropertyChangedEventArgs("NivelText"));
                }
            }
        }

        /// Inicializa una nueva instancia de MainWindow class
        public VentanaBodyBasics(int nivel)
        {
            inicializaComunicacionKinect();
            inicializaFiguraHumana();

            this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;             // set IsAvailableChanged event notifier
            this.kinectSensor.Open();                                                           // open sensor
            this.NivelText = "NIVEL " + nivel;                                                  // muestra en pantalla que nivel estas
                                                                                                // set the status text
            this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                                : Properties.Resources.NoSensorStatusText;
            this.drawingGroup = new DrawingGroup();                                             // Crea drawing group para dibujar
            this.imageSource = new DrawingImage(this.drawingGroup);                             // Crea una image source para el image control
            this.DataContext = this;                                                            // usa window object como view model
            this.InitializeComponent();                                                         // inicializa (controls) de la ventana
        }

        /// INotifyPropertyChangedPropertyChanged evento para el control de ventana bind to changeable data
        public event PropertyChangedEventHandler PropertyChanged;

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.bodyFrameReader != null)
            {
                this.bodyFrameReader.FrameArrived += this.Reader_FrameArrived;
            }
        }

        /// Ejecuta tareas terminales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (this.bodyFrameReader != null)
            {
                this.bodyFrameReader.Dispose();   // BodyFrameReader is IDisposable
                this.bodyFrameReader = null;
            }
        }

        /// Handler para los datos recibidos de body frame enviados por kinect
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool dataReceived = false;
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    if (this.bodies == null)
                    {
                        this.bodies = new Body[bodyFrame.BodyCount];
                    }
                    // The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                    // As long as those body objects are not disposed and not set to null in the array,
                    // those body objects will be re-used.
                    bodyFrame.GetAndRefreshBodyData(this.bodies);
                    dataReceived = true;
                }
            }
            if (dataReceived)
            {
                using (DrawingContext dc = this.drawingGroup.Open())
                {
                    // Dibuja un background transparente para inicializar el tamaño del render
                    dc.DrawRectangle(Brushes.Black, null, new Rect(0.0, 0.0, this.displayWidth, this.displayHeight));
                    int penIndex = 0;
                    foreach (Body body in this.bodies)
                    {
                        Pen drawPen = this.bodyColors[penIndex++];
                        if (body.IsTracked)
                        {
                            this.DrawClippedEdges(body, dc);
                            IReadOnlyDictionary<JointType, Joint> joints = body.Joints;

                            // convierte las intersecciones en una profundidad de espacio a dibujar
                            Dictionary<JointType, Point> jointPoints = new Dictionary<JointType, Point>();

                            foreach (JointType jointType in joints.Keys)
                            {
                                // a veces -Z de un vertice inferido puede mostrarse como negativa
                                // clamp down to 0.1f previene que el coordinatemapper regrese valores (-Infinity, -Infinity)
                                CameraSpacePoint position = joints[jointType].Position;
                                if (position.Z < 0)
                                {
                                    position.Z = InferredZPositionClamp;
                                }
                                DepthSpacePoint depthSpacePoint = this.coordinateMapper.MapCameraPointToDepthSpace(position);
                                jointPoints[jointType] = new Point(depthSpacePoint.X, depthSpacePoint.Y);
                            }
                            this.DrawBody(joints, jointPoints, dc, drawPen);
                            this.DrawHand(body.HandLeftState, jointPoints[JointType.HandLeft], dc);
                            this.DrawHand(body.HandRightState, jointPoints[JointType.HandRight], dc);
                        }
                    }
                    // evita que dibujemos fuera del area de render
                    this.drawingGroup.ClipGeometry = new RectangleGeometry(new Rect(0.0, 0.0, this.displayWidth, this.displayHeight));
                }
            }
        }

        /// Dibuja un cuerpo
        /// <param name="joints">vertices a dibujar</param>
        /// <param name="jointPoints">conversion de la posicion de los vertices a dibujar</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        /// <param name="drawingPen">especifica el color para dibujar un cuerpo en especifico</param>
        private void DrawBody(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, DrawingContext drawingContext, Pen drawingPen)
        {
            foreach (var bone in this.bones)            // Dibuja los huesos
            {
                this.DrawBone(joints, jointPoints, bone.Item1, bone.Item2, drawingContext, drawingPen);
            }
            foreach (JointType jointType in joints.Keys)            // Dibuja los vertices
            {
                Brush drawBrush = null;
                TrackingState trackingState = joints[jointType].TrackingState;
                if (trackingState == TrackingState.Tracked)
                {
                    drawBrush = this.trackedJointBrush;
                }
                else if (trackingState == TrackingState.Inferred)
                {
                    drawBrush = this.inferredJointBrush;
                }
                if (drawBrush != null)
                {
                    drawingContext.DrawEllipse(drawBrush, null, jointPoints[jointType], JointThickness, JointThickness);
                }
            }
        }

        /// Dibuja un hueso en un cuerpo (vertice a vertice)
        /// <param name="joints">vertices a dibujar</param>
        /// <param name="jointPoints">conversion de la posicion de los vertices a dibujar</param>
        /// <param name="jointType0">primer vertice del hueso a dibujar</param>
        /// <param name="jointType1">segundo vertice del hueso a dibujar</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        /// /// <param name="drawingPen">especifica el color de un hueso especifico a dibujar</param>
        private void DrawBone(IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, 
                                    JointType jointType0, JointType jointType1, DrawingContext drawingContext, Pen drawingPen)
        {
            Joint joint0 = joints[jointType0];
            Joint joint1 = joints[jointType1];
            // Si no podemos encontrar alguno de los vertices, exit
            if (joint0.TrackingState == TrackingState.NotTracked || joint1.TrackingState == TrackingState.NotTracked)
            {
                return;
            }
            // Asumimos que todos los huesos dibujados son inferidos a menos que ambos sean leidos (tracked)
            Pen drawPen = this.inferredBonePen;
            if ((joint0.TrackingState == TrackingState.Tracked) && (joint1.TrackingState == TrackingState.Tracked))
            {
                drawPen = drawingPen;
            }
            drawingContext.DrawLine(drawPen, jointPoints[jointType0], jointPoints[jointType1]);
        }

        /// Dibuja el simbolo de la mano si es leida (tracked): circulo rojo = closed, circulo verde = opened; circulo azul = lasso
        /// <param name="handState">estado de la mano</param>
        /// <param name="handPosition">posicion de la mano</param>
        /// <param name="drawingContext">drawing context para dibujar</param>
        private void DrawHand(HandState handState, Point handPosition, DrawingContext drawingContext)
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
        private void DrawClippedEdges(Body body, DrawingContext drawingContext)
        {
            FrameEdges clippedEdges = body.ClippedEdges;

            if (clippedEdges.HasFlag(FrameEdges.Bottom))
            {
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, this.displayHeight - ClipBoundsThickness, this.displayWidth, ClipBoundsThickness));
            }
            if (clippedEdges.HasFlag(FrameEdges.Top))
            {
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, 0, this.displayWidth, ClipBoundsThickness));
            }
            if (clippedEdges.HasFlag(FrameEdges.Left))
            {
                drawingContext.DrawRectangle(Brushes.Red, null, new Rect(0, 0, ClipBoundsThickness, this.displayHeight));
            }
            if (clippedEdges.HasFlag(FrameEdges.Right))
            {
                drawingContext.DrawRectangle( Brushes.Red, null, new Rect(this.displayWidth - ClipBoundsThickness, 0, ClipBoundsThickness, this.displayHeight));
            }
        }

        /// Handles el evento en el que el sensor no esta disponible (E.g. paused, closed, unplugged).
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        { // en caso de falla, set the status text
            this.StatusText = this.kinectSensor.IsAvailable ? Properties.Resources.RunningStatusText
                                                            : Properties.Resources.SensorNotAvailableStatusText;
        }

        private void botonSalir_VN_click(object sender, RoutedEventArgs e)
        {
            if (this.bodyFrameReader != null)
            {
                this.bodyFrameReader.Dispose();                // BodyFrameReader is IDisposable
                this.bodyFrameReader = null;
            }
            /*////////  if (this.kinectSensor != null) {   this.kinectSensor.Close(); this.kinectSensor = null;  } //////////////// */
            VentanaEjemplosKinect v = new VentanaEjemplosKinect();
            v.Show();
            this.Close();
        }

        private void inicializaComunicacionKinect()
        {
            this.kinectSensor = KinectSensor.GetDefault();                                              // detecta un sensor maximo
            this.coordinateMapper = this.kinectSensor.CoordinateMapper;                                 // detecta coordinate mapper
            FrameDescription frameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;    // get depth (display) extents

            this.displayWidth = frameDescription.Width;                                                 // get tamaño del marco
            this.displayHeight = frameDescription.Height;
            this.bodyFrameReader = this.kinectSensor.BodyFrameSource.OpenReader();                      // open lector de marcos/cuerpo
        }

        private void inicializaFiguraHumana()
        {
            this.bones = new List<Tuple<JointType, JointType>>();            // definicion de huesos como lineas entre dos vertices
            // Torso
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Head, JointType.Neck));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.Neck, JointType.SpineShoulder));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.SpineMid));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineMid, JointType.SpineBase));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineShoulder, JointType.ShoulderLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.SpineBase, JointType.HipLeft));
            // Brazo Derecho
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderRight, JointType.ElbowRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowRight, JointType.WristRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.HandRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandRight, JointType.HandTipRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristRight, JointType.ThumbRight));
            // Brazo Izquierdo
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ShoulderLeft, JointType.ElbowLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.ElbowLeft, JointType.WristLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.HandLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HandLeft, JointType.HandTipLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.WristLeft, JointType.ThumbLeft));
            // Pierna Derecha
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipRight, JointType.KneeRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeRight, JointType.AnkleRight));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleRight, JointType.FootRight));
            // Pierna Izquierda
            this.bones.Add(new Tuple<JointType, JointType>(JointType.HipLeft, JointType.KneeLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.KneeLeft, JointType.AnkleLeft));
            this.bones.Add(new Tuple<JointType, JointType>(JointType.AnkleLeft, JointType.FootLeft));

            this.bodyColors = new List<Pen>();            // almacena un color por cada BodyIndex

            this.bodyColors.Add(new Pen(Brushes.Red, 6));
            this.bodyColors.Add(new Pen(Brushes.Orange, 6));
            this.bodyColors.Add(new Pen(Brushes.Green, 6));
            this.bodyColors.Add(new Pen(Brushes.Blue, 6));
            this.bodyColors.Add(new Pen(Brushes.Indigo, 6));
            this.bodyColors.Add(new Pen(Brushes.Violet, 6));
        }
    }
}
