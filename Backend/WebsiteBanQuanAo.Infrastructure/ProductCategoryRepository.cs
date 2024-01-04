using Dapper;
using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.Infrastructure
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        #region Constructor
        public ProductCategoryRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Xóa nhiều sản phẩm
        /// </summary>
        /// <param name="listId">danh sách id sản phẩm</param>
        /// <returns></returns>
        public async Task<int> DeleteMultipleRecord(string listId)
        {
            var rowAffects = 0;
            using (var transaction = _dbConnection.BeginTransaction())
            {
                // Xóa sản phẩm thuộc danh mục đó


                // Xóa danh mục sản phẩm
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("listId", listId);
                rowAffects = await _dbConnection.ExecuteAsync("Proc_DeleteMultipleProductCategory", param: parameters, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                rowAffects = 1;
            }
            return rowAffects;
        }


        #endregion
    }
}
