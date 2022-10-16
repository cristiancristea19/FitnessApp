using Application.Models.AuthenticationModels;
using Domain.Entities.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Authentication
{
    public interface IUserService
    {
        Task<UserModel> LogInAsync(string email, string password);

        Task SignOutAsync();

        Task<UserModel> RegisterAsync(RegisterUserModel user);

        Task DeleteUserAsync(Guid id);

        Task<List<UserModel>> GetUsersAsync();

        Task<bool> ExistsUserAsync(Guid id);

        Task<bool> IsUsernameUniqueAsync(string username);

        Task<bool> IsEmailUniqueAsync(string email);

        Task<UserModel> GetUsersByIdAsync(Guid id);
    }
}