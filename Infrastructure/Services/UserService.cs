using Application.Interfaces;
using Application.Interfaces.Authentication;
using Application.Models.AuthenticationModels;
using Common;
using Domain.Entities;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Quotation.Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    [MapServiceDependency(nameof(UserService))]
    public class UserService : IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly FitnessDbContext _fitnessDbContext;

        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager, IUnitOfWork unitOfWork, FitnessDbContext fitnessDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _fitnessDbContext = fitnessDbContext;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            _userManager.DeleteAsync(user).Wait();
        }

        public async Task<bool> ExistsUserAsync(Guid id)
        {
            return (await _userManager.FindByIdAsync(id.ToString())) != null;
        }

        public async Task<bool> IsUsernameUniqueAsync(string username)
        {
            return !await _userManager.Users.AnyAsync(u => u.UserName.ToUpper() == username.ToUpper());
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _userManager.Users.AnyAsync(u => u.Email.ToUpper() == email.ToUpper());
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _userManager.Users.Select(u => new UserModel
            {
                Id = Guid.Parse(u.Id),
                Username = u.UserName,
                Email = u.Email,
                Gender = u.Gender,
                Height = u.Height,
                Weight = u.Weight
            }).ToListAsync();

            return users;
        }

        public async Task<UserModel> GetUsersByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
               
                var roleEntity = await _roleManager.FindByNameAsync(userRole);
                var role = new RoleModel
                {
                    Id = roleEntity.Id,
                    RoleName = roleEntity.Name,
                    RoleType = roleEntity.RoleType
                };

                return await Task.FromResult(new UserModel
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Gender = user.Gender,
                    Height = user.Height,
                    Weight = user.Weight,
                    Email = user.Email
                });
            }
            return null;
        }

        public async Task<UserModel> RegisterAsync(RegisterUserModel newUser)
        {
            try
            {
                var roleType = (RoleTypeEnum)newUser.Role.RoleType;
                string roleName = roleType.ToString();
                var roleFindResult = await _roleManager.FindByNameAsync(roleName);
                RoleModel userRole;
                if (roleFindResult == null)
                {
                    return null;
                }
                else
                {
                    userRole = new RoleModel
                    {
                        Id = roleFindResult.Id,
                        RoleName = roleFindResult.Name,
                        RoleType = roleFindResult.RoleType
                    };
                };

                if (newUser != null)
                {
                    var user = new User
                    {
                        UserName = newUser.Username,
                        Email = newUser.Email,
                        Gender = newUser.Gender,
                        Height = newUser.Height,
                        Weight = newUser.Weight
                    };
                    var result = await _userManager.CreateAsync(user, newUser.Password);
                    if (result != IdentityResult.Success)
                    {
                        return null;
                    }

                    var registeredUser = await _userManager.FindByNameAsync(user.UserName);

                    var roleAddResult = await _userManager.AddToRoleAsync(registeredUser, roleName);

                    if (roleAddResult != IdentityResult.Success)
                    {
                        return null;
                    }

                    return await Task.FromResult(new UserModel
                    {
                        Id = Guid.Parse(registeredUser.Id),
                        Username = newUser.Username,
                        Gender = newUser.Gender,
                        Height = newUser.Height,
                        Weight = newUser.Weight,
                        Email = newUser.Email
                    });
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw new Exception("Invalid user data!");
            }
        }

        public async Task<UserModel> LogInAsync(string username, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(username);

            if (existingUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(existingUser.UserName, password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var userRole = (await _userManager.GetRolesAsync(existingUser)).FirstOrDefault();
                 
                    var roleEntity = await _roleManager.FindByNameAsync(userRole);

                    var roleModel = new RoleModel
                    {
                        Id = roleEntity.Id,
                        RoleName = roleEntity.Name,
                        RoleType = roleEntity.RoleType
                    };

                    return await Task.FromResult(new UserModel
                    {
                        Username = existingUser.UserName,
                        Id = Guid.Parse(existingUser.Id),
                        Email = existingUser.Email,
                        Weight = existingUser.Weight,
                        Height = existingUser.Height,
                        Gender = existingUser.Gender
                    });
                }
            }
            return null;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}