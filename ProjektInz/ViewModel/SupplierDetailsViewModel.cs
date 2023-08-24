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
    internal class SupplierDetailsViewModel : INotifyPropertyChanged
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Company> CompanyList { get; set; }

        public SupplierDetailsViewModel() 
        {
            _connection = new Connection();
        }

        public async Task GetSupplierDetailsData(Company company)
        {
            CompanyList = await _connection.GetSupplierDetailsData(company.Id_company);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (nameof(CompanyList)));
        }
    }
}
