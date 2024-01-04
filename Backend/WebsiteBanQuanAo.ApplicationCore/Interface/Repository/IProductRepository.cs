using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Repository
{
    /// <summary>
    /// Interface sản phẩm
    /// </summary>
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="productId">Id sản phẩm</param>
        /// <returns>Sản phẩm được tìm thấy</returns>
        /// NXHOANG
        Task<Product> GetProductById(Guid? productId);


        /// <summary>
        /// Xóa nhiều sản phẩm
        /// </summary>
        /// <param name="listId">danh sách id sản phẩm</param>
        /// <returns></returns>
        Task<int> DeleteMultipleRecord(string listId);

    }
}
