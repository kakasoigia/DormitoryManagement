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
    
    public partial class CANBO
    {
        public int IDCANBO { get; set; }
        public Nullable<int> MSCB { get; set; }
        public string HOTEN { get; set; }
        public string NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public string QUOCTICH { get; set; }
        public string DANTOC { get; set; }
        public string NGAYVAOLAM { get; set; }
        public string CHUCVU { get; set; }
        public Nullable<int> IDUSER { get; set; }
    
        public virtual User User { get; set; }
    }
}
