using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using NXHOANG.ApplicationCore.Interface.Service;
using NXHOANG.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.Service
{
    public class FooterProductService : BaseService<FooterProduct>, IFooterProductService
    {
        #region Declare
        private readonly IFooterProductRepository _footerProductRepository;
        private readonly IProductCategoryService _productCategoryService;
        #endregion

        #region Constructor
        public FooterProductService(IFooterProductRepository footerProductRepository, IProductCategoryService productCategoryService) : base(footerProductRepository)
        {
            _footerProductRepository = footerProductRepository;
            _productCategoryService = productCategoryService;
        }

        #endregion

        #region Method

        /// <summary>
        /// Method Lấy dữ liệu footer
        /// </summary>
        /// <returns>Thông tin footer</returns>
        /// NXHOANG 17/07/2022
        public async Task<FooterViewModel> GetFooterProducts()
        {
            FooterViewModel footerViewModel = new FooterViewModel();
            var footers = await _footerProductRepository.GetEntities() as List<FooterProduct>;

            var productCategorys = await _productCategoryService.GetEntities() as List<ProductCategory>;

            var footerInfo = footers.FirstOrDefault();

            footerViewModel.FooterContact = footerInfo.FooterContact;
            footerViewModel.FooterInfo = footerInfo.FooterInfo;
            footerViewModel.Infos = JsonSerializer.Deserialize<List<string>>(footerInfo.FooterHelp);

            footerViewModel.Menus = productCategorys.OrderBy(x => x.DisplayOrder).ToList();

            return footerViewModel;

        }
        #endregion
    }
}
