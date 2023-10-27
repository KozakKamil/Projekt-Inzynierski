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
    internal class AddCompanyViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        private Company company = new Company();
        public AddCompanyViewModel()
        {
            _connection = new Connection();
        }   

        public Company Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Company)));
            }
        }

        public async void AddCompany()
        {
            await _connection.AddCompany(Company);
        }
    }
}
