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
            ToList();
            return g;
        }

        public async Task<List<Company>> GetContractorData()
        {
            var context = new WarehousedbEntities();
            return context.Companies.
                Where(x => x.Company_Type.Company_type1 == CompanyType.Contractor).
                ToList();
        }
    }
}
