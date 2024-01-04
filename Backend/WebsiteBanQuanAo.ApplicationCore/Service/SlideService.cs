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
    public class SlideService : BaseService<Slide>, ISlideService
    {
        #region Constructor
        public SlideService(ISlideRepository slideRepository) : base(slideRepository)
        {

        }
        #endregion
    }
}
