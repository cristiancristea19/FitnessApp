using Application.Interfaces;
using Application.Interfaces.Authentication;
using Application.Models.AuthenticationModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Persistance
{
    public class FitnessDbContextInitializer : IFitnessDbContextInitializer
    {
        private readonly FitnessDbContext _fitnessDbContext;
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;

        public FitnessDbContextInitializer(FitnessDbContext fitnessDbContext, IUserService userService, IServiceProvider serviceProvider)
        {
            _fitnessDbContext = fitnessDbContext;
            _userService = userService;
            _serviceProvider = serviceProvider;
        }

        public async Task SeedAsync()
        {
            await MigrateDatabaseAsync();
            await InitializeUsersAsync(_serviceProvider);
        }

        private async Task MigrateDatabaseAsync()
        {
            await _fitnessDbContext.Database.MigrateAsync();
        }

        private async Task InitializeUsersAsync(IServiceProvider serviceProvider)
        {

            if (!await _fitnessDbContext.Users.AnyAsync())
            {
                var user1 = serviceProvider.GetRequiredService<IUserService>();
                var user2 = serviceProvider.GetRequiredService<IUserService>();
                var user3 = serviceProvider.GetRequiredService<IUserService>();

                if (user1.IsUsernameUniqueAsync("admin").Result)
                {
                    await user1.RegisterAsync(new RegisterUserModel
                    {
                        Username = "admin",
                        Password = "P@ssw0rd",
                        Email = "admin@webdotnet.com",
                        Role = new RegisterRoleModel
                        {
                            RoleType = RoleTypeEnum.Admin
                        }
                    });
                }

                if (user2.IsUsernameUniqueAsync("user1").Result)
                {
                    await user2.RegisterAsync(new RegisterUserModel
                    {
                        Username = "user1",
                        Password = "P@rola1234",
                        Email = "user1@webdotnet.com",
                        Role = new RegisterRoleModel
                        {
                            RoleType = RoleTypeEnum.User
                        }
                    });
                }

            }
        }

    }
}