using CommunityToolkit.Mvvm.Input;
using ProjektInz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektInz
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new FileViewModel();
        }

        private void btnDocuments_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DocumentsViewModel();
        }

        private void btnReceiver_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReceiverViewModel();
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SupplierViewModel();
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new WorkerViewModel();
        }

        private void btnState_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new StateViewModel();
        }
    }
}
