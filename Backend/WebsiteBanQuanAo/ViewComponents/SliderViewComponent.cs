using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NXHOANG.DoAnTotNghiep.ViewComponents
{
    public class SliderViewComponent : ViewComponent
    {
        #region Declare
        private readonly ISlideService _slideService;
        #endregion

        #region Constructor
        public SliderViewComponent(ISlideService slideService)
        {
            _slideService = slideService;
        }

        #endregion


        public IViewComponentResult Invoke()
        {
            var slides = _slideService.GetEntities().Result as List<Slide>;

            return View(slides);
        }
    }
}
