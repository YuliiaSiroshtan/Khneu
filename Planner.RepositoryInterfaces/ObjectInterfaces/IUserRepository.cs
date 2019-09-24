using Planner.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.RepositoryInterfaces.ObjectInterfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetByUserName(String userName);
        ApplicationUser GetUser(String userName, String password);
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetByUserId(String userId);
        void UpdateUser(ApplicationUser user);
    }
}
