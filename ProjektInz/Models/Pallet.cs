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
    
    public partial class Pallet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pallet()
        {
            this.Warehouse_Operation = new HashSet<Warehouse_Operation>();
        }
    
        public int Id_pallet { get; set; }
        public int QR_code { get; set; }
        public int Id_warehouse { get; set; }
        public int Id_type { get; set; }
    
        public virtual Pallet_type Pallet_type { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse_Operation> Warehouse_Operation { get; set; }
    }
}
