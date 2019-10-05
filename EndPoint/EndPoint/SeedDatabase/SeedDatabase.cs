using EndPoint.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.SeedDatabase
{
    public static class SeedDatabase
    {
        public static void SeedData(UserManager<ApplicationUserModel> userManager, RoleManager<ApplicationRoleModel> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUserModel> userManager)
        {
            if (userManager.FindByEmailAsync("user1").Result == null)
            {
                ApplicationUserModel user = new ApplicationUserModel();
                user.UserName = "user1";
                user.NormalizedUserName = "user";
                user.Email = "user1@local.com";
                user.FirstName = "user1";
                user.LastName = "test";

                IdentityResult result = userManager.CreateAsync(user, "user1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

            if (userManager.FindByEmailAsync("user2").Result == null)
            {
                ApplicationUserModel user = new ApplicationUserModel();
                user.UserName = "user2";
                user.NormalizedUserName = "user";
                user.Email = "user2@local.com";
                user.FirstName = "user2";
                user.LastName = "test";

                IdentityResult result = userManager.CreateAsync(user, "user2").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Editor").Wait();
                }
            }

            if (userManager.FindByEmailAsync("user3").Result == null)
            {
                ApplicationUserModel user = new ApplicationUserModel();
                user.UserName = "user3";
                user.NormalizedUserName = "user";
                user.Email = "user2@local.com";
                user.FirstName = "user2";
                user.LastName = "test";

                IdentityResult result = userManager.CreateAsync(user, "user3").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<ApplicationRoleModel> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                ApplicationRoleModel identityRole = new ApplicationRoleModel();
                identityRole.Name = "Administrator";
                
                identityRole.Description = "Full access to the application.";
                identityRole.NormalizedName = "Admin";
                IdentityResult result = roleManager.CreateAsync(identityRole).Result;
            }

            if (!roleManager.RoleExistsAsync("Editor").Result)
            {
                ApplicationRoleModel identityRole = new ApplicationRoleModel();
                identityRole.Name = "Editor";
                identityRole.Description = "Can edit posts and comments.";
                identityRole.NormalizedName = "Edit";
                IdentityResult result = roleManager.CreateAsync(identityRole).Result;
            }

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                ApplicationRoleModel identityRole = new ApplicationRoleModel();
                identityRole.Name = "User";
                identityRole.Description = "Can write posts and comments.";
                identityRole.NormalizedName = "User";
                IdentityResult result = roleManager.CreateAsync(identityRole).Result;
            }
        }
    }
}
