//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLThuVIen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHIEUTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUTRA()
        {
            this.PHIEUMUONs = new HashSet<PHIEUMUON>();
        }
    
        public string ID_TRASACH { get; set; }
        public Nullable<System.DateTime> NGAYTRA { get; set; }
        public string TINHTRANG { get; set; }
        public string NDVIPHAM { get; set; }
        public string ID_DOCGIA { get; set; }
    
        public virtual DOCGIA DOCGIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }
    }
}
