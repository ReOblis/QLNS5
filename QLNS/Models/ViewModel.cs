using QLNS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

namespace QLNS.Models
{
    public class ViewModel
    {

        public IEnumerable<NhanVien> NhanVien { get; set; }
        public IEnumerable<ChamCong> ChamCong { get; set; }

    }
}
