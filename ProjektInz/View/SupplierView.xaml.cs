﻿using ProjektInz.ViewModel;
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
    /// Logika interakcji dla klasy SupplierView.xaml
    /// </summary>
    public partial class SupplierView : UserControl
    {
        SupplierViewModel viewModel;
        public SupplierView()
        {
            InitializeComponent();
            viewModel = new SupplierViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.GetSupplierData();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = e.Source as DataGridRow;
            new SupplierDetailsView(row.Item).ShowDialog();
        }
    }
}
