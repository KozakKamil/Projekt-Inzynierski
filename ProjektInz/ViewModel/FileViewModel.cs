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
    internal class FileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Connection _connection;

        public List<Warehouse_Operation> warehouse_Operations { get; set; }

        public FileViewModel() { _connection = new Connection(); }

        public async Task GetFilesData()
        {
            warehouse_Operations = await _connection.GetFilesData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(warehouse_Operations)));

        }
    }
}
