using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Enum;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.Param;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.API
{
    public class ProductController : BaseEntitiesController<Product>
    {

        #region Declare

        /// <summary>
        /// Service sản phẩm
        /// </summary>
        IProductService _productService;

        IProductCategoryService _productCategoryService;

        IProductRepository _productRepository;

        private readonly IHostingEnvironment _hostingEnvironment;

        #endregion

        #region Constructor

        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IHostingEnvironment hostingEnvironment, IProductRepository productRepository) : base(productService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _hostingEnvironment = hostingEnvironment;
            _productRepository = productRepository;
        }

        #endregion


        #region Method

        [HttpGet("getProduct")]
        public IActionResult GetProductApi()
        {
            var products = _productService.GetApiProducts().Result;

            return Ok(products);
        }


        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("AddNewProduct")]
        public IActionResult AddNewProduct()//[FromBody]Product product
        {
            string sPath = "";

            // Lấy thông tin sản phẩm

            var productJson = HttpContext.Request.Form["product"];

            var product = JsonConvert.DeserializeObject<Product>(productJson);

            // Lấy thông tin danh mục sản phẩm

            var productCategories = _productCategoryService.GetEntities().Result;

            var productCategory = productCategories.Where(x => x.ProductCategoryId == product.CategoryID).FirstOrDefault();

            if (productCategory.DisplayOrder == (int)TypeProduct.furniture)
            {
                sPath = "Images/ImageProduct/BanGhe";
            }
            else if (productCategory.DisplayOrder == (int)TypeProduct.Cabinet)
            {
                sPath = "Images/ImageProduct/Tu";
            }
            else if (productCategory.DisplayOrder == (int)TypeProduct.Bed)
            {
                sPath = "Images/ImageProduct/Giuong";
            }
            else
            {
                sPath = "Images/ImageProduct";
            }

            string imageName = null;

            //Đọc file 
            IFormFile fileImage = HttpContext.Request.Form.Files["formFile"];


            //create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(fileImage.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileImage.FileName);

            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, sPath);

            string filePath = Path.Combine(uploadsFolder, imageName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileImage.CopyTo(fileStream);
            }

            // thực hiện insert sản phẩm

            product.ProductId = Guid.NewGuid();
            product.Image = imageName;
            product.TypeProduct = productCategory.DisplayOrder;
            var serviceresult = _productService.AddEntity(product);

            return StatusCode(201, serviceresult);
        }



        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct()
        {
            string sPath = "";

            // Lấy thông tin sản phẩm

            var productJson = HttpContext.Request.Form["product"];

            var product = JsonConvert.DeserializeObject<Product>(productJson);

            // Lấy ra sản phẩm theo Id
            var productData = _productService.GetEntityById(product.ProductId.ToString()).Result;

            // Lấy thông tin danh mục sản phẩm

            var productCategories = _productCategoryService.GetEntities().Result;

            var productCategory = productCategories.Where(x => x.ProductCategoryId == product.CategoryID).FirstOrDefault();

            // Lấy image

            string imageName = null;

            //Đọc file mới nhất
            IFormFile fileImage = HttpContext.Request.Form.Files["formFile"];

            if (fileImage != null)
            {
                if (product.Image != fileImage.FileName)
                {
                    // Thay đổi lại đường dẫn

                    if (productCategory.DisplayOrder == (int)TypeProduct.furniture)
                    {
                        sPath = "Images/ImageProduct/BanGhe";
                    }
                    else if (productCategory.DisplayOrder == (int)TypeProduct.Cabinet)
                    {
                        sPath = "Images/ImageProduct/Tu";
                    }
                    else if (productCategory.DisplayOrder == (int)TypeProduct.Bed)
                    {
                        sPath = "Images/ImageProduct/Giuong";
                    }
                    else
                    {
                        sPath = "Images/ImageProduct";
                    }

                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, sPath);

                    //Xóa bỏ image cũ
                    string filePath = Path.Combine(uploadsFolder, product.Image);

                    FileInfo file = new FileInfo(filePath);

                    if (file.Exists)
                    {
                        file.Delete();
                    }
                        
                    // Bổ sung image mới

                    //create custom filename
                    imageName = new String(Path.GetFileNameWithoutExtension(fileImage.FileName).Take(10).ToArray()).Replace(" ", "-");
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileImage.FileName);

                    uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, sPath);

                    filePath = Path.Combine(uploadsFolder, imageName);

                    // bổ sung thêm file mới
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        fileImage.CopyTo(fileStream);
                    }
                }
            }

            // Update lại thông tin sản phẩm

            if(imageName != null)
            {
                product.Image = imageName;
            }
            
            product.TypeProduct = productCategory.DisplayOrder;
            var serviceresult = _productService.UpdateEntity(product);
                

            return StatusCode(201, 1);

        }


        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpDelete("deleteMulti")]
        public IActionResult DeleteMulti([FromQuery]string listId)
        {
            var rowAffects = _productRepository.DeleteMultipleRecord(listId).Result;
            return Ok(rowAffects);
        }

        /// <summary>
        /// Tìm kiếm kết hợp với phân trang
        /// </summary>
        /// <param name="txtSearch">text tìm kiếm</param>
        /// <param name="pageSize">Số lượng trên 1 trang</param>
        /// <param name="PageIndex">Trang hiện tại</param>
        /// <returns></returns>
        /// NXHOANG 04/08/2022

        [HttpGet("searchPaging")]
        public object GetProductPaging(string txtSearch, int pageSize, int PageIndex)
        {
            return  _productService.GetProductPaging(txtSearch, pageSize, PageIndex).Result;
        }




        /// <summary>
        /// Sửa sản phẩm
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        //public override IActionResult Put([FromRoute] string id, [FromBody] Product product)
        //{

        //    // Lấy ra sản phẩm theo Id
        //    var productData = _productService.GetEntityById(id).Result;

        //    // Lấy ra danh sách danh mục sản phẩm
        //    var productCategories = _productCategoryService.GetEntities().Result;

        //    var productCategory = productCategories.Where(x => x.ProductCategoryId == product.CategoryID).FirstOrDefault();

        //    var imageBefore = productData.Image;

        //    if (product.Image != imageBefore)
        //    {
        //        // Thay đổi lại đường dẫn
        //    }

        //    // Update lại thông tin 

        //    product.ProductId = Guid.Parse(id);
        //    product.TypeProduct = productCategory.DisplayOrder;

        //    var serviceResult = _productService.UpdateEntity(product);

        //    return Ok(serviceResult);
        //}




        #endregion

    }
}
