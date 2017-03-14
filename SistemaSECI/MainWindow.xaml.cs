using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace SistemaSECI
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TablasDBHelper nuevaBD;
        private BackgroundWorker worker;

        private static int backgroundTime = 100;
        private static int sleepTime = 50;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// Ejecuta el hilo para conexion con la base de datos
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync(backgroundTime);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int tiempoMax = (int) e.Argument;
            nuevaBD = new TablasDBHelper();
//PROPOSITOS DE DESARROLLO            nuevaBD.BorrarTodo();

            for (int i = 0; i < tiempoMax; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(sleepTime);
                e.Result = i;
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VUsuarios v = new VUsuarios();
            v.Show();
            this.Close();
        }
    }
}
