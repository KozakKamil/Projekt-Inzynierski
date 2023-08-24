using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjektInz.ViewModel
{
    internal class WorkerDetailsViewModel : INotifyPropertyChanged
    {
        public Connection _connection;
        public event PropertyChangedEventHandler PropertyChanged;
        public Worker Worker;

        public Action CloseAction { get; set; }

        public WorkerDetailsViewModel() 
        {
            _connection = new Connection();
        }

        public async Task GetWorkerDetailsData(Worker worker)
        {
            Worker = (await _connection.GetWorkerDetailsData(worker.Id_worker));
                if(Worker == null)
            {
                MessageBox.Show("Brak danych do wyświetlenia", "Błąd");
                CloseAction();
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Worker)));
        }
    }
}
