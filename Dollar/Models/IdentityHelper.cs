using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dollar.Models
{
    public class IdentityHelper
    {
        public const string ManagementRole = "Managament";
        public const string UserRole = "User";

        public static void SetIdentityOptions(IdentityOptions option)
        {
            // Set Sign In Options
            option.SignIn.RequireConfirmedAccount = false;
            option.SignIn.RequireConfirmedPhoneNumber = false;

            // Set Password Strength
            option.Password.RequireDigit = false;
            option.Password.RequireLowercase = false;
            option.Password.RequireUppercase = false;
            option.Password.RequiredLength = 8;
            option.Password.RequireNonAlphanumeric = false;

            // Set Lockout Options
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            option.Lockout.MaxFailedAccessAttempts = 5;
        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleMgr = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // create role if it does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleMgr.RoleExistsAsync(role);

                if (!doesRoleExist)
                {
                    await roleMgr.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultInstructor(IServiceProvider serviceProvider)
        {
            const string email = "computerprogramming@cptc.edu";
            const string username = "instructor";
            const string password = "P@ssw0rd";

            var userMgr = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Check if any users are in the database;
            if (userMgr.Users.Count() == 0)
            {
                IdentityUser instructor = new IdentityUser()
                {
                    Email = email,
                    UserName = username
                };

                // Create Instructor
                await userMgr.CreateAsync(instructor, password);

                // Add to instructor role
                await userMgr.AddToRoleAsync(instructor, ManagementRole);
            }
        }
    }
}
