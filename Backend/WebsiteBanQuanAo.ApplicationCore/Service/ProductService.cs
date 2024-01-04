using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Enum;
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
    public class ProductService : BaseService<Product>, IProductService
    {
        #region Declare
        /// <summary>
        /// Service Product
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Service Product
        /// </summary>
        private readonly IProductCategoryRepository _productCategoryRepository;

        #endregion

        #region Constructor
        public ProductService(IProductRepository customerRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository) : base(customerRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách sản phẩm lên cho phần trang chủ
        /// </summary>
        /// <returns></returns>
        /// NXHOANG 17/07/2022
        public async Task<HomeViewModel> GetProducts()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            var products = await _productRepository.GetEntities() as List<Product>;

            // Lấy ra Bàn Ghế mới nhất
            var TableLatests = products.Where(x => x.TypeProduct == (int)TypeProduct.furniture).ToList();
            if (TableLatests.Count >= 4)
            {
                TableLatests = TableLatests.OrderBy(x => x.CreatedDate).Skip(0).Take(4).ToList();
            }
            else
            {
                TableLatests = TableLatests.OrderBy(x => x.CreatedDate).ToList();
            }

            // Lấy ra Tủ mơi nhất

            var CabinetLatests = products.Where(x => x.TypeProduct == (int)TypeProduct.Cabinet).ToList();
            if (CabinetLatests.Count >= 4)
            {
                CabinetLatests = CabinetLatests.OrderBy(x => x.CreatedDate).Skip(0).Take(4).ToList();
            }
            else
            {
                CabinetLatests = CabinetLatests.OrderBy(x => x.CreatedDate).ToList();
            }

            // Lấy ra Giường mới nhất

            var BedLatests = products.Where(x => x.TypeProduct == (int)TypeProduct.Bed).ToList();
            if (BedLatests.Count >= 4)
            {
                BedLatests = BedLatests.OrderBy(x => x.CreatedDate).Skip(0).Take(4).ToList();
            }
            else
            {
                BedLatests = BedLatests.OrderBy(x => x.CreatedDate).ToList();
            }

            homeViewModel.TableLatests = TableLatests;
            homeViewModel.CabinetLatests = CabinetLatests;
            homeViewModel.BedLatests = BedLatests;

            return homeViewModel;
        }



        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <returns></returns>
        /// NXHOANG 17/07/2022
        public async Task<ProductCategoryViewModel> getAllProductSearch(string keySearch, int page, int pageSize)
        {
            ProductCategoryViewModel productCategoryViewModel = new ProductCategoryViewModel();

            //Lấy danh sách sản phẩm
            var productData = await _productRepository.GetEntities() as List<Product>;

            productData = productData.Where(x => x.ProductName.ToLower().StartsWith(keySearch.ToLower())).ToList();

            var productGetByPages = productData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            productCategoryViewModel.products = productGetByPages;
            productCategoryViewModel.TotalProducts = productData.Count;
        
            return productCategoryViewModel;

        }

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="productId">Id sản phẩm</param>
        /// <returns>Sản phẩm được tìm thấy</returns>
        /// NXHOANG
        public async Task<Product> GetProductById(Guid? productId)
        {
            var product = await _productRepository.GetProductById(productId);

            return product;
        }

        /// <summary>
        /// Kiểm tra xem sản phẩm đã hết hàng hay chưa
        /// </summary>
        /// <param name="ProductId">Id sản phẩm</param>
        /// <param name="Quantity">Số lượng sản phẩm</param>
        /// <returns>
        /// True : Sản phẩm vẫn còn
        /// False : Sản phẩm đã hết hàng
        /// </returns>
        /// NXHOANG 23/07/2022
        public async Task<bool> SellProduct(Guid? ProductId, int? Quantity)
        {
            var product = await _productRepository.GetProductById(ProductId);
            if (product.Quantity < Quantity)
            {
                return false;
            }
            product.Quantity -= Quantity;

            //Update lại số lượng sản phẩm

            var _ = await _productRepository.UpdateEntity(product);

            return true;
        }


        /// <summary>
        /// Lấy danh sách sản phẩm lên cho api
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetApiProducts()
        {
            // Lấy danh sách produts
            var products = await _productRepository.GetEntities();

            // lấy danh sách danh mục sản phẩm

            var productCategories = await _productCategoryRepository.GetEntities();


            var productData = products.Join(productCategories, x => new { CategoryID = x.CategoryID }, y => new { CategoryID = (Guid)y.ProductCategoryId }, (x, y) =>
            {
                return new {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Alias = x.Alias,
                    CategoryID = x.CategoryID,
                    CategoryName = y.ProductCategoryName,
                    TypeProduct = x.TypeProduct,
                    Image = x.Image,
                    MoreImages = x.MoreImages,
                    Price = x.Price,
                    PromotionPrice = x.PromotionPrice,
                    Warranty = x.Warranty,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    Content = x.Content,
                };

            }).ToList();

            return productData;
        }


        /// <summary>
        /// Tìm kiếm kết hợp với phân trang
        /// </summary>
        /// <param name="txtSearch">text tìm kiếm</param>
        /// <param name="pageSize">Số lượng trên 1 trang</param>
        /// <param name="PageIndex">Trang hiện tại</param>
        /// <returns></returns>

        public async Task<object> GetProductPaging(string txtSearch, int pageSize, int pageIndex)
        {
            //Tính lại pageIndex
            pageIndex = (pageIndex - 1) * pageSize;

            var searchText = txtSearch != null ? txtSearch : string.Empty;

            // Lấy danh sách sản phẩm
            var products = _productRepository.GetEntities().Result.OrderBy(x => x.CreatedDate).ToList();

            // Tìm kiếm

            var productData = new List<Product>();

            if(searchText != null && searchText != string.Empty)
            {
                productData = products.Where(x => x.ProductName.Contains(txtSearch)).ToList();
            }
            else
            {
                productData = products;
            }

            // phân trang

            //productData = productData.Skip(pageIndex).Take(pageSize).OrderBy(x => x.CreatedDate).ToList();

            // lấy danh sách danh mục sản phẩm

            var productCategories = await _productCategoryRepository.GetEntities();


            var productDatas= productData.Join(productCategories, x => new { CategoryID = x.CategoryID }, y => new { CategoryID = (Guid)y.ProductCategoryId }, (x, y) =>
            {
                return new
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Alias = x.Alias,
                    CategoryID = x.CategoryID,
                    CategoryName = y.ProductCategoryName,
                    TypeProduct = x.TypeProduct,
                    Image = x.Image,
                    MoreImages = x.MoreImages,
                    Price = x.Price,
                    PromotionPrice = x.PromotionPrice,
                    Warranty = x.Warranty,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    Content = x.Content,
                    CreatedDate = x.CreatedDate
                };

            }).ToList();


            productDatas = productDatas.Skip(pageIndex).Take(pageSize).OrderBy(x => x.CreatedDate).ToList();

            return new
            {
                Data = productDatas,
                TotalRecord = products.Count(),
                TotalPage = (int)Math.Ceiling((double)products.Count() / pageSize)
            };
        }

        #endregion

    }
}
