using NXHOANG.ApplicationCore.Common;
using NXHOANG.ApplicationCore.DTO;
using NXHOANG.ApplicationCore.Interface.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.Controllers
{
    public class AccountController : Controller
    {

        #region method

        private readonly IUserService _userService;

        #endregion

        #region Constructor

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        /// <summary>
        /// Thực hiện login
        /// </summary>
        /// <param name="UserEmail">Email người dùng</param>
        /// <param name="UserPassWord">PassWord người dùng</param>
        /// <returns></returns>
        /// NXHOANG 24/07/2022
        [HttpPost]
        public JsonResult Login(string UserEmail, string UserPassWord)
        {
            // check login

            var isCheckLogin = _userService.checkLoginUser(UserEmail, UserPassWord).Result;

            if(isCheckLogin)
            {
                var userLogin = _userService.GetUserByNameAndPass(UserEmail, UserPassWord).Result;

                // Lưu thông tin user vào Session

                string jsonUserLogin = JsonConvert.SerializeObject(userLogin);
                HttpContext.Session.SetString(CommonConstant.UserLogin, jsonUserLogin);

                return Json(new
                {
                    status = true
                });
            }

            return Json(new
            {
                status = false
            });
        }



        /// <summary>
        /// Đăng ký tài khoản
        /// </summary>
        /// <param name="UserName">Tên người dùng</param>
        /// <param name="UserEmail">Email</param>
        /// <param name="PassWord"></param>
        /// <param name="UserPhone"></param>
        /// <param name="Address"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult Register(string UserName, string UserEmail,string PassWord,string UserPhone,string Address)
        {
            var isRegister =  _userService.Register(UserName, UserEmail, PassWord, UserPhone, Address).Result;

            if(isRegister)
            {
                return Json(new
                {
                    status = true
                });
            }    

            return Json(new
            {
                status = false
            });
        }

        /// <summary>
        /// Thực hiện đăng xuất
        /// </summary>
        /// <returns></returns>
        /// NXHOANG 24/07/2022
        [HttpPost]
        public JsonResult Logout()
        {
            // gán lại session
            HttpContext.Session.Remove(CommonConstant.UserLogin);
            return Json(new
            {
                status = true
            });
        }


    }
}
