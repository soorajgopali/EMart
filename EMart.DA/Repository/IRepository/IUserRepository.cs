using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface IUserRepository : IRepository<UserProfile>
    {

        void Update(UserProfile userProfile);

        UserProfileWithShoppingCartViewModel GetCheckOut(string userId);

    }
}
