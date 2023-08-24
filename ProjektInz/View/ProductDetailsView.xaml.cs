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
    /// Logika interakcji dla klasy ProductDetailsView.xaml
    /// </summary>
    public partial class ProductDetailsView : Window
    {
        ProductDetailsViewModel viewModel;
        public ProductDetailsView(object product)
        {
            InitializeComponent();
            viewModel = new ProductDetailsViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetProductDetailsData(product as Product);
            if(viewModel.CloseAction == null)
            {
                viewModel.CloseAction = new Action(this.Close);
            }
        }
    }
}
