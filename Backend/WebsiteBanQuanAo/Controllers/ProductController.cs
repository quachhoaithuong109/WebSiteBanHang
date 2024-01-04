using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.Controllers
{
    public class ProductController : Controller
    {
        #region Declare

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        public IActionResult Detail(Guid? ProductId)
        {
            ProductDetailViewModel productDetailViewModel = new ProductDetailViewModel();

            var product = _productService.GetEntities().Result;

            var productDetail = product.Where(x => x.ProductId == ProductId).FirstOrDefault();

            productDetailViewModel.Product = productDetail;

            productDetailViewModel.ProductRelates = product.Where(x => x.CategoryID == productDetail.CategoryID).ToList();

            return View(productDetailViewModel);
        }
    }
}
