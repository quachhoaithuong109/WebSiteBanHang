using NXHOANG.ApplicationCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    /// <summary>
    /// Kết quả thông báo trả về chuẩn Resfull API
    /// </summary>
    public class ServiceResult
    {
        #region Property
        /// <summary>
        /// dữ liệu trả về trả về cho client sử dụng
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Thông tin mô tả dữ liệu trả về
        /// </summary>  
        public string Messeger { get; set; }

        /// <summary>
        /// Mã code biểu diễn thông tin trả về
        /// </summary>
        public NXHOANGEnum NXHOANGCode { get; set; }
        #endregion
    }
}
