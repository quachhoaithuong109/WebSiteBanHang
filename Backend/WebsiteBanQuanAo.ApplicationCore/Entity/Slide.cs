using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    public class Slide : BaseEntity
    {
        #region Property
        /// <summary>
        /// Id slide
        /// </summary>
        public Guid SlideId { get; set; }


        /// <summary>
        /// Tên slide
        /// </summary>
        public string SlideName { get; set; }

        /// <summary>
        /// Ảnh slide
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; }

        #endregion

    }
}
