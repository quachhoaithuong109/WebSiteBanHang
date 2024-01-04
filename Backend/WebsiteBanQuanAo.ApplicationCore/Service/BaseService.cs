using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Enum;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Service
{
    /// <summary>
    /// Service thực hiện các nghiệp vụ dùng chung.
    /// </summary>
    /// <typeparam name="TEntity">Class truyền vào bắt buộc phải kế thừa từ class BaseEntity</typeparam>
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        #region Declare

        /// <summary>
        /// Repository của phần base thực việc kết nối dữ liệu xuống database phục vụ cho việc xử lý các yêu cầu dùng chung
        /// </summary>
        protected IBaseRepository<TEntity> _baseRepository;

        /// <summary>
        /// Dùng để check xem mã code có bị trùng hay không
        /// </summary>
        protected bool isCheckDuplicateCode;

        /// <summary>
        /// Kết quả thống báo trả về chuẩn Resfull API
        /// </summary>
        protected ServiceResult _serviceResult;

        #endregion

        #region Constructor

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { NXHOANGCode = NXHOANGEnum.Success };
        }
        #endregion

        #region Method

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm</param>
        /// <returns>Trả về thông báo kết quả sau khi thêm mới</returns>
        /// CreatedBy : NXHOANG(9/11/2021)
        public virtual async Task<ServiceResult> AddEntity(TEntity entity)
        {

            _serviceResult.Data = await _baseRepository.AddEntity(entity);
            return _serviceResult;

        }

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="lstEntity">Danh sách bản ghi được parse thành json</param>
        /// <returns></returns>
        /// CreatedBy : NXHOANG (23/07/2022)
        public virtual async Task<ServiceResult> AddMultyEntity(string lstEntity)
        {
            _serviceResult.Data = await _baseRepository.AddMultyEntity(lstEntity);
            return _serviceResult;
        }

        /// <summary>
        /// Lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : NXHOANG(9/11/2021)
        public virtual async Task<IEnumerable<TEntity>> GetEntities()
        {
            var entities = await _baseRepository.GetEntities();
            return entities;
        }

        /// <summary>
        /// Tìm kiếm bản ghi theo Id
        /// </summary>  
        /// <param name="entityId">Id bản ghi cần tìm kiếm</param>
        /// <returns>Bản ghi đầu tiên được tìm thấy theo Id</returns>
        ///  CreatedBy : NXHOANG (01/08/2022)
        public async Task<TEntity> GetEntityById(string entityId)
        {
            return await _baseRepository.GetEntityById(entityId);
        }


        /// <summary>
        /// Xóa một bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy : NXHOANG(9/11/2021)
        public async Task<int> DeleteEntity(string entityId)
        {
            return await _baseRepository.DeleteEntity(entityId);
        }


        /// <summary>
        /// Cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Trả về thông báo kết quả sau khi cập nhật</returns>
        /// CreatedBy : NXHOANG(9/11/2021)   
        public virtual async Task<ServiceResult> UpdateEntity(TEntity entity)
        {

            _serviceResult.Data = await _baseRepository.UpdateEntity(entity);

            return _serviceResult;
        }

       


        #endregion


    }
}
