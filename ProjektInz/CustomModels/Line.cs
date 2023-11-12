using System.Collections.Generic;

namespace ProjektInz.CustomModels
{
    public class Line
    {
       public int Number { get; set; }
       public List<Shelf> Shelves { get; set; }
    }

    public class Shelf
    {
        public int Number { get; set; }
        public int LineNumber { get; set; }
        public int MaxRackNumber { get; set; }
        public int BusyRacks { get; set; }
        public string FillInfo { get; set; }
    }

}
