using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class HomeViewModel
    {
        /// <summary>
        /// Bàn Ghế thoại mới nhất
        /// </summary>
        public IList<Product> TableLatests { set; get; }

        /// <summary>
        /// List Tủ mới nhất
        /// </summary>
        public IList<Product> CabinetLatests { set; get; }

        /// <summary>
        /// Giường mới nhất
        /// </summary>
        public IList<Product> BedLatests { set; get; }


    }
}
