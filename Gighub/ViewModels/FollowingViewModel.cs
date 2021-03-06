using Gighub.Models;
using System.Collections.Generic;

namespace Gighub.ViewModels
{
    public class FollowingViewModel
    {
        public IEnumerable<ApplicationUser>  Following { get; set; }
        public IEnumerable<ApplicationUser> Followers { get; set; }
        
    }
}