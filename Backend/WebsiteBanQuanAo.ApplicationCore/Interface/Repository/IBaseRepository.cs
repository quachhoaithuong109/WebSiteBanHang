using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Repository
{
    public interface IBaseRepository<TEntity>
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
        Task<int> AddEntity(TEntity entity);

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="lstEntity">Danh sách bản ghi được parse thành json</param>
        /// <returns></returns>
        Task<int> AddMultyEntity(string lstEntity);

        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số lượng bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        Task<int> UpdateEntity(TEntity entity);

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

        /// <summary>
        /// Lấy bản ghi dựa vào thuộc tính (Property)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">Thông tin thuộc tính</param>
        /// <returns>Trả về 1 bản ghi đầu tiên được tìm thấy</returns>
        /// CreatedBy : NXHOANG (09/07/2022)
        //TEntity GetEntityByProperty(TEntity entity, PropertyInfo property);
    }
}
