using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Param
{
    public class ProductCategoryParam
    {
        #region Property

        /// <summary>
        /// Id danh mục sản phẩm
        /// </summary>
        public string ProductCategoryId { get; set; }

        /// <summary>
        /// Tên danh mục sản phẩm
        /// </summary>
        public string ProductCategoryName { get; set; }

        /// <summary>
        /// Alias danh mục sản phẩm
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string Description { get; set; }

        #endregion

    }
}
