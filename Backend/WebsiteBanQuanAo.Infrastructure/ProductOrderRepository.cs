using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.Interface.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.Infrastructure
{
    public class ProductOrderRepository : BaseRepository<ProductOrder>, IProductOrderRepository
    {
        #region Constructor
        public ProductOrderRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}
