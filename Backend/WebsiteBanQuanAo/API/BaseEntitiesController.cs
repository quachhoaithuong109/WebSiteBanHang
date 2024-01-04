using NXHOANG.ApplicationCore.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.API
{

    /// <summary>
    /// API lớp Base dùng chung
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [Route("api/v1/[controller]")]
    [ApiController]

    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        #region Declare

        /// <summary>
        /// Service base dùng để sử lý các nghiệp vụ dùng chung
        /// </summary>
        IBaseService<TEntity> _baseService;

        #endregion
    
        #region Constructor
        public BaseEntitiesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion


        #region Method


        /// <summary>
        /// API lấy danh sách dữ liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        /// CreatedBy : NXHOANG 30/07/2022
        [HttpGet]
        public virtual IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);

        }

        /// <summary>
        /// API lấy 1 record theo trường id
        /// </summary>
        /// <param name="id">Giá trị trường id</param>
        /// <returns>Trả về 1 record được tìm thấy</returns>
        /// CreatedBy : NXHOANG 30/07/2022
        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {
            var entity = _baseService.GetEntityById(id).Result;
            return Ok(entity);
        }


        /// <summary>
        /// API Thêm một record 
        /// </summary>
        /// <param name="entity">Thông tin record muốn thêm vào</param>
        /// <returns>Thông báo kết quả trả về</returns>
        /// CreatedBy :  NXHOANG 30/07/2022
        [HttpPost]
        public virtual IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseService.AddEntity(entity);
            
            return StatusCode(201, serviceResult);
        }


        /// <summary>
        /// API Xóa 1 record theo trường id
        /// </summary>
        /// <param name="id">Giá trị của trường id của record muốn xóa</param>
        /// <returns>Số row bị ảnh hưởng</returns>
        /// CreatedBy :  NXHOANG 30/07/2022
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var rowAffects = _baseService.DeleteEntity(id);
            return Ok(rowAffects);
        }


        /// <summary>
        /// API sửa 1 record
        /// </summary>
        /// <param name="id">Giá trị trường id của record muốn sửa</param>
        /// <param name="entity">Record muốn sửa</param>
        /// <returns>Thông báo kết quả trả về</returns>
        /// CreatedBy :  NXHOANG 30/07/2022
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromRoute] string id, [FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if (keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if (keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }
            var serviceResult = _baseService.UpdateEntity(entity);
            //if (serviceResult.MisaCode == MISAEnum.NotValid)
            //{
            //    return BadRequest(serviceResult);
            //}
            return Ok(serviceResult);
        }



        #endregion



    }
}
