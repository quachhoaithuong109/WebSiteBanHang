using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class ProductOrderDetailViewModel
    {
        #region Property

        /// <summary>
        /// Id chi tiết đơn hàng
        /// </summary>
        public Guid? ProductOrderDetailId { get; set; }

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public Guid? ProductOrderId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal? ProductPrice { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Giá khuyến mại
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string Image { get; set; }

        #endregion

    }
}
