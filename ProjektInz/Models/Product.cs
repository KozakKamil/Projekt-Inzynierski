//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektInz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Warehouse_Operation = new HashSet<Warehouse_Operation>();
        }
    
        public int Id_product { get; set; }
        public string Product_name { get; set; }
        public string Product_code { get; set; }
        public Nullable<int> Minimum_stock { get; set; }
        public string Product_desc { get; set; }
        public Nullable<int> Id_ADR { get; set; }
    
        public virtual Dangerous_Goods Dangerous_Goods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse_Operation> Warehouse_Operation { get; set; }
    }
}