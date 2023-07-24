using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class ReceiverViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Connection _connection;
        public List<Company> receiverCompany { get; set; }
        public ReceiverViewModel() { _connection = new Connection(); }

        public async Task GetReceiverData()
        {
            receiverCompany = await _connection.GetContractorData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(receiverCompany)));
        }
    }
}
