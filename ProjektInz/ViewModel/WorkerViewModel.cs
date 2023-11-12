using CommunityToolkit.Mvvm.Input;
using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektInz.ViewModel
{
    internal class WorkerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Connection _connection;
        public List<Worker> Workers {  get; set; }
        public ICommand DeleteWorkerCommand { get; private set; }

        private Worker worker;

        public WorkerViewModel() 
        { 
            _connection = new Connection();
        }

        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public async Task GetWorkerData()
        {
            Workers = await _connection.GetWorkerData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Workers)));
        }
    }
}
