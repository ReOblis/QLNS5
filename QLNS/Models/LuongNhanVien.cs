using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Models
{
    public class LuongNhanVien
    {
        [Key]
        public string MaLuong { get;set; }
        public string MaNV { get;set; }
        public double LCBan { get;set;}
    }
}
