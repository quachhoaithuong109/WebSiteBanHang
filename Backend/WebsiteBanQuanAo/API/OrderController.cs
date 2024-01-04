using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.API
{
    public class OrderController : BaseEntitiesController<ProductOrder>
    {
        #region Declare

        /// <summary>
        /// Service đơn hàng
        /// </summary>
        private readonly IProductOrderService _productOrderService;

        private readonly IProductOrderRepository _productOrderRepository;

        #endregion

        public OrderController(IProductOrderService productOrderService, IProductOrderRepository productOrderRepository) : base(productOrderService)
        {
            _productOrderService = productOrderService;
            _productOrderRepository = productOrderRepository;
        }

        /// <summary>
        /// Lấy thông tin đơn hàng
        /// </summary>
        /// <param name="txtSearch"></param>
        /// <param name="pageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        [HttpGet("searchPaging")]
        public object GetOrderPaging(string txtSearch, int pageSize, int pageIndex)
        {
            return _productOrderService.GetProductOrderPaging(txtSearch, pageSize, pageIndex).Result;
        }


        /// <summary>
        /// Lấy chi tiết đơn hàng
        /// </summary>
        /// <param name="productOrderId">Id đơn hàng</param>
        /// <returns></returns>
        [HttpGet("GetProductOrderDetail/{productOrderId}")] 
        public object GetProductOrderDetail(string productOrderId)
        {
            return _productOrderService.GetProductOrderDetail(productOrderId).Result;
        }




    }
}
