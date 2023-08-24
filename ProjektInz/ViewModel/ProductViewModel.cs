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
    internal class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Connection _connection;

        public List<Product> products { get; set; }

        public ProductViewModel() { _connection = new Connection(); }

        public async Task GetProductData()
        {
            products = await _connection.GetProductasData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(products)));

        }
    }
}
