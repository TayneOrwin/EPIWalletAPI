using EPIWalletAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace EPIWalletAPI.Factory
{
    public class AppUserClaimsPrincipalFactory:UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccesor): base(userManager, roleManager, optionsAccesor)
        {

        }
    }
}
