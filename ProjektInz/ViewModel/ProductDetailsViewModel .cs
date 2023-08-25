using CommunityToolkit.Mvvm.Input;
using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using ProjektInz.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektInz.ViewModel
{

    internal class ProductDetailsViewModel : INotifyPropertyChanged
    {

        public Connection _connection;
        public event PropertyChangedEventHandler PropertyChanged;
        public Product Products { get; set; }

        public Action CloseAction { get; set; }

        public ProductDetailsViewModel()
        {
            _connection = new Connection();
        }

        public async Task GetProductDetailsData(Product product)
        {

            Products = (await _connection.GetProductDetailsData(product.Id_product));
            if (Products == null)
            {
                MessageBox.Show("Brak danych do wyświetlenia", "Błąd");
                CloseAction();
            }
            else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Products)));
            }
        }
    }
}
