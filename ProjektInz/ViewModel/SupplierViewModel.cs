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
    internal class SupplierViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Connection _connection;
        public List<Company> supplierCompany { get; set; }

        public SupplierViewModel() { _connection = new Connection(); }

        public async Task GetSupplierData()
        {
            supplierCompany = await _connection.GetSupplierData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(supplierCompany)));

        }
    }
}
