using DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> AddRole(RoleModel roleModel);
        Task<IdentityResult> CreateUser(SignUpModel signUpModel);
        List<IdentityRole> GetRoles();
        List<ApplicationUser> getUsers();
        Task<SignInResult> SignIn(SignInModel signInModel);
        Task<ApplicationUser> getUser(string username);
        List<string> getUserRoles(ApplicationUser obj);
        Task Delete(string Id);
    }
}
