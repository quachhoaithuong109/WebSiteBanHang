using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class ProductDetailViewModel
    {
        /// <summary>
        /// Sản phẩm
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Sản phẩm liên quan
        /// </summary>
        public List<Product> ProductRelates { get; set; }


    }
}
