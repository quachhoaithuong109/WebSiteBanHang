using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    /// <summary>
    /// Viewmodel giỏ hàng
    /// </summary>
    public class ShoppingCartViewModel
    {
        #region Property

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Sản phẩm
        /// </summary>
        public Product Product { set; get; }

        /// <summary>
        /// Số lượng
        /// </summary>
        public int? Quantity { set; get; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        public decimal? Amount { get; set; }


        #endregion

    }
}
