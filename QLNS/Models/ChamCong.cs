using System;
using System.ComponentModel.DataAnnotations;
namespace QLNS.Models
{
    public class ChamCong
    {
        [Key]
        public int MaCC { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayChamCong { get; set; }
        public int SoGioLamViec { get; set; }

    }

}
