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
    
    public partial class PHIEUMUON
    {
        public string ID_MUONSACH { get; set; }
        public Nullable<System.DateTime> NGAYMUON { get; set; }
        public string GHICHU { get; set; }
        public string ID_DOCGIA { get; set; }
        public string ID_TRASACH { get; set; }
        public string ID_TAILIEU { get; set; }
    
        public virtual DOCGIA DOCGIA { get; set; }
        public virtual TAILIEU TAILIEU { get; set; }
        public virtual PHIEUTRA PHIEUTRA { get; set; }
    }
}
