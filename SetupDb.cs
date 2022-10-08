
using MCake.Models;
using Microsoft.AspNetCore.Identity;

namespace MCake
{
    public class SetupDb
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<Role> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }



        public static void SeedUsers
    (UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
                   ("manager@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "manager@gmail.com";
                user.Email = "manager@gmail.com";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync
                (user, "Solomon12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            if (userManager.FindByNameAsync
                  ("admin@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync
                (user, "Solomon12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }


            if (userManager.FindByNameAsync
                   ("olafire03@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "olafire03@gmail.com";
                user.Email = "olafire03@gmail.com";
                user.EmailConfirmed = true;
                IdentityResult result = userManager.CreateAsync
                (user, "Solomon12!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }



        public static void SeedRoles(RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync
               ("User").Result)
            {
                Role role = new Role();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                ("Admin").Result)
            {
                Role role = new Role();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync
               ("Manager").Result)
            {
                Role role = new Role();
                role.Name = "Manager";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

    }
}
