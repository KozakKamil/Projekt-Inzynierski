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
    internal class AddVatViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        private VAT_rate _vat = new VAT_rate();

        public AddVatViewModel()
        {
            _connection = new Connection();
        }

        public VAT_rate Vat
        {
            get
            {
                return _vat;
            }
            set
            {
                _vat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vat)));
            }
        }

        public async void AddVat()
        {
            await _connection.AddVat(Vat);
        }
    }
}
