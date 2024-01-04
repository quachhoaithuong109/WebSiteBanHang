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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Constructor
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {

        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy sản phẩm theo id
        /// </summary>
        /// <param name="productId">Id sản phẩm</param>
        /// <returns>Sản phẩm được tìm thấy</returns>
        /// NXHOANG
        public virtual async Task<Product> GetProductById(Guid? productId)
        {
            var queryString = $"select * from {_tableName} where {_tableName}Id = @entityId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@entityId", productId);
            var rowReader = await _dbConnection.QueryAsync<Product>(queryString, param: parameters, commandType: System.Data.CommandType.Text);
            return rowReader.FirstOrDefault();
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("listId", listId);
                rowAffects = await _dbConnection.ExecuteAsync("Proc_DeleteMultipleProduct", param: parameters, commandType: CommandType.StoredProcedure);
                transaction.Commit();
                rowAffects = 1;
            }
            return rowAffects;
        }




        #endregion



    }
}
