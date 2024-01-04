using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Service
{
    public class ProductCategoryService : BaseService<ProductCategory>,IProductCategoryService
    {

        #region Declare
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        #endregion

        #region Constructor
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository) : base(productCategoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <returns></returns>
        /// NXHOANG 17/07/2022
        public async Task<ProductCategoryViewModel> getAllProductCategory(Guid? ProductCategoryId, int page, int pageSize)
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();

            //Lấy danh sách sản phẩm
            var productData = await _productRepository.GetEntities() as List<Product>;

            productData = productData.Where(x => x.CategoryID == ProductCategoryId).ToList();

            // Lấy danh mục
            var productCategoryData = await _productCategoryRepository.GetEntities() as List<ProductCategory>;

            var productGetByPages = productData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            if (productCategoryData.Count > 0)
            {
                productCategoryData = productCategoryData.OrderBy(x => x.DisplayOrder).ToList();
            }    

            productCategoryViewModel.products = productGetByPages;
            productCategoryViewModel.productCategories = productCategoryData;
            productCategoryViewModel.TotalProducts = productData.Count;
            productCategoryViewModel.productCategoryActive = productCategoryData.Where(x => x.ProductCategoryId == ProductCategoryId).FirstOrDefault();

            return productCategoryViewModel;

        }


        /// <summary>
        /// Tìm kiếm kết hợp với phân trang
        /// </summary>
        /// <param name="txtSearch">text tìm kiếm</param>
        /// <param name="pageSize">Số lượng trên 1 trang</param>
        /// <param name="PageIndex">Trang hiện tại</param>
        /// <returns></returns>
        /// NXHOANG 04/08/2022
        public async Task<object> GetProductCategryPaging(string txtSearch, int pageSize, int pageIndex)
        {
            //Tính lại pageIndex
            pageIndex = (pageIndex - 1) * pageSize;

            var searchText = txtSearch != null ? txtSearch : string.Empty;

            // Lấy danh sách người dùng
            var productCategories = await _productCategoryRepository.GetEntities() as List<ProductCategory>;

            // Tìm kiếm

            var productCategoryData = new List<ProductCategory>();

            if (searchText != null && searchText != string.Empty)
            {
                productCategoryData = productCategories.Where(x => x.ProductCategoryName.Contains(txtSearch)).ToList();
            }   
            else
            {
                productCategoryData = productCategories;
            }

            // phân trang
            productCategoryData = productCategoryData.Skip(pageIndex).Take(pageSize).OrderBy(x => x.CreatedDate).ToList();

            return new
            {
                Data = productCategoryData,
                TotalRecord = productCategories.Count(),
                TotalPage = (int)Math.Ceiling((double)productCategories.Count() / pageSize)
            };
        }





        #endregion
    }
}
