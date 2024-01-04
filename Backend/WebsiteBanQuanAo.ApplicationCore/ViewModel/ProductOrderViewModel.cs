using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class ProductOrderViewModel
    {
        #region Property

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public Guid? ProductOrderId { get; set; }

        /// <summary>
        /// Id khách hàng
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SĐT người dùng
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Lời nhắn từ người dùng
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Tình trạng đơn hàng
        /// 1. Chưa giao
        /// 2. Đã giao
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 1. Người dùng nhập thông tin
        /// 2. Người dùng đăng nhập
        /// </summary>
        public int? CheckOrder { get; set; }

        /// <summary>
        /// Danh sách sản phẩm chi tiết
        /// </summary>
        public IEnumerable<ProductOrderDetailViewModel> productOrderDetails { set; get; }

        #endregion

    }



    public class ProductOrderPapram
    {
        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public Guid? ProductOrderId { get; set; }

        /// <summary>
        /// Tên khách hàng
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SĐT người dùng
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// Địa chỉ khách hàng
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// Ngày đặt
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        public decimal? TotalPrice { get; set; }

        // <summary>
        /// Tình trạng đơn hàng
        /// 1. Chưa giao
        /// 2. Đã giao
        /// </summary>
        public int? Status { get; set; }

    }

}
