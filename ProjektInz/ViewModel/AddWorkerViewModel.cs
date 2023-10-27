using ProjektInz.ConnectionDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class AddWorkerViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddWorkerViewModel()
        {
            _connection = new Connection();
        }

    }
}
