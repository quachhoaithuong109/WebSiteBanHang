using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Service
{
    public class ProductOrderService : BaseService<ProductOrder>, IProductOrderService
    {

        #region Declare
        private readonly IProductOrderRepository _productOrderRepository;
        private readonly IProductOrderDetailRepository _productOrderDetailRepository;

        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;


        #endregion

        #region Constructor

        public ProductOrderService(IProductRepository productRepository, IUserRepository userRepository, IProductOrderRepository productOrderRepository, IProductOrderDetailRepository productOrderDetailRepository) : base(productOrderRepository)
        {
            _productOrderRepository = productOrderRepository;
            _productOrderDetailRepository = productOrderDetailRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region Method

        /// <summary>
        /// Tạo đơn hàng khi người dùng xác nhận
        /// </summary>
        /// <param name="productOrder">Thông tin đơn hàng</param>
        /// <param name="productOrderDetails">Thông tin chi tiết đơn hàng</param>
        /// <returns></returns>
        /// NXHOANG
        public async Task<int> CreateOrderProduct(ProductOrder productOrder, List<ProductOrderDetail> productOrderDetails)
        {

            // Lấy danh sách sản phẩm
            var products = await _productRepository.GetEntities();

            // insert thông tin đơn hàng

            var rowAffects = await _productOrderRepository.AddEntity(productOrder);

            if (rowAffects > 0)
            {
                // insert thông tin chi tiết đơn hàng

                var productOrderDetailParam = JsonConvert.SerializeObject(productOrderDetails);

                rowAffects = await _productOrderDetailRepository.AddMultyEntity(productOrderDetailParam);

                // Thực hiện update lại số lượng sản phẩm trong database

                foreach(var item in productOrderDetails)
                {
                    var product = products.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                    product.Quantity = product.Quantity - item.Quantity;
                    rowAffects = await _productRepository.UpdateEntity(product);
                }    
            }

            return rowAffects;
        }


        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="pageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public async Task<object> GetProductOrderPaging(string txtSearch, int pageSize, int pageIndex)
        {

            ////Tính lại pageIndex
            //pageIndex = (pageIndex - 1) * pageSize;

            //var searchText = txtSearch != null ? txtSearch : string.Empty;

            // Lấy danh sách đơn hành

            var productOrders = await _productOrderRepository.GetEntities();

            // Lấy danh sách người dùng

            var users = await _userRepository.GetEntities();

            // Lấy thông tin đơn hàng chi tiết
            var productOrderDetail = await _productOrderDetailRepository.GetEntities();

            var productOrderParams = new List<ProductOrderPapram>();
            var productOrderView = new List<ProductOrderPapram>();

            foreach (var item in productOrders)
            {
                var productOrderPapram = new ProductOrderPapram();

                productOrderPapram.ProductOrderId = item.ProductOrderId;
                productOrderPapram.UserName = item.UserName;
                productOrderPapram.UserPhone = item.UserPhone;
                productOrderPapram.UserAddress = item.UserAddress;
                productOrderPapram.OrderDate = item.CreatedDate;

                var productOrderDetailData = productOrderDetail.Where(x => x.ProductOrderId == item.ProductOrderId).ToList();
                productOrderPapram.TotalPrice = productOrderDetailData.Sum(x => (x.ProductPrice * x.Quantity));

                productOrderParams.Add(productOrderPapram);
            }

            //if (searchText != null && searchText != string.Empty)
            //{
            //    productOrderView = productOrderParams.Where(x => x.ProductName.Contains(txtSearch)).ToList();
            //}
            //else
            //{
            //    productOrderView = productOrderParams;
            //}

            productOrderView = productOrderParams.Skip(pageIndex - 1).Take(pageSize).OrderBy(x => x.OrderDate).ToList();

            return new
            {
                Data = productOrderView,
                TotalRecord = productOrderParams.Count(),
                TotalPage = (int)Math.Ceiling((double)productOrderParams.Count() / pageSize)
            };
        }


        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="productOrderId">Id đơn hàng</param>
        /// <returns></returns>
        public async Task<object> GetProductOrderDetail(string productOrderId)
        {
            // Lấy thông tin đơn hàng chi tiết
            var productOrderDetails = await _productOrderDetailRepository.GetEntities();

            var productOrderDetailData = productOrderDetails.Where(x => x.ProductOrderId == Guid.Parse(productOrderId)).ToList();

            return productOrderDetailData;

        }

        #endregion
    }
}
