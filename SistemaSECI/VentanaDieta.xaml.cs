using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

//        Excel.Application e = default(Excel.Application);

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
    }
}
