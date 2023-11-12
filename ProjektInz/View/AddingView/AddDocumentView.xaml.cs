using ProjektInz.Models;
using ProjektInz.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProjektInz.View.AddingView
{
    /// <summary>
    /// Logika interakcji dla klasy AddDocumentView.xaml
    /// </summary>
    public partial class AddDocumentView : Window
    {
        public AddDocumentView(Warehouse_document warehouse_Document = null)
        {
            InitializeComponent();
            var addDocumentViewModel = new AddDocumentViewModel();
            if (warehouse_Document != null)
            {
                addDocumentViewModel.isEdit = true;
                addDocumentViewModel.DocumentName = warehouse_Document.Doc_number;
                addDocumentViewModel.ForeignCompany = warehouse_Document.Company1;
                addDocumentViewModel.OurCompany = warehouse_Document.Company;
                addDocumentViewModel.DocumentType = warehouse_Document.Document_type;
                addDocumentViewModel.Worker = warehouse_Document.Worker;
                addDocumentViewModel.IssueDate = warehouse_Document.Issue_date;
                addDocumentViewModel.OperationDate = warehouse_Document.Operation_date;
                addDocumentViewModel.Comments = warehouse_Document.Comments;
                addDocumentViewModel.Operation = new ObservableCollection<Warehouse_Operation>(warehouse_Document.Warehouse_Operation);
            }
            DataContext = addDocumentViewModel;
        }
    }
}
