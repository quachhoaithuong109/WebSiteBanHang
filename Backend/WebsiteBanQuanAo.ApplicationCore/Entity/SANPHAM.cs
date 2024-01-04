using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity // em muốn đổi tên này này 
{
    public class SANPHAM
    {
        public int? ID { get; set; }
        public string MaSP { get; set; } //MASP là tên các trường tương ứng với bảng trong sql
        public string TenSP { get; set; } //nvarchar thì để string int thì để int
        public int? LoaiSP{ get; set; }
    }
}
