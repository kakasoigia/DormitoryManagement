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
    
    public partial class DANHSACHSV_TIENPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DANHSACHSV_TIENPHONG()
        {
            this.BIENLAITIENPHONGs = new HashSet<BIENLAITIENPHONG>();
        }
    
        public int IDSV_TIENPHONG { get; set; }
        public Nullable<int> IDSINHVIEN { get; set; }
        public Nullable<int> IDPHONG { get; set; }
        public Nullable<decimal> TIENPHAIDONG { get; set; }
        public string NGAYVAO { get; set; }
        public Nullable<bool> DADONGTIENPHONG { get; set; }
        public Nullable<bool> DADONGBHYT { get; set; }
        public Nullable<bool> DADONGBHTN { get; set; }
        public Nullable<int> IDHOCKI { get; set; }
        public Nullable<decimal> TIENBHYT { get; set; }
        public Nullable<decimal> TIENBHTN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BIENLAITIENPHONG> BIENLAITIENPHONGs { get; set; }
        public virtual PHONG PHONG { get; set; }
        public virtual SINHVIEN SINHVIEN { get; set; }
        public virtual HOCKI HOCKI { get; set; }
    }
}
