using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.API
{
    public class UserController : BaseEntitiesController<User>
    {

        #region Declare

        /// <summary>
        /// Service sản phẩm
        /// </summary>
        private readonly IUserService _userService;

        #endregion

        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Tìm kiếm kết hợp với phân trang
        /// </summary>
        /// <param name="txtSearch">text tìm kiếm</param>
        /// <param name="pageSize">Số lượng trên 1 trang</param>
        /// <param name="PageIndex">Trang hiện tại</param>
        /// <returns></returns>

        [HttpGet("searchPaging")]
        public object GetUserPaging(string txtSearch, int pageSize, int PageIndex)
        {
            return _userService.GetProductPaging(txtSearch, pageSize, PageIndex).Result;
        }

    }
}
