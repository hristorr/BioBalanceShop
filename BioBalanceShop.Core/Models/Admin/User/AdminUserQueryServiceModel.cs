using BioBalanceShop.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Models.Admin.User
{
    public class AdminUserQueryServiceModel
    {
        public int TotalUsersCount { get; set; }

        public IEnumerable<AdminUserServiceModel> Users { get; set; } = new List<AdminUserServiceModel>();
    }
}
