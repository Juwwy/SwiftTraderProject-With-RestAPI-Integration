using Microsoft.AspNetCore.Identity;
using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Entities;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserService(UserManager<Users> userManager, SignInManager<Users> signInManager, RoleManager<IdentityRole> roleManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<string> AddUser(AddUserDTO model)
        {
            var user = new Users
            {
                Fullname = model.Fullname,
                Email = model.Email,
                Telephone = model.Telephone,
                UserName = model.Username,
                WalletBalance = model.WalletBalance,
            };
            

            var result = await userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                if(!await roleManager.RoleExistsAsync(model.UserRole))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = model.UserRole });
                }

                await userManager.AddToRoleAsync(user, model.UserRole);
            }

            return user.Id;
        }

        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Email = user.Email,
                Telephone = user.Telephone,
                Username = user.UserName,
                UserRole = user.UserRole,
                WalletBalance = user.WalletBalance
            };
        }

        public async Task<UserDTO> GetUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return new UserDTO
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Email = user.Email,
                Telephone = user.Telephone,
                Username = user.UserName,
                UserRole = user.UserRole,
                WalletBalance = user.WalletBalance
            };
        }

        public async Task<string> GetUserId(ClaimsPrincipal principal)
        {
            var user = await GetUser(principal);
            return user.Id;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var user = userManager.Users;
            return user.Select(e => Map(e)).ToList();

        }

        public async Task<bool> LoginUser(LogInDTO model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if(result.Succeeded)
            {
                return true;
            } return false;
        }

        public async Task LogoutUser()
        {
            await signInManager.SignOutAsync();
        }

        private static UserDTO Map(Users model)
        {
            return new UserDTO()
            {
                Id = model.Id,
                Fullname = model.Fullname,
                Email = model.Email,
                Telephone = model.Telephone,
                Username = model.UserName,
                UserRole = model.UserRole,
                WalletBalance = model.WalletBalance,
            };
        }


    }
}
