using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    /// <summary>
    /// Đơn hàng
    /// </summary>
    public class ProductOrder : BaseEntity
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
        /// SĐT người dùng
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>   
        /// Tên khách hàng
        /// </summary>
        public string UserName { get; set; }

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


        #endregion

    }
}
