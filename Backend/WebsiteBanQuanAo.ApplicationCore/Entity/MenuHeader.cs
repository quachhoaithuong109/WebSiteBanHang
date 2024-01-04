using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    public class MenuHeader : BaseEntity
    {
        #region Property

        /// <summary>
        /// Id menu
        /// </summary>
        public Guid MenuHeaderId { get; set; }

        /// <summary>
        /// Tên menu
        /// </summary>
        public string MenuHeaderName { get; set; }

        /// <summary>
        /// 1.Có dropdown
        /// 2.Ko có dropdown
        /// </summary>
        public int IsDropDown { get; set; }

        /// <summary>
        /// Dùng để sort menu theo thứ tự
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// Đường dẫn
        /// </summary>
        public string MenuLink { get; set; }

        #endregion
    }
}
