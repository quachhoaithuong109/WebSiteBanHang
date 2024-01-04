using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    public class ProductCategory : BaseEntity
    {
        #region Property

        /// <summary>
        /// Id danh mục sản phẩm
        /// </summary>
        public Guid? ProductCategoryId { get; set; }

        /// <summary>
        /// Tên danh mục sản phẩm
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// Id khóa ngoài Menu
        /// </summary>
        public Guid? MenuHeaderId { get; set; }

        /// <summary>
        /// Alias danh mục sản phẩm
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id cha
        /// </summary>
        public Guid? ParentID { get; set; }

        /// <summary>
        /// Sắp xếp danh mục sản phẩm
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string Image { get; set; }


        /// <summary>
        /// Đường dẫn
        /// </summary>
        public string ProductCategoryLink { get; set; }

        #endregion

    }
}
