using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Enum
{

    /// <summary>
    /// Misa code để xác định trạng thái của việc validate
    /// </summary>
    public enum NXHOANGEnum
    {
        /// <summary>
        /// Dữ liệu hợp lệ
        /// </summary>
        IsValid = 100,
        /// <summary>
        /// Dự liệu không hợp lệ
        /// </summary>
        NotValid = 900,
        /// <summary>
        /// Thành công
        /// </summary>
        Success = 200,
        /// <summary>
        /// Exception   
        /// </summary>
        Exception = 500
    }


    /// <summary>
    /// Xác định trạng thái của Object
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        AddNew = 1,
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        Update = 2,
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        Delete = 3

    }

    /// <summary>
    /// Loại sản phẩm
    /// </summary>
    public enum TypeProduct
    {
        /// <summary>
        /// Bàn Ghế
        /// </summary>
        furniture = 1,

        /// <summary>
        /// Tủ
        /// </summary>
        Cabinet = 2,

        /// <summary>
        /// Giường
        /// </summary>
        Bed = 3


    }

    /// <summary>
    /// Phân quyền người dùng
    /// 1. admin
    /// 2. User 
    /// </summary>
    public enum UserRole
    {
        Admin = 1,
        User = 2
    }

}
