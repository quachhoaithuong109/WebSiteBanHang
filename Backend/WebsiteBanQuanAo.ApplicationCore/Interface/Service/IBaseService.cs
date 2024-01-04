using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Service
{
    // <summary>
    /// Interface chứa các phương thức dùng chung
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        Task<IEnumerable<TEntity>> GetEntities();

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id bản ghi cần tìm kiếm</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        //TEntity GetEntityById(string entityId);

        /// <summary>
        /// Thêm một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        Task<ServiceResult> AddEntity(TEntity entity);


        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="lstEntity">Danh sách bản ghi được parse thành json</param>
        /// <returns></returns>
        /// CreatedBy : NXHOANG (23/07/2022)
        Task<ServiceResult> AddMultyEntity(string lstEntity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        Task<ServiceResult> UpdateEntity(TEntity entity);

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>  
        /// <param name="entityId">Id bản ghi cần tìm kiếm</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        ///  CreatedBy : NXHOANG (01/08/2022)
        Task<TEntity> GetEntityById(string entityId);

        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id của bản ghi cần xóa</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        Task<int> DeleteEntity(string entityId);
    }
}
