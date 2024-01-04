using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Service
{
    public interface IProductOrderService : IBaseService<ProductOrder>
    {

        /// <summary>
        /// Method xử lý lưu thông tin đơn hàng
        /// </summary>
        /// <param name="productOrder">Đơn hàng</param>
        /// <param name="productOrderDetails">Chi tiết đơn hàng</param>
        /// <returns></returns>
        /// NXHOANG 23/07/2022
        Task<int> CreateOrderProduct(ProductOrder productOrder, List<ProductOrderDetail> productOrderDetails);


        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="pageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        Task<object> GetProductOrderPaging(string txtSearch, int pageSize, int PageIndex);

        /// <summary>
        /// Id đơn hàng
        /// </summary>
        /// <param name="productOrderId">id đơn hàng</param>
        /// <returns></returns>
        Task<object> GetProductOrderDetail(string productOrderId);

    }
}
