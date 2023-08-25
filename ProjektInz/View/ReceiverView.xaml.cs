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
    /// Logika interakcji dla klasy ReceiverView.xaml
    /// </summary>
    public partial class ReceiverView : UserControl
    {
        ReceiverViewModel viewModel;
        public ReceiverView()
        {
            InitializeComponent();
            viewModel = new ReceiverViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetReceiverData();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = e.Source as DataGridRow;
            new ReceiverDetailsView(row.Item).ShowDialog();
        }
    }
}
