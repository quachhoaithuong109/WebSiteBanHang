using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.ViewModel
{
    public class PaginationSet
    {
        public int Page { set; get; }
        public int Count
        {
            get
            {
                return (Item != null) ? Item.products.Count() : 0;
            }
        }
        public int TotalPages { set; get; }
        public int TotalCount { set; get; }
        public int MaxPage { set; get; }
        public ProductCategoryViewModel Item { set; get; }
    }
}
