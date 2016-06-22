using System;
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
        ManejadorTablas nuevaBD;
        BackgroundWorker worker;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// Ejecuta tareas iniciales
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync(100);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int) e.Argument;
            nuevaBD = new ManejadorTablas();

            for (int i = 0; i < max; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(15);
                e.Result = i;
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pBar.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VentanaUsuarios v = new VentanaUsuarios();
            v.Show();
            this.Close();
        }
    }
}
