using Microsoft.AspNetCore.Identity;
using ShopBridge_data.Contexts;
using ShopBridge_model;
using ShopBridge_utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_data.SeederClass
{
    public class RbaSeeder
    {
        public async static Task Seeder(UserManager<AppUsers> userManager, ShopDbContext context, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                await context.Database.EnsureCreatedAsync();
                if (!context.Users.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = UserRole.Admin.ToString() });
                    await roleManager.CreateAsync(new IdentityRole { Name = UserRole.Customer.ToString() });

                    var userList = new List<AppUsers>
                    {
                        new AppUsers
                        {
                            FirstName = "Samuel",
                            LastName = "Adeosun",
                            Email = "samuel@gmail.com",
                            UserName = "Allos",
                            PhoneNumber = "08165434179",
                            PasswordHash = "Password@123",
                            EmailConfirmed = true,
                            Avatar = "http://placehold.it/32x32",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new AppUsers
                        {
                            FirstName = "Gideon",
                            LastName = "Faive",
                            Email = "gideon@gmail.com",
                            UserName = "faive",
                            PhoneNumber = "08143547856",
                            PasswordHash = "Password@123",
                            EmailConfirmed = true,
                            Avatar = "http://placehold.it/32x32",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        },
                        new AppUsers
                        {
                            FirstName = "Ombu",
                            LastName = "Ayebakuro",
                            Email = "kuro@gmail.com",
                            UserName = "iceboss",
                            PhoneNumber = "08186957401",
                            PasswordHash = "Password@123",
                            EmailConfirmed = true,
                            Avatar = "http://placehold.it/32x32",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    };

                    foreach (var user in userList)
                    {
                        await userManager.CreateAsync(user, user.PasswordHash);
                        if (user == userList[0])
                        {
                            await userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
                        }
                        else
                            await userManager.AddToRoleAsync(user, UserRole.Customer.ToString());
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
