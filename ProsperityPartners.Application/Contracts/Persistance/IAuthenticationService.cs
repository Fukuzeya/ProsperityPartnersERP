using Microsoft.AspNetCore.Identity;
using ProsperityPartners.Application.Shared.AuthenticationaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Contracts.Persistance
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(CreateUserDto userDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
