using ProjektInz.Models;
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
using System.Windows.Shapes;

namespace ProjektInz.View
{
    /// <summary>
    /// Logika interakcji dla klasy ReceiverDetailsView.xaml
    /// </summary>
    public partial class WorkerDetailsView : Window
    {
        WorkerDetailsViewModel viewModel;
        public WorkerDetailsView(object worker)
        {
            InitializeComponent();
            viewModel = new WorkerDetailsViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetWorkerDetailsData(worker as Worker);
        }
    }
}
