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
    /// Logika interakcji dla klasy FileView.xaml
    /// </summary>
    public partial class FileView : UserControl
    {
        FileViewModel viewModel;
        public FileView()
        {
            InitializeComponent();
            viewModel = new FileViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetFilesData();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = e.Source as DataGridRow;
            new DocumentDetailsView(row.Item).ShowDialog();
        }
    }
}
