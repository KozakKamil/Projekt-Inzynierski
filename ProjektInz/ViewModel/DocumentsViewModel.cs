using CommunityToolkit.Mvvm.Input;
using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using ProjektInz.View.AddingView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjektInz.ViewModel
{
    public partial class DocumentsViewModel : INotifyPropertyChanged
    {
        public ICommand AddDocumentCommand { get; private set; }
        public ICommand EditDocumentCommand { get; private set; }

        public Connection _connection;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Warehouse_document> Warehouse_Documents { get; set; }

        public Warehouse_document SelectedDocument { get; set; }

        public DocumentsViewModel()
        {
            _connection = new Connection();
            AddDocumentCommand = new RelayCommand(AddDoc);
            EditDocumentCommand = new RelayCommand(EditDoc);
        }

        public async Task GetDocumentData()
        {
            Warehouse_Documents =  await _connection.GetDocumentData();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Warehouse_Documents)));

        }

        public async void AddDoc()
        {
            new AddDocumentView().ShowDialog();
            await GetDocumentData();
        }

        public async void EditDoc()
        {
            new AddDocumentView(SelectedDocument).ShowDialog();
            await GetDocumentData();
        }
    }
}
