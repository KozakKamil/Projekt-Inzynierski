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

namespace ProjektInz.View
{
    /// <summary>
    /// Logika interakcji dla klasy WorkerView.xaml
    /// </summary>
    public partial class WorkerView : UserControl
    {
        WorkerViewModel workerViewModel;
        public WorkerView()
        {
            InitializeComponent();
            workerViewModel = new WorkerViewModel();
            DataContext = workerViewModel;
            Loaded += async (s, e) => await workerViewModel.GetWorkerData();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = e.Source as DataGridRow;
            new WorkerDetailsView(row.Item).ShowDialog();
        }
    }
}
