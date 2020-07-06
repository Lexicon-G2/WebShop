using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppForWebshop.Data;

namespace WebAppForWebshop.Models
{
    public class dbSeedUserRoles
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public dbSeedUserRoles(ApplicationDbContext context, UserManager<ApplicationUser> userMrg)
        {
            _context = context;
            _userManager = userMrg;        
        }
        public async void SeedAdminUser()
        {

            var user = new ApplicationUser
            {
                UserName = "superadmin@admin",
                NormalizedUserName = "SUPERADMIN@ADMIN",
                Email = "superadmin@admin",
                NormalizedEmail = "SUPERADMIN@ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Admin",
                Address = "AdminGatan 2"
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });
            }
            if (!_context.Roles.Any(r => r.Name == "Customer"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
        {
            var password = new PasswordHasher<ApplicationUser>();
var hashed = password.HashPassword(user, "1234");
user.PasswordHash = hashed;
            var userStore = new UserStore<ApplicationUser>(_context);
await userStore.CreateAsync(user);

                //string userId = user.Id;
                //ApplicationUser useradmin = await _userManager.FindByIdAsync(userId);
                //if(useradmin != null) {
                //IdentityResult result = await _userManager.AddToRoleAsync(user, "SuperAdmin");
                await userStore.AddToRoleAsync(user, "SUPERADMIN");
                //var result = _userManager.AddToRoleAsync(user, "Admin");
                //}
                //if (result.Succeeded)
                //    await _userManager.AddToRoleAsync(user, "SuperAdmin");

                //await _userManager.AddToRoleAsync(user, "Admin");
            }

            
            _context.SaveChanges();
    }
        
    }
}
