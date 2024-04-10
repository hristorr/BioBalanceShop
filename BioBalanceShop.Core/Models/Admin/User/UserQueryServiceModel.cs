using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.User
{
    public class UserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }

        public IEnumerable<UserServiceModel> Users { get; set; } = new List<UserServiceModel>();
    }
}
