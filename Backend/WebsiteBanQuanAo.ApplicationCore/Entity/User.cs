using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{

    public class User : BaseEntity
    {
        /// <summary>
        /// Id người dùng
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// Điện thoại người dùng
        /// </summary>
        public string UserPhone { get; set; }

        /// <summary>
        /// Địa chỉ người dùng
        /// </summary>

        public string Address { get; set; }

        /// <summary>
        /// Phân quyền người dùng
        /// 1. admin
        /// 2. User 
        /// </summary>
        public int? UserRole { get; set; }

    }
}
