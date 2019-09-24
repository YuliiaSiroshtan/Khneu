using System;

namespace Planner.DependencyInjection.ViewModels.User
{
    public class UserListItemViewModel
    {
        public String ApplicationUserId { get; set; }
        public String Email { get; set; }
        public String FullName { get; set; }
        public Boolean IsActive { get; set; }
    }
}
