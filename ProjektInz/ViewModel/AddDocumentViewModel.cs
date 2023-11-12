using CommunityToolkit.Mvvm.Input;
using ProjektInz.ConnectionDB;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjektInz.ViewModel
{
    internal class AddDocumentViewModel
    {
        public ICommand AddDocumentCommand { get; private set; }
        public ICommand AddOperationCommand { get; private set; }
        public ICommand RemoveOperationCommand { get; private set; }

        public Connection _connection;

        public bool isEdit { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;

        //ComboBox data 
        public List<Worker> ListOfWorker { get; set; }
        public List<Company> ListOfCompany { get; set; }
        public List<Document_type> ListOfDocumentsType { get; set; }

        //Dokument property
        public string DocumentName { get; set; }
        public Company ForeignCompany { get;
            set; }
        public Company OurCompany { get; set; }
        public Document_type DocumentType { get; set; }
        public Worker Worker { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime OperationDate { get; set; }
        public string Comments { get; set; }

        //Warehouse_Operation 
        public ObservableCollection<Warehouse_Operation> Operation { get; set; } = new ObservableCollection<Warehouse_Operation>();
        public List<Product> ListOfProducts { get; set; }
        public List<VAT_rate> ListOfVat { get; set; }
        public Pallet Pallet { get; set; }

        public AddDocumentViewModel()
        {
            _connection = new Connection();

            //add commands 
            AddDocumentCommand = new RelayCommand(AddDocument);
            AddOperationCommand = new RelayCommand(AddOperation);
            RemoveOperationCommand = new RelayCommand(RemoveOperation);

            //Get data to fill combobox 
            ListOfWorker = _connection.GetWorkerData().Result;
            ListOfCompany = _connection.GetCompanyData().Result;
            ListOfDocumentsType = _connection.GetDocumentsTypeData().Result;
            ListOfProducts = _connection.GetProductasData().Result;
            ListOfVat = _connection.GetVatData().Result;

            //set dates 
            IssueDate = DateTime.Now;
            OperationDate = DateTime.Now;

            Pallet = _connection.GetPallet().Result;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
        }

        [RelayCommand]
        public void RemoveOperation()
        {
            if (Operation.Count > 0)
                Operation.Remove(Operation.Last());
        }

        [RelayCommand]
        public void AddOperation()
        {
            Operation.Add(new Warehouse_Operation() { Pallet = Pallet });
        }

        public async void AddDocument()
        {
            try
            {
                var dokument = new Warehouse_document()
                {
                    Doc_number = DocumentName,
                    Company1 = ForeignCompany,
                    Company = OurCompany,
                    Document_type = DocumentType,
                    Worker = Worker,
                    Issue_date = IssueDate,
                    Operation_date = OperationDate,
                    Comments = Comments,
                    Warehouse_Operation = Operation
                };
                if (isEdit)
                {

                }
                else
                {
                    await _connection.AddDocument(dokument);
                }
                //Zamknąć okno

            }
            catch
            {
                MessageBox.Show("Dokument zawiera błedy. Nie udało się dodać dokumentu");
            }
        }
    }
}
