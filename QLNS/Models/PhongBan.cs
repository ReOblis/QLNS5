using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Models
{
    public class PhongBan
    {
        [Key]
        public string MaPB { get; set; }
        public string TenPB { get; set; }
        public string DiaChi { get; set; }
        
    }
}
