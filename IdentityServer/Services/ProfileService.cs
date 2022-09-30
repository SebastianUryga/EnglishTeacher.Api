using IdentityServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        private UserManager<ApplicationUser> _userMenager;

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = await _userMenager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email)
            };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userMenager.GetUserAsync(context.Subject);
            context.IsActive = user != null;
        }
    }
}
