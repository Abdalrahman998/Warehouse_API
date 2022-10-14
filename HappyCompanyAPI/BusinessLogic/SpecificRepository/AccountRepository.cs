using DataAccess.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public class AccountRepository:IAccountRepository
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<ApplicationUser> _userManager,
                                SignInManager<ApplicationUser> _signInManager,
                                RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> AddRole(RoleModel roleModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.Name;

            var result = await roleManager.CreateAsync(role);
            return result;
        }
        public async Task<IdentityResult> CreateUser(SignUpModel signUpModel)
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = signUpModel.FirstName;
            user.MiddleName = signUpModel.MiddleName;
            user.LastName = signUpModel.LastName;
            user.Email = signUpModel.Email;
            user.UserName = signUpModel.Email;
            //user.PasswordHash = signUpModel.Password;
            var result = await userManager.CreateAsync(user, signUpModel.Password);

            if (result.Succeeded)
            {
                var role = await roleManager.FindByIdAsync(signUpModel.RoleId);
                result = await userManager.AddToRoleAsync(user, role.Name);
            }
            return result;
        }
        public List<IdentityRole> GetRoles()
        {
            List<IdentityRole> liRole = roleManager.Roles.ToList();
            return liRole;
        }
        public List<ApplicationUser> getUsers()
        {
            List<ApplicationUser> liUser = userManager.Users.ToList();
            return liUser;
        }
        public async Task<SignInResult> SignIn(SignInModel signInModel)
        {
            var result = await signInManager.PasswordSignInAsync(signInModel.Username, signInModel.Password, false, false);
            return result;
        }
        public async Task<ApplicationUser> getUser(string username)
        {
            var result = await userManager.FindByNameAsync(username);
            return result;
        }
        public List<string> getUserRoles(ApplicationUser obj)
        {
            List<string> li = userManager.GetRolesAsync(obj).Result.ToList();
            return li;
        }
        public async Task Delete(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var result = await userManager.DeleteAsync(user);
        }
        

    }
}
