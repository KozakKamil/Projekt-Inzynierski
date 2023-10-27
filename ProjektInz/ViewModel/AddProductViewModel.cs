using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class AddProductViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        private Product product = new Product();

        public AddProductViewModel()
        {
            _connection = new Connection(); 
        }

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Product)));
            }
        }

        public async void AddProduct()
        {
            await _connection.AddProduct(product);
        }
    }
}
