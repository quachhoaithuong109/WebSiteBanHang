using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    public class Product : BaseEntity
    {

        #region Property

        /// <summary>
        /// Id sản phẩm
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Id danh mục 
        /// </summary>
        public Guid CategoryID { get; set; }

        /// <summary>
        /// Loại sản phẩm
        /// 1.Bàn Ghế
        /// 2.Tủ
        /// 3.Giường
        /// </summary>
        public int? TypeProduct { get; set; }

        /// <summary>
        /// Hình ảnh sản phẩm
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// List hình ảnh chi tiết sản phẩm
        /// </summary>
        public string MoreImages { get; set; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Giá khuyến mãi
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// Bảo hành
        /// </summary>
        public int? Warranty { get; set; }


        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Nội dung sản phẩm
        /// </summary>
        public string Content { get; set; }
        #endregion

    }
}
