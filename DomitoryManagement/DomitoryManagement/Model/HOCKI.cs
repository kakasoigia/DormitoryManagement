//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomitoryManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HOCKI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCKI()
        {
            this.BIENLAIHOANTRAPHONGs = new HashSet<BIENLAIHOANTRAPHONG>();
            this.BIENLAITHUEPHONGs = new HashSet<BIENLAITHUEPHONG>();
            this.BIENLAITIENPHONGs = new HashSet<BIENLAITIENPHONG>();
            this.DANHSACHSV_TIENPHONG = new HashSet<DANHSACHSV_TIENPHONG>();
        }
    
        public string TENHOCKI { get; set; }
        public int IDHOCKI { get; set; }
        public string NGAYBATDAU { get; set; }
        public string NGAYKETHUC { get; set; }
        public string TENNAMHOC { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAIHOANTRAPHONG> BIENLAIHOANTRAPHONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAITHUEPHONG> BIENLAITHUEPHONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAITIENPHONG> BIENLAITIENPHONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHSACHSV_TIENPHONG> DANHSACHSV_TIENPHONG { get; set; }
    }
}
