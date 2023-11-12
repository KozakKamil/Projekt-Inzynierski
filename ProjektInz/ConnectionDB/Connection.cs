using ProjektInz.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace ProjektInz.ConnectionDB
{
    public class Connection
    {
        private readonly WarehousedbEntities _context;
        public Connection()
        {
            _context = new WarehousedbEntities();
        }

        public async Task<List<Warehouse_document>> GetDocumentData()
        {
            return _context.Warehouse_document.Include(x => x.Company)
                                              .Include(x => x.Company1)
                                              .Include(x => x.Worker)
                                              .Include(x => x.Document_type)
                                              .Include(x => x.Warehouse_Operation)
                                              .ToList();
        }

        public async Task<List<Worker>> GetWorkerData()
        {
            return _context.Workers.
                Include(x => x.Adress).
                Include(x => x.Position_title).
                ToList();
        }

        public async Task<List<Company>> GetSupplierData()
        {
            var c = _context.Companies;

            var g = c.Where(x => x.Company_Type.Company_type1 == CompanyType.Supplier).
                Include(x => x.Adress).
                ToList();
            return g;
        }

        public async Task<List<Company>> GetContractorData()
        {
            return _context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Contractor).
                Include(x => x.Adress).
                ToList();
        }
        public async Task<List<Company>> GetCompanyData()
        {
            return _context.Companies.
                Include(x => x.Adress).
                ToList();
        }

        public async Task<List<Product>> GetProductasData()
        {
            return _context.Products.
                Include(x => x.Dangerous_Goods).
                ToList();
        }

        public async Task<List<Warehouse_Operation>> GetFilesData()
        {
            return _context.Warehouse_Operation.
                Include(x => x.Product).
                Include(x => x.Warehouse_document.Document_type).
                Include(x => x.Product.Dangerous_Goods).
                ToList();
        }

        public Task<List<VAT_rate>> GetVatData()
        {
            return Task.Run(() => _context.VAT_rate.ToList());
        }

        public Task<List<Document_type>> GetDocumentsTypeData()
        {
            return Task.Run(() => _context.Document_type.ToList());
        }

        public async Task<List<Warehouse_Operation>> GetDocumentDetailsData(int Id)
        {
            return _context.Warehouse_Operation.
                Where(x => x.Id_document == Id).
                Include(x => x.Product).
                ToList();
        }

        public async Task<Product> GetProductDetailsData(int Id)
        {
            return _context.Products.
                Where(x => x.Id_product == Id).
                Include(x => x.Dangerous_Goods).
                FirstOrDefault();
        }

        public async Task<Company> GetReceiverDetailsData(int Id)
        {
            return _context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Contractor).
                Where(x => x.Id_company == Id).
                Include(x => x.Adress).
                FirstOrDefault();
        }

        public async Task<Company> GetSupplierDetailsData(int Id)
        {
            return _context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Supplier).
                Where(x => x.Id_company == Id).
                Include(x => x.Adress).
                FirstOrDefault();
        }

        public async Task<Worker> GetWorkerDetailsData(int Id)
        {
            return _context.Workers.
                Where(x => x.Id_worker == Id).
                Include(x => x.Adress).
                Include(x => x.Position_title).
                FirstOrDefault();
        }

        public async Task<Warehouse_Operation> GetFilesDetailsData(int Id)
        {
            return _context.Warehouse_Operation.
                Where(x => x.Id_operation == Id).
                Include(x => x.Product).
                Include(x => x.Product.Dangerous_Goods).
                Include(x => x.VAT_rate).
                Include(x => x.Warehouse_document).
                Include(x => x.Warehouse_document.Document_type).
                FirstOrDefault();

        }

        public Task<Pallet> GetPallet()
        {
            return Task.Run(() => _context.Pallets.First());
        }

        // Warehouse state

        public async Task<IEnumerable<Warehouse>> GetWarehouseState()
        {
            return _context.Warehouses;
        }

        //Add data to database
        public async Task AddWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
        }

        public async Task AddVat(VAT_rate vat)
        {
            _context.VAT_rate.Add(vat);
            await _context.SaveChangesAsync();
        }
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddPosition(Position_title position)
        {
            _context.Position_title.Add(position);
            await _context.SaveChangesAsync();
        }

        public async Task AddDocument(Warehouse_document warehouse_Document)
        {
            _context.Warehouse_document.Add(warehouse_Document);
            await _context.SaveChangesAsync();
        }

        public async Task AddCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task AddAdress(Adress adress)
        {
            _context.Adresses.Add(adress);
            await _context.SaveChangesAsync();
        }

        //Edit 

        public async Task EditDocument(Warehouse_document warehouse_Document)
        {
            var doc = _context.Warehouse_document.Where(x => x.Id_document == warehouse_Document.Id_document).FirstOrDefault();

            doc.Doc_number = warehouse_Document.Doc_number;
            doc.Company1 = warehouse_Document.Company1;
            doc.Company = warehouse_Document.Company;
            doc.Document_type = warehouse_Document.Document_type;
            doc.Worker = warehouse_Document.Worker;
            doc.Issue_date = warehouse_Document.Issue_date;
            doc.Operation_date = warehouse_Document.Operation_date;
            doc.Comments = warehouse_Document.Comments;
            doc.Warehouse_Operation = warehouse_Document.Warehouse_Operation;

            await _context.SaveChangesAsync();
        }

        //Usuwanie 
        public async Task DeleteWorker(Worker worker)
        {
            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompany(Company company)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocuments(Warehouse_Operation warehouse_Operation)
        {
            _context.Warehouse_Operation.Remove(warehouse_Operation);
            await _context.SaveChangesAsync();
        }
    }
}
