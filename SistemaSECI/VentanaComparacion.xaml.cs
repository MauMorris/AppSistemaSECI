using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media.Imaging;
using Excel = Microsoft.Office.Interop.Excel;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para VentanaComparacion.xaml
    /// </summary>
    public partial class VentanaComparacion : Window
    {
        string apoyoCerrar = "CerrarVentana";

        List<string> seleccion = new List<string>();
        List<string> seleccionAlmacenar;

        List<Pares> parejas = new List <Pares>();
        int idParametros = 0;
        int idLlaves = 0;
        string apoyo = string.Empty;
        int inicio = 0;

        TablasDBHelper nuevoUsuario;

        DateTime t0 = DateTime.Now;
        DateTime t1 = DateTime.Now;

        TimeSpan t2;
        string tiempo = string.Empty;

        string imagen0 = string.Empty;
        string imagen1 = string.Empty;

        public VentanaComparacion(int idParametrosSeci, int idLlavesUI, List<string> seleccionAnterior)
        {
            nuevoUsuario = new TablasDBHelper();

            idParametros = idParametrosSeci;
            idLlaves = idLlavesUI;

            seleccion = seleccionAnterior;
            seleccionAlmacenar = new List<string>(seleccionAnterior);

            inicio = nuevoUsuario.ConsultaIdUltimoMuestreo();

            int tamaño = seleccion.Count();

            for (int i = 0; i < tamaño; i++)
            {
                apoyo = seleccion.ElementAt(0);
                foreach (string x in seleccion)
                {
                    if (apoyo != x)
                        parejas.Add(new Pares(apoyo, x));
                }
                seleccion.Remove(apoyo);
            }

            InitializeComponent();

            image1_VComparacion.BeginInit();
            image1_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par0, UriKind.RelativeOrAbsolute));
            image1_VComparacion.EndInit();

            image2_VComparacion.BeginInit();
            image2_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par1, UriKind.RelativeOrAbsolute));
            image2_VComparacion.EndInit();

            imagen0 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par0);
            imagen1 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par1);

            t2 = t1.Subtract(t0);
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            switch (apoyoCerrar)
            {
                case "Cerrar":
                    e.Cancel = false;
                    break;
                case "Regresar":
                    e.Cancel = false;
                    break;
                case "CerrarVentana":
                    VentanaHome v = new VentanaHome(idLlaves);
                    v.Show();
                    e.Cancel = false;
                    break;
                default:
                    VentanaHome f = new VentanaHome(idLlaves);
                    f.Show();
                    e.Cancel = false;
                    break;
            }
        }

        private void b1_comida(object sender, RoutedEventArgs e)
        {
            t1 = DateTime.Now;
            t2 = t1.Subtract(t0);
            t0 = DateTime.Now;

            tiempo = String.Format("{0:#}", t2.TotalSeconds);

            nuevoUsuario.InsertarSesionMuestreo(imagen0, imagen1, imagen0, tiempo);

            parejas.RemoveAt(0);

            if (parejas.Count() == 0)
            {
                List<DatosMuestreo> aExcel = new List<DatosMuestreo>(nuevoUsuario.RegresaDatosSesionMuestreo(inicio));

                int tamaño = seleccionAlmacenar.Count();
                int[] conteo = new int[tamaño];
                string[] nomImagen = new string[tamaño];

                for (int i = 0; i < tamaño; i++)
                {
                    apoyo = seleccionAlmacenar.ElementAt(0);
                    nomImagen[i] = nuevoUsuario.RegresaNombreImagen(apoyo);
                    conteo[i] = nuevoUsuario.ContarUriSesionMuestreo(inicio, nomImagen[i]);
                    seleccionAlmacenar.Remove(apoyo);
                }

                if (CreaExcel(aExcel, conteo, nomImagen))
                {
                    var salida = MessageBox.Show("Has almacenado la información correctamente", "Terminar sesión",
                                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    if (salida.Equals(MessageBoxResult.OK))
                    {
                        apoyoCerrar = "Cerrar";
                        VentanaHome v = new VentanaHome(idLlaves);
                        v.Show();
                        this.Close();
                    }
                }

            }
            else
            {
                image1_VComparacion.BeginInit();
                image1_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par0, UriKind.RelativeOrAbsolute));
                image1_VComparacion.EndInit();

                image2_VComparacion.BeginInit();
                image2_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par1, UriKind.RelativeOrAbsolute));
                image2_VComparacion.EndInit();

                imagen0 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par0);
                imagen1 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par1);
            }
        }

        private void b2_comida(object sender, RoutedEventArgs e)
        {
            t1 = DateTime.Now;
            t2 = t1.Subtract(t0);
            t0 = DateTime.Now;
            tiempo = String.Format("{0:#}", t2.TotalSeconds);

            nuevoUsuario.InsertarSesionMuestreo(imagen0, imagen1, imagen1, tiempo);

            parejas.RemoveAt(0);

            if (parejas.Count() == 0)
            {
                List<DatosMuestreo> aExcel = new List<DatosMuestreo>(nuevoUsuario.RegresaDatosSesionMuestreo(inicio));

                int tamaño = seleccionAlmacenar.Count();
                int[] conteo = new int[tamaño];
                string[] nomImagen = new string[tamaño];

                for (int i = 0; i < tamaño; i++)
                {
                    apoyo = seleccionAlmacenar.ElementAt(0);
                    nomImagen[i] = nuevoUsuario.RegresaNombreImagen(apoyo);
                    conteo[i] = nuevoUsuario.ContarUriSesionMuestreo(inicio, nomImagen[i]);
                    seleccionAlmacenar.Remove(apoyo);
                }

                if (CreaExcel(aExcel, conteo, nomImagen))
                {
                    var salida = MessageBox.Show("Has almacenado la información correctamente", "Terminar sesión",
                                        MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    if (salida.Equals(MessageBoxResult.OK))
                    {
                        apoyoCerrar = "Cerrar";
                        VentanaHome v = new VentanaHome(idLlaves);
                        v.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                image1_VComparacion.BeginInit();
                image1_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par0, UriKind.RelativeOrAbsolute));
                image1_VComparacion.EndInit();

                image2_VComparacion.BeginInit();
                image2_VComparacion.Source = new BitmapImage(new Uri(parejas.ElementAt(0).Par1, UriKind.RelativeOrAbsolute));
                image2_VComparacion.EndInit();

                imagen0 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par0);
                imagen1 = nuevoUsuario.RegresaNombreImagen(parejas.ElementAt(0).Par1);
            }
        }

        private bool CreaExcel(List <DatosMuestreo> a, int[] cont, string[] nombres)
        {
            DatosUsuario pacienteActual = new DatosUsuario();
            Imc ImcActual = new Imc();
            int[] llaves = { 0, 0 };

            int contarDatos = 0;

            int[] numeroElecciones;
            string[] nombresElecciones;

            numeroElecciones = cont;
            nombresElecciones = nombres;
            List<DatosMuestreo> dMuestreo = a;

            contarDatos = dMuestreo.Count();

            nuevoUsuario = new TablasDBHelper();

            llaves = nuevoUsuario.RegresaLlavesUsuarioImc(idLlaves);

            pacienteActual = nuevoUsuario.RegresaDatosUsuarioConsulta(llaves[0]);
            ImcActual = nuevoUsuario.RegresaImcUsuarioConsulta(llaves[1]);

            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
            }

            Excel._Workbook libro;
            Excel._Worksheet hoja, hoja2, hoja3;
            Excel.Range rango = null;

            object misValue = System.Reflection.Missing.Value;

            libro = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            hoja = (Excel._Worksheet)libro.Worksheets.Add();
            hoja.Name = "DATOS USUARIO";

            hoja2 = (Excel._Worksheet)libro.Worksheets.Add();
            hoja2.Name = "SESION MUESTREO";

            hoja3 = (Excel._Worksheet)libro.Worksheets.Add();
            hoja3.Name = "RESULTADOS MUESTREO";

            try
            {
                hoja.Cells[1, 2] = "DATOS DE USUARIO";

                hoja.Cells[3, 2] = Contrato.DatosUsuario.NOMBRE;
                hoja.Cells[4, 2] = Contrato.DatosUsuario.APELLIDOS;
                hoja.Cells[5, 2] = Contrato.DatosUsuario.EDAD;
                hoja.Cells[6, 2] = Contrato.DatosUsuario.ESCOLARIDAD;
                hoja.Cells[7, 2] = Contrato.DatosUsuario.SEXO;
                hoja.Cells[8, 2] = Contrato.DatosUsuario.TUTOR;
                hoja.Cells[9, 2] = Contrato.DatosUsuario.EDAD_TUTOR;
                hoja.Cells[10, 2] = Contrato.DatosUsuario.TELEFONO_TUTOR;
                hoja.Cells[11, 2] = Contrato.DatosUsuario.MAIL;
                hoja.Cells[12, 2] = Contrato.DatosUsuario.CODIGO;

                hoja.Cells[13, 2] = Contrato.Imc.PESO;
                hoja.Cells[14, 2] = Contrato.Imc.ESTATURA;
                hoja.Cells[15, 2] = Contrato.Imc.IMC;

                rango = hoja.Range["B1"];
                rango.Font.Bold = true;
                rango.Font.Size = 12;

                rango = hoja.Range["B3:B15"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                rango.Font.Size = 14;

                rango.Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#1976D2"));
                rango.Font.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FFF"));

                rango = hoja.Columns[1];
                rango.ColumnWidth = 1;
                rango = hoja.Columns[2];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[3];
                rango.ColumnWidth = 40;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                hoja.Cells[3, 3] = pacienteActual.Nombre;
                hoja.Cells[4, 3] = pacienteActual.Apellidos;
                hoja.Cells[5, 3] = pacienteActual.Edad;
                hoja.Cells[6, 3] = pacienteActual.Escolaridad;
                hoja.Cells[7, 3] = pacienteActual.Sexo;
                hoja.Cells[8, 3] = pacienteActual.NombreTutor;
                hoja.Cells[9, 3] = pacienteActual.EdadTutor;
                hoja.Cells[10, 3] = pacienteActual.TelefonoTutor;
                hoja.Cells[11, 3] = pacienteActual.Mail;
                hoja.Cells[12, 3] = pacienteActual.Codigo;

                hoja.Cells[13, 3] = ImcActual.Peso;
                hoja.Cells[14, 3] = ImcActual.Estatura;
                hoja.Cells[15, 3] = ImcActual.IMC;

                rango = hoja.Range["C3:C15"];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                hoja2.Cells[1, 2] = "SESION DE MUESTREO";

                hoja2.Cells[3, 2] = Contrato.SesionMuestreoSeci.IMAGEN_1;
                hoja2.Cells[3, 3] = Contrato.SesionMuestreoSeci.IMAGEN_2;
                hoja2.Cells[3, 4] = Contrato.SesionMuestreoSeci.RESULTADO;
                hoja2.Cells[3, 5] = Contrato.SesionMuestreoSeci.TIEMPO_ELECCION;

                rango = hoja2.Range["B1"];
                rango.Font.Bold = true;
                rango.Font.Size = 12;

                rango = hoja2.Range["B3:E3"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rango.Font.Size = 14;

                rango.Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#1976D2"));
                rango.Font.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FFF"));

                rango = hoja2.Columns[1];
                rango.ColumnWidth = 1;
                rango = hoja2.Columns[2];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[3];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[4];
                rango.ColumnWidth = 40;
                rango = hoja2.Columns[5];
                rango.ColumnWidth = 30;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                for (int i = 0; i < contarDatos; i++)
                {
                    hoja2.Cells[4 + i, 2] = dMuestreo.ElementAt(i).Imagen1;
                    hoja2.Cells[4 + i, 3] = dMuestreo.ElementAt(i).Imagen2;
                    hoja2.Cells[4 + i, 4] = dMuestreo.ElementAt(i).Resultado;
                    hoja2.Cells[4 + i, 5] = dMuestreo.ElementAt(i).Tiempo;
                }
                rango = hoja2.Range["B4:E48"];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                hoja3.Cells[1, 2] = "RESULTADOS MUESTREO";

                hoja3.Cells[3, 2] = Contrato.SesionMuestreoSeci.RESULTADO;
                hoja3.Cells[3, 3] = "numero_de_elecciones";

                rango = hoja3.Range["B1"];
                rango.Font.Bold = true;
                rango.Font.Size = 12;

                rango = hoja3.Range["B3:C3"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rango.Font.Size = 14;

                rango.Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#1976D2"));
                rango.Font.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FFF"));

                rango = hoja3.Columns[1];
                rango.ColumnWidth = 1;
                rango = hoja3.Columns[2];
                rango.ColumnWidth = 40;
                rango = hoja3.Columns[3];
                rango.ColumnWidth = 30;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                for (int i = 0; i < numeroElecciones.Length; i++)
                {
                    hoja3.Cells[4 + i, 2] = nombresElecciones[i];
                    hoja3.Cells[4 + i, 3] = numeroElecciones[i];
                }
                rango = hoja3.Range["B4:C13"];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            libro.Saved = true;

            SaveFileDialog v = new SaveFileDialog();
            v.AddExtension = true;
            v.DefaultExt = "xlsx";
            v.CheckPathExists = true;
            v.Filter = "Archivos de Excel (*.xls, *.xlsx)|*.xls;*.xlsx| Todos los Archivos (*.*)|*.*";
            v.Title = "Guardar información de Alimentación";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (v.ShowDialog().Equals(true))
            {
                libro.SaveAs(v.FileName);
                libro.Close(true, misValue, misValue);
                xlApp.Quit();

                try
                {
                    Marshal.ReleaseComObject(hoja);
                    Marshal.ReleaseComObject(libro);
                    Marshal.ReleaseComObject(xlApp);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error mientras liberabas memoria de objeto " + e.Message);
                }
                finally
                {
                    GC.Collect();
                }
                return true;
            }
            else
            {
                libro.Close(true, misValue, misValue);
                xlApp.Quit();

                try
                {
                    Marshal.ReleaseComObject(hoja);
                    Marshal.ReleaseComObject(libro);
                    Marshal.ReleaseComObject(xlApp);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error mientras liberabas memoria de objeto " + e.Message);
                }
                finally
                {
                    GC.Collect();
                }
                return false;
            }

        }

    }
}
