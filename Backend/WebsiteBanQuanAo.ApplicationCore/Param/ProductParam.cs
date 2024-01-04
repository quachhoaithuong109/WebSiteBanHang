using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Param
{
    public class ProductParam
    {
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Id danh mục 
        /// </summary>
        public Guid? CategoryID { get; set; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Giá khuyến mãi
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Bảo hành
        /// </summary>
        public int? Warranty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Hình ảnh sản phẩm
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Nội dung sản phẩm
        /// </summary>
        public string Content { get; set; }
    }
}
