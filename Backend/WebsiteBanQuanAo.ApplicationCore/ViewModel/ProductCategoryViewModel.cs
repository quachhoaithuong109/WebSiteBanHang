using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class ProductCategoryViewModel
    {
        /// <summary>
        /// Danh sách sản phẩm
        /// </summary>
        public List<Product> products { get; set; }

        /// <summary>
        /// Danh mục sản phẩm
        /// </summary>  
        public List<ProductCategory> productCategories { get; set; }

        /// <summary>
        /// Danh mục active
        /// </summary>
        public ProductCategory productCategoryActive { get; set; }

        /// <summary>
        /// Tổng sản phẩm
        /// </summary>
        public int TotalProducts { get; set; }

    }
}
