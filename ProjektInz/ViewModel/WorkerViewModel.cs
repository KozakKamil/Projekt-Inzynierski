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
    internal class WorkerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Connection _connection;
        public List<Worker> workers {  get; set; }

        public WorkerViewModel() { _connection = new Connection(); }

        public async Task GetWorkerData()
        {
            workers = await _connection.GetWorkerData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(workers)));
        }
    }
}
