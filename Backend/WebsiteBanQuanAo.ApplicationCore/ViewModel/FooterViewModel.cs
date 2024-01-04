using NXHOANG.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class FooterViewModel
    {
        /// <summary>
        /// Thông tin footer
        /// </summary>
        public string FooterInfo { get; set; }

        /// <summary>
        /// Kết nối Footer
        /// </summary>
        public string FooterContact { get; set; }

        /// <summary>
        /// Footer Help
        /// </summary>
        public string FooterHelp { get; set; }

        /// <summary>
        /// Danh sách menu
        /// </summary>
        public List<ProductCategory> Menus { get; set; }

        /// <summary>
        /// Thông tin
        /// </summary>
        public List<string> Infos { get; set; }

    }
}
