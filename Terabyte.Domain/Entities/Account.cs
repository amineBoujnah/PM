using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Terabyte.Domain.Entities.Account;

namespace Terabyte.Domain.Entities
{
    public class Account : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public virtual ICollection<Publication> publications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }



        public class CustomUserLogin : IdentityUserLogin<int>
        {
            public int Id { get; set; }

        }
        public class CustomUserRole : IdentityUserRole<int>
        {
            public int Id { get; set; }
        }
        public class CustomUserClaim : IdentityUserClaim<int>
        {

        }
        public class CustomRole : IdentityRole<int, CustomUserRole>
        {
            public CustomRole() { }
            public CustomRole(string name) { Name = name; }
        }
    }
}
