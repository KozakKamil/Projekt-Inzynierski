using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    internal class DocumentsViewModel : INotifyPropertyChanged
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Warehouse_document> Warehouse_Documents { get; set; }
        public DocumentsViewModel()
        {
            _connection = new Connection();
        }

        public async Task GetDocumentData()
        {
            Warehouse_Documents =  await _connection.GetDocumentData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Warehouse_Documents)));
        }
    }
}
