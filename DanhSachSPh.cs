//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyCare
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhSachSPh
    {
        public string MaSP { get; set; }
        public string MaPhanLoai { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public string KhoiLuong { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string GioiThieu { get; set; }
        public string MaThuongHieu { get; set; }
    
        public virtual DSThuongHieu DSThuongHieu { get; set; }
        public virtual PhanLoai PhanLoai { get; set; }
    }
}
