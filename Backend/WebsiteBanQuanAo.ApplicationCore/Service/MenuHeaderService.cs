using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Service
{
    public class MenuHeaderService : BaseService<MenuHeader>,IMenuHeaderService
    {
        #region Constructor
        public MenuHeaderService(IMenuHeaderRepository menuRepository) : base(menuRepository)
        {

        }
        #endregion
    }
}
