using ProjektInz.ConnectionDB;
using ProjektInz.CustomModels;
using ProjektInz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInz.ViewModel
{
    public class StateViewModel
    {
        private readonly Connection _connection;

        public List<Line> Warehouse { get; set; }
        public StateViewModel()
        {
            _connection = new Connection();
            Load();
        }

        public async Task Load()
        {
            var warehause = (await _connection.GetWarehouseState()).ToList();

            Warehouse = warehause.GroupBy(x => new { x.Lane_number })
                .Select(line => new Line
                {
                    Number = line.Key.Lane_number,
                    Shelves = line.GroupBy(x => x.Shelf_number)
                        .Select(shelfGroup => new Shelf
                        {
                            Number = shelfGroup.Key,
                            LineNumber = line.Key.Lane_number,
                            MaxRackNumber = shelfGroup.Count(),
                            BusyRacks = shelfGroup.Count(x => x.IsBusy),
                            FillInfo = $"{shelfGroup.Count(x => x.IsBusy)} / {shelfGroup.Count()}"
                        }).ToList()
                }).ToList();

            Warehouse.OrderBy(x=>x.Number);
            Warehouse.ForEach(x => x.Shelves.OrderBy(y => y.Number));
        }

    }
}
