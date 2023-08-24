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
    internal class DocumentDetailsViewModel : INotifyPropertyChanged
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;
        public Warehouse_document Warehouse_document { get; set; }
        public List<Warehouse_Operation> Warehouse_Operations { get; set; }

        public DocumentDetailsViewModel() 
        {
            _connection = new Connection();
        }

        public async Task GetDocumentDetailsData(Warehouse_document warehouse_Document)
        {
            Warehouse_document = warehouse_Document; 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Warehouse_document)));

            Warehouse_Operations = await _connection.GetDocumentDetailsData(warehouse_Document.Id_document);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Warehouse_Operations)));
        }
    }
}
