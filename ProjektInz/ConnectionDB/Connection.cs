using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ConnectionDB
{
    internal class Connection
    {
        public async Task<List<Warehouse_document>> GetDocumentData()
        {
            var context = new WarehousedbEntities();
            return context.Warehouse_document.Include(x => x.Document_type).
                Include(x => x.Company).
                Include(x => x.Company1).
                Include(x => x.Worker).
                ToList();
        }

        public async Task<List<Worker>> GetWorkerData()
        {
            var context = new WarehousedbEntities();
            return context.Workers.
                Include(x => x.Adress).
                Include(x => x.Position_title).
                ToList();
        }

        public async Task<List<Company>> GetSupplierData()
        {
            var context = new WarehousedbEntities();
            var c = context.Companies;

            var g = c.Where(x => x.Company_Type.Company_type1 == CompanyType.Supplier).
                Include(x => x.Adress).
                ToList();
            return g;
        }

        public async Task<List<Company>> GetContractorData()
        {
            var context = new WarehousedbEntities();
            return context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Contractor).
                Include(x => x.Adress).
                ToList();
        }

        public async Task<List<Product>> GetProductasData()
        {
            var context = new WarehousedbEntities();
            return context.Products.
                Include(x => x.Dangerous_Goods).
                ToList();
        }

        public async Task<List<Warehouse_Operation>> GetFilesData()
        {
            var context = new WarehousedbEntities();
            return context.Warehouse_Operation.
                Include(x=>x.Product).
                Include(x=>x.Warehouse_document.Document_type).
                Include(x=>x.Product.Dangerous_Goods).
                ToList();
        }

        public async Task<List<Warehouse_Operation>> GetDocumentDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Warehouse_Operation.
                Where(x=>x.Id_document == Id).
                Include(x => x.Product).
                ToList();
        }

        public async Task<Product> GetProductDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Products.
                Where(x => x.Id_product == Id).
                Include(x => x.Dangerous_Goods).
                FirstOrDefault();
        }

        public async Task<Company> GetReceiverDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Contractor).
                Where(x => x.Id_company == Id).
                Include(x => x.Adress).
                FirstOrDefault();
        }

        public async Task<Company> GetSupplierDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Supplier).
                Where(x => x.Id_company == Id).
                Include(x => x.Adress).
                FirstOrDefault();
        }

        public async Task<Worker> GetWorkerDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Workers.
                Where(x => x.Id_worker == Id).
                Include(x => x.Adress).
                Include(x => x.Position_title).
                FirstOrDefault();
        }

        public async Task<Warehouse_Operation> GetFilesDetailsData(int Id)
        {
            var context = new WarehousedbEntities();
            return context.Warehouse_Operation.
                FirstOrDefault();

        }
    }
}
