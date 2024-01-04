using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Interface.Service
{
    public interface IFooterProductService : IBaseService<FooterProduct>
    {
        public Task<FooterViewModel> GetFooterProducts();
    }
}
