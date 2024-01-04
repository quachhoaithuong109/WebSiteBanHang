using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Service
{
    public interface IProductCategoryService : IBaseService<ProductCategory>
    {
        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <returns></returns> 
        Task<ProductCategoryViewModel> getAllProductCategory(Guid? ProductCategoryId,int page, int pageSize);


        /// <summary>
        /// Tìm kiếm kết hợp với phân trang
        /// </summary>
        /// <param name="txtSearch">text tìm kiếm</param>
        /// <param name="pageSize">Số lượng trên 1 trang</param>
        /// <param name="PageIndex">Trang hiện tại</param>
        /// <returns></returns>
        /// NXHOANG 04/08/2022
        Task<object> GetProductCategryPaging(string txtSearch, int pageSize, int PageIndex);


    }
}
