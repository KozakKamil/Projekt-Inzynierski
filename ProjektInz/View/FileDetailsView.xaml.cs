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
    /// Logika interakcji dla klasy DocumentDetailsView.xaml
    /// </summary>
    public partial class FileDetailsView : Window
    {
        FileDetailsViewModel viewModel;
        public FileDetailsView(object document)
        {
            InitializeComponent();
            viewModel = new FileDetailsViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetFilesDetailsData(document as Warehouse_Operation);
        }
    }
}
