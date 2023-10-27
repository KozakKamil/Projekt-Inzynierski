using ProjektInz.ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class AddAdressViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddAdressViewModel()
        {
            _connection = new Connection();
        }
    }
}
