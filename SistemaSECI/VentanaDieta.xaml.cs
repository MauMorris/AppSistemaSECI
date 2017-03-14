using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace SistemaSECI
{
    /// <summary>
    /// Interaction logic for VentanaDieta.xaml
    /// </summary>
    public partial class VentanaDieta : Window
    {
        string[] dias = { "lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo" };
        int auxiliarDias;

        DietaDiaria[] semana;
        BanderaAlimentacion[] banderas;

        DietaDiaria vacio;

        ExpresionesReg match = new ExpresionesReg();

        DatosUsuario paciente;
        TablasDBHelper nuevoUsuario;

        int idLlaves = 0;
        string apoyoCerrar = "CerrarVentana";


        public VentanaDieta(int id)
        {
            InitializeComponent();

            semana = new DietaDiaria[7];
            banderas = new BanderaAlimentacion[7];
            for (int x = 0; x <= 6; x++)
            {
                semana[x] = new DietaDiaria();
                banderas[x] = new BanderaAlimentacion();
                semana[x].Dia = dias[x];
            }

            banderas[0].Bandera = (int)DiaSemana.lunes;
            banderas[1].Bandera = (int)DiaSemana.martes;
            banderas[2].Bandera = (int)DiaSemana.miercoles;
            banderas[3].Bandera = (int)DiaSemana.jueves;
            banderas[4].Bandera = (int)DiaSemana.viernes;
            banderas[5].Bandera = (int)DiaSemana.sabado;
            banderas[6].Bandera = (int)DiaSemana.domingo;

            vacio = new DietaDiaria();

            paciente = new DatosUsuario();
            nuevoUsuario = new TablasDBHelper();

            idLlaves = id;

            InicializaTB();

            desayunoTB_VDieta.Focus();
            auxiliarDias = (int) DiaSemana.lunes;

            lBox_VDieta.SelectedItem = lunesLBI_VDieta;
        }

        private void InicializaTB()
        {
            desayunoTB_VDieta.Text = String.Empty;
            almuerzoTB_VDieta.Text = String.Empty;
            comidaTB_VDieta.Text = String.Empty;
            meriendaTB_VDieta.Text = String.Empty;
            cenaTB_VDieta.Text = String.Empty;
            rubricaTB_VDieta.Text = String.Empty;
            comentarioTB_VDieta.Text = String.Empty;
        }

        private void lBox_VDieta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            switch (lbi.Content.ToString())
            {
                case "LUNES":

                    if (banderas[0].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.lunes;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[0].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.lunes;
                        BorraTB();
                        banderas[0].Click = true;
                    }
                    break;
                case "MARTES":
                    if (banderas[1].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int) DiaSemana.martes;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[1].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.martes;
                        BorraTB();
                        banderas[1].Click = true;
                    }
                    break;
                case "MIERCOLES":
                    if (banderas[2].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.miercoles;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[2].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.miercoles;
                        BorraTB();
                        banderas[2].Click = true;
                    }
                    break;
                case "JUEVES":
                    if (banderas[3].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.jueves;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[3].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.jueves;
                        BorraTB();
                        banderas[3].Click = true;
                    }
                    break;
                case "VIERNES":
                    if (banderas[4].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.viernes;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[4].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.viernes;
                        BorraTB();
                        banderas[4].Click = true;
                    }
                    break;
                case "SABADO":
                    if (banderas[5].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.sabado;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[5].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.sabado;
                        BorraTB();
                        banderas[5].Click = true;
                    }
                    break;
                case "DOMINGO":
                    if (banderas[6].Click)
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.domingo;
                        BorraTB();
                        recuperaDatosTB(auxiliarDias);
                        banderas[6].Click = true;
                    }
                    else
                    {
                        guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));
                        auxiliarDias = (int)DiaSemana.domingo;
                        BorraTB();
                        banderas[6].Click = true;
                    }

                    break;
                default:
                    break;
            }
        }

        public string recibirDia(int dia)
        {
            string diaSemana = string.Empty;

            switch (dia)
            {
                case 0:
                    diaSemana = dias[0];
                    break;
                case 1:
                    diaSemana = dias[1];
                    break;
                case 2:
                    diaSemana = dias[2];
                    break;
                case 3:
                    diaSemana = dias[3];
                    break;
                case 4:
                    diaSemana = dias[4];
                    break;
                case 5:
                    diaSemana = dias[5];
                    break;
                case 6:
                    diaSemana = dias[6];
                    break;
                default:
                    break;
            }
            return diaSemana;
        }

        private void BorraTB()
        {
            desayunoTB_VDieta.Text = vacio.Desayuno;
            almuerzoTB_VDieta.Text = vacio.Almuerzo;
            comidaTB_VDieta.Text = vacio.Comida;
            meriendaTB_VDieta.Text = vacio.Merienda;
            cenaTB_VDieta.Text = vacio.Cena;
            rubricaTB_VDieta.Text = vacio.Rubrica.ToString();
            comentarioTB_VDieta.Text = vacio.Comentarios;
        }

        private void recuperaDatosTB(int i)
        {
            desayunoTB_VDieta.Text = semana[i].Desayuno;
            almuerzoTB_VDieta.Text = semana[i].Almuerzo;
            comidaTB_VDieta.Text = semana[i].Comida;
            meriendaTB_VDieta.Text = semana[i].Merienda;
            cenaTB_VDieta.Text = semana[i].Cena;
            rubricaTB_VDieta.Text = semana[i].Rubrica.ToString();
            comentarioTB_VDieta.Text = semana[i].Comentarios;
        }

        private void guardaDatosTB(int i, string dia)
        {
            int result = 0;

            semana[i].Dia = dia;
            semana[i].Desayuno = desayunoTB_VDieta.Text;
            semana[i].Almuerzo = almuerzoTB_VDieta.Text;
            semana[i].Comida = comidaTB_VDieta.Text;
            semana[i].Merienda = meriendaTB_VDieta.Text;
            semana[i].Cena = cenaTB_VDieta.Text;
            semana[i].Comentarios = comentarioTB_VDieta.Text;

            if (Int32.TryParse(rubricaTB_VDieta.Text, out result))
                semana[i].Rubrica = result;
            else
                semana[i].Rubrica = 0;
        }

        private void ValidarNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.Numero(e.Text);
        }

        private void ValidarTextoNumero(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !match.TextoNumeros(e.Text);
        }

        private void PegarTextoNumero(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.TextoNumeros(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void PegarNumero(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!match.Numero(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();
        }

        private void OkBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            guardaDatosTB(auxiliarDias, recibirDia(auxiliarDias));

            int a = 0;

            for (int i = 0; i < 7; i++)
            {
                if (TodoBien(i))
                    a++;
            }
                if (a > 6)
                {
                    QueryParametros();
                    if (CreaExcel())
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
                    MessageBox.Show("Necesitas completar la información de la sesión", "Error de ingreso de información",
                                                MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void regresarBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            apoyoCerrar = "Regresar";
            VentanaHome v = new VentanaHome(idLlaves);
            v.Show();
            this.Close();
        }

        private void videoBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = false;
            v.Filter = "AVI (*.avi)|*.avi| MPG (*.mpg)|*.mpg| Windows Media Video (*.wmv)|*.wmv| 3gp (*.3gp)|*.3gp| Quick Time (*.mov)|*.mov| Flash (*.flv)|*.flvv| MPEG-4 (*.mp4)|*.mp4| Todos los Archivos (*.*)|*.*";
            v.Title = "Selección de videos";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (v.ShowDialog().Equals(true))
                System.Diagnostics.Process.Start(v.FileName);
//            System.Diagnostics.Process.Start("https://www.youtube.com/?hl=es-419&gl=MX");
        }

        private void guiaBoton_VDieta_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog v = new OpenFileDialog();
            v.Multiselect = false;
            v.Filter = "Presentaciones de Power Point (*.ppt, *.pptx)|*.ppt;*.pptx| PDF files (*.pdf)|*.pdf| Documentos de Word (*.doc, *.docx)|*.doc;*.docx| Archivos de Excel (*.xls, *.xlsx)|*.xls;*.xlsx| Todos los Archivos (*.*)|*.*";
            v.Title = "Selección para el paciente";
            v.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (v.ShowDialog().Equals(true))
                System.Diagnostics.Process.Start(v.FileName);
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

        private bool TodoBien(int i)
        {
            if (semana[i].Dia == String.Empty | semana[i].Desayuno == String.Empty |
                semana[i].Almuerzo == String.Empty | semana[i].Comida == String.Empty |
                semana[i].Merienda == String.Empty | semana[i].Cena == String.Empty |
                semana[i].Rubrica == 0 | semana[i].Comentarios == String.Empty)
            {
                MessageBox.Show("Necesitas llenar uno o más parámetros en los días de la semana", 
                            "Error de ingreso de información", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void QueryParametros()
        {
            nuevoUsuario = new TablasDBHelper();

            for(int i= 0; i< 7; i++)
            {
                nuevoUsuario.InsertarDietaDiaria(semana[i].Dia, semana[i].Desayuno, semana[i].Almuerzo, semana[i].Comida,
                                                    semana[i].Merienda, semana[i].Cena, semana[i].Rubrica, semana[i].Comentarios);
            }
        }

        private bool CreaExcel()
        {
            DatosUsuario pacienteActual = new DatosUsuario();
            Imc ImcActual = new Imc();

            int[] llaves = { 0, 0 };

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
            Excel._Worksheet hoja, hoja2;
            Excel.Range rango = null;

            object misValue = System.Reflection.Missing.Value;

            libro = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);

            hoja = (Excel._Worksheet)libro.Worksheets.Add();
            hoja.Name = "DATOS USUARIO";

            hoja2 = (Excel._Worksheet)libro.Worksheets.Add();
            hoja2.Name = "ALIMENTACION";

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
                hoja2.Cells[1, 2] = "INFORMACION DE ALIMENTACION";

                hoja2.Cells[3, 2] = Contrato.DietaDiaria.DIA_SEMANA;
                hoja2.Cells[3, 3] = Contrato.DietaDiaria.DESAYUNO;
                hoja2.Cells[3, 4] = Contrato.DietaDiaria.ALMUERZO;
                hoja2.Cells[3, 5] = Contrato.DietaDiaria.COMIDA;
                hoja2.Cells[3, 6] = Contrato.DietaDiaria.MERIENDA;
                hoja2.Cells[3, 7] = Contrato.DietaDiaria.CENA;
                hoja2.Cells[3, 8] = Contrato.DietaDiaria.RUBRICA;
                hoja2.Cells[3, 9] = Contrato.DietaDiaria.COMENTARIOS;

                rango = hoja2.Range["B1"];
                rango.Font.Bold = true;
                rango.Font.Size = 12;

                rango = hoja2.Range["B3:I3"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rango.Font.Size = 14;

                rango.Interior.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#1976D2"));
                rango.Font.Color = ColorTranslator.ToOle(ColorTranslator.FromHtml("#FFF"));

                rango = hoja2.Columns[1];
                rango.ColumnWidth = 1;
                rango = hoja2.Columns[2];
                rango.ColumnWidth = 25;
                rango = hoja2.Columns[3];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[4];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[5];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[6];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[7];
                rango.ColumnWidth = 30;
                rango = hoja2.Columns[8];
                rango.ColumnWidth = 20;
                rango = hoja2.Columns[9];
                rango.ColumnWidth = 70;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en creacion/actualizacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            try
            {
                for (int i = 0; i < 7; i++)
                {
                    hoja2.Cells[4+i, 2] = semana[i].Dia;
                    hoja2.Cells[4+i, 3] = semana[i].Desayuno;
                    hoja2.Cells[4+i, 4] = semana[i].Almuerzo;
                    hoja2.Cells[4+i, 5] = semana[i].Comida;
                    hoja2.Cells[4+i, 6] = semana[i].Merienda;
                    hoja2.Cells[4+i, 7] = semana[i].Cena;
                    hoja2.Cells[4+i, 8] = semana[i].Rubrica;
                    hoja2.Cells[4+i, 9] = semana[i].Comentarios;
                }
                rango = hoja2.Range["B4:I10"];
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
