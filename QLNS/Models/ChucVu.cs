using System;
using System.ComponentModel.DataAnnotations;

namespace QLNS.Models
{
    public class ChucVu
    {
        [Key]
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
    }
}
