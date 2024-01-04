using NXHOANG.ApplicationCore.Common;
using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        #region Declare
        private readonly IMenuHeaderService _menuHeaderService;
        private readonly IProductCategoryService _productCategoryService;
        #endregion

        #region Constructor
        public HeaderViewComponent(IMenuHeaderService menuHeaderService, IProductCategoryService productCategoryService)
        {
            _menuHeaderService = menuHeaderService;
            _productCategoryService = productCategoryService;
        }
        #endregion

        public IViewComponentResult Invoke()
        {

            MenuHeaderViewModel menuHeader = new MenuHeaderViewModel();

            var menuHeaders = _menuHeaderService.GetEntities().Result as List<MenuHeader>;

            var productCategory = _productCategoryService.GetEntities().Result as List<ProductCategory>;

            menuHeader.ListMenuHeader = menuHeaders;
            menuHeader.ListProductCategory = productCategory;

            var cartJson = HttpContext.Session.GetString(CommonConstant.SessionCart);

            var cartParseJson = new List<ShoppingCartViewModel>();

            if (cartJson != null)
            {
                cartParseJson = JsonConvert.DeserializeObject<List<ShoppingCartViewModel>>(cartJson);
            }

            menuHeader.CountCart = cartParseJson.Sum(x => x.Quantity);

            // Truyền session vào viewBag

            var userJson = HttpContext.Session.GetString(CommonConstant.UserLogin);

            var isLogin = false;

            if (userJson != null)
            {
                var userLogin = JsonConvert.DeserializeObject<User>(userJson);
                ViewBag.userLogin = userLogin;
                isLogin = true;
            }

            ViewBag.isLogin = isLogin;

            return View(menuHeader);
        }
    }
}
