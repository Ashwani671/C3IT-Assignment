//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryMgmtSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ashwani
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ashwani()
        {
            this.Ashwani_Order = new HashSet<Ashwani_Order>();
        }
    
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string attname { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string user_level { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> udate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ashwani_Order> Ashwani_Order { get; set; }
    }
}
