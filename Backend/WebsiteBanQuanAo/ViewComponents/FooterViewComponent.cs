using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        #region Declare
        private readonly IFooterProductService _footerProductService;
        #endregion

        #region Constructor
        public FooterViewComponent(IFooterProductService footerProductService)
        {
            _footerProductService = footerProductService;
        }
        #endregion

        public IViewComponentResult Invoke()
        {

            FooterViewModel footerViewModel = new FooterViewModel();

            footerViewModel = _footerProductService.GetFooterProducts().Result;

            return View(footerViewModel);
        }
    }
}
