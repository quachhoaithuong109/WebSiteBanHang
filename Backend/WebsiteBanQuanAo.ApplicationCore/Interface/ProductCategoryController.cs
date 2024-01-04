//using NXHOANG.ApplicationCore.Entity;
//using NXHOANG.ApplicationCore.EtensionMethod;
//using NXHOANG.ApplicationCore.Interface.Repository;
//using NXHOANG.ApplicationCore.Interface.Service;
//using NXHOANG.ApplicationCore.Param;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NXHOANG.DoAnTotNghiep.API
//{
//    public class ProductCategoryController : BaseEntitiesController<ProductCategory>
//    {

//        #region Declare

//        /// <summary>
//        /// Service danh mục sản phẩm
//        /// </summary>
//        IProductCategoryService _productCategoryService;

//        IProductCategoryRepository _productCategoryRepository;

//        IProductService _productService;
//        IProductRepository _productRepository;

//        IMenuHeaderRepository _menuHeaderRepository;
//        #endregion


//        #region Constructor 

//        public ProductCategoryController(IMenuHeaderRepository menuHeaderRepository, IProductRepository productRepository, IProductService productService, IProductCategoryService productCategoryService, IProductCategoryRepository productCategoryRepository) //: base(productCategoryService)
//        {
//            _productCategoryService = productCategoryService;
//            _productCategoryRepository = productCategoryRepository;
//            _productService = productService;
//            _productRepository = productRepository;
//            _menuHeaderRepository = menuHeaderRepository;
//        }

//        /// <summary>
//        /// Tìm kiếm kết hợp với phân trang
//        /// </summary>
//        /// <param name="txtSearch">text tìm kiếm</param>
//        /// <param name="pageSize">Số lượng trên 1 trang</param>
//        /// <param name="PageIndex">Trang hiện tại</param>
//        /// <returns></returns>
//        /// NXHOANG 04/08/2022

//        [HttpGet("searchProductCategory")]
//        public object GetProductCategryPaging(string txtSearch, int pageSize, int PageIndex)
//        {
//            return _productCategoryService.GetProductCategryPaging(txtSearch, pageSize, PageIndex).Result;
//        }


//        /// <summary>
//        /// Thêm danh mục sản phẩm
//        /// </summary>
//        /// <param name="product"></param>
//        /// <returns></returns>
//        [HttpPost("AddNewProductCategory")]
//        public IActionResult AddNewProductCategory(ProductCategoryParam productCategory)
//        {
//            // Lấy danh sách danh mục sản phẩm

//            var productCategories = _productCategoryService.GetEntities().Result as List<ProductCategory>;

//            var newProductCategory = new ProductCategory();
//            newProductCategory.ProductCategoryId = Guid.NewGuid();
//            newProductCategory.ProductCategoryName = productCategory.ProductCategoryName;
//            newProductCategory.Alias = productCategory.Alias;
//            newProductCategory.Description = productCategory.Description;
            
//            newProductCategory.ProductCategoryLink = productCategory.ProductCategoryName.RemoveUnicode().ToLower().Replace(@" ","-");
//            //newProductCategory.MenuHeaderId = productCategories.FirstOrDefault().MenuHeaderId;

//            if(!productCategories.Any())
//            {
//                newProductCategory.DisplayOrder = 1;
//            }
//            else
//            {
//                newProductCategory.DisplayOrder = productCategories.Max(x => x.DisplayOrder) + 1;
//            }

//            // Lấy menu Header

//            var menuHeaders = _menuHeaderRepository.GetEntities().Result;
//            var menuHeader = menuHeaders.Where(x => x.IsDropDown == 1).FirstOrDefault();

//            newProductCategory.MenuHeaderId = menuHeader.MenuHeaderId;

//            // Lưu danh mục sản phẩm

//            var rowAffect =  _productCategoryService.AddEntity(newProductCategory).Result;

//            return StatusCode(201, rowAffect);
//        }


//        /// <summary>
//        /// Sửa danh mục sản phẩm
//        /// </summary>
//        /// <param name="productCategory">Danh mục sản phẩm</param>
//        /// <returns></returns>
//        [HttpPut("updateProductCategory")]
//        public IActionResult updateProductCategory(ProductCategoryParam productCategory)
//        {
//            // Lấy danh mục sản phẩm

//            var productCategoryEdit = _productCategoryService.GetEntityById(productCategory.ProductCategoryId).Result;

//            productCategoryEdit.ProductCategoryName = productCategory.ProductCategoryName;
//            productCategoryEdit.Description = productCategory.Description;
//            productCategory.Alias = productCategory.Alias;

//            // Update danh mục sản phẩm

//            var rowAffect = _productCategoryService.UpdateEntity(productCategoryEdit).Result;

//            return Ok(rowAffect);


//        }


//        /// <summary>
//        /// Xóa danh mục sản phẩm
//        /// </summary>
//        /// <param name="product"></param>
//        /// <returns></returns>
//        [HttpDelete("deleteMulti")]
//        public IActionResult DeleteMulti([FromQuery] string listId)
//        {
//            var rowAffects = _productCategoryRepository.DeleteMultipleRecord(listId).Result;


//            if (rowAffects > 0)
//            {
//                // Xóa sản phẩm
//                var stringArray = listId.Split(',');
//                var products = _productService.GetEntities().Result;
//                foreach (var item in stringArray)
//                {
//                    // Lấy danh sách sản phẩm

//                    var productsData = products.Where(x => x.CategoryID == Guid.Parse(item)).ToList();

//                    // Xóa sản phẩm

//                    var listIdTodelete = "";
//                    foreach(var product in productsData)
//                    {
//                        listIdTodelete += product.ProductId + ",";
//                    }

//                    if(listIdTodelete.Length > 0)
//                    {
//                        listIdTodelete = listIdTodelete.Substring(0, listIdTodelete.Length - 1);
//                        rowAffects = _productRepository.DeleteMultipleRecord(listIdTodelete).Result;
//                    }    
//                }    

//            }


//            return Ok(rowAffects);
//        }



//        #endregion
//    }
//}
