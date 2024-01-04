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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        #region Constructor
        public UserRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

    }
}
