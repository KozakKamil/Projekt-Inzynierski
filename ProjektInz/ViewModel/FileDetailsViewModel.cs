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
    internal class FileDetailsViewModel : INotifyPropertyChanged
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public FileDetailsViewModel() 
        {
            _connection = new Connection();
        }

        public async Task GetFilesDetailsData()
        {

        }
    }
}
