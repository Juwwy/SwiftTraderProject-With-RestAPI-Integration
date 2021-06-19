using SwiftTraders.ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SwiftTraders.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(ClaimsPrincipal principal);
        Task<UserDTO> GetUser(string id);
        Task<string> GetUserId(ClaimsPrincipal principal);
        IEnumerable<UserDTO> GetUsers();
        Task<string> AddUser(AddUserDTO user);
        Task<bool> LoginUser(LogInDTO model); 
        Task LogoutUser();
    }
}
