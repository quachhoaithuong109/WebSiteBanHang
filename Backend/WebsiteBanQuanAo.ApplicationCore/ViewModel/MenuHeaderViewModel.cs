using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class MenuHeaderViewModel
    {
        /// <summary>
        /// Danh sách MenuHeader
        /// </summary>
        public IList<MenuHeader> ListMenuHeader { set; get; }

        /// <summary>
        /// Danh sách MenuCategory
        /// </summary>
        public IList<ProductCategory> ListProductCategory { set; get; }

        /// <summary>
        /// Số lượng sản phẩm trong giỏ hàng
        /// </summary>
        public int? CountCart { get; set; }

    }
}
