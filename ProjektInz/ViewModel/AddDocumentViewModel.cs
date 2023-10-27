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
    internal class AddDocumentViewModel
    {
        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddDocumentCommand { get; private set; }
        private Warehouse_Operation operation = new Warehouse_Operation();
        public AddDocumentViewModel()
        {
            _connection = new Connection();
            AddDocumentCommand = new RelayCommand(AddDocument);
        }

        public Warehouse_Operation Operation
        {
            get
            {
                return operation;
            }
            set
            {
                operation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }

        public async void AddDocument()
        {
            await _connection.AddDocument(Operation);
        }
    }
}
