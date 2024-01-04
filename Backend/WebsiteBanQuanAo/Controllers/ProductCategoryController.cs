using NXHOANG.ApplicationCore.Common;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.Controllers
{
    public class ProductCategoryController : Controller
    {

        #region Declare
        private readonly IProductCategoryService _productCategoryService;
        #endregion

        #region Constructor
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        #endregion
        /// <summary>
        /// View Danh Mục Sản Phẩm
        /// </summary>
        /// <param name="ProductCategoryId">Id danh mục</param>
        /// <param name="page">Trang hiện tại</param>
        /// <returns></returns>
        /// NXHOANG
        public IActionResult Index(Guid? ProductCategoryId, int page = 1)
        {
            int pageSize = ConfigHelper.pageSize;

            var productCategoryViewModel = _productCategoryService.getAllProductCategory(ProductCategoryId, page, pageSize).Result;

            int totalPage = (int)Math.Ceiling((double)productCategoryViewModel.TotalProducts / pageSize);

            var paginationSet = new PaginationSet
            {
                Item = productCategoryViewModel,
                MaxPage = ConfigHelper.MaxPage,
                Page = page,
                TotalCount = productCategoryViewModel.TotalProducts,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }

        


    }
}
