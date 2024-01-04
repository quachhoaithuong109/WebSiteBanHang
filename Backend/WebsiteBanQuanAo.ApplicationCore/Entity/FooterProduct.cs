using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Entity
{
    public class FooterProduct : BaseEntity
    {
        /// <summary>
        /// Id footer
        /// </summary>
        public Guid FooterProductId { get; set; }

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

    }
}
