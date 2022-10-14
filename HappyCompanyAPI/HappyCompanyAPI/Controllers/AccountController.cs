using BusinessLogic.SpecificRepository;
using DataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HappyCompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountRepository accountRepository;
        IConfiguration configuration;

        public AccountController(IAccountRepository _accountRepository, IConfiguration _configuration)
        {
            accountRepository = _accountRepository;
            configuration = _configuration;
        }
        //[HttpPost]
        //[Route("NewRole")]
        //public async Task NewRole(RoleModel model)
        //{
        //    var result = await accountRepository.AddRole(model);
        //}
        [HttpPost]
        [Route("CreateUser")]
        //[Authorize]
        public async Task CreateUser(SignUpModel signUpModel)
        {
            var result = await accountRepository.CreateUser(signUpModel);
        }
        [HttpGet]
        [Route("GetRoles")]
        //[Authorize]
        public List<IdentityRole> RoleList()
        {
            List<IdentityRole> li = accountRepository.GetRoles();
            return li;

        }
        [HttpGet]
        [Route("GetUsers")]
        //[Authorize]
        public List<ApplicationUser> UserList()
        {
            List<ApplicationUser> li = accountRepository.getUsers();
            return li;

        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            var result = await accountRepository.SignIn(signInModel);
            if (result.Succeeded)
            {
                var user = await accountRepository.getUser(signInModel.Username);


                var authClaim = new List<Claim>
                {
                    new Claim("Name", signInModel.Username),
                    new Claim("UniqueValue", Guid.NewGuid().ToString())
                };

                var roles = accountRepository.getUserRoles(user);

                foreach (var item in roles)
                {
                    authClaim.Add(new Claim("Role", item));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                            issuer: configuration["JWT:ValidIssuer"],
                            audience: configuration["JWT:ValidAudience"],
                            expires: DateTime.Now.AddDays(15),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                // build token
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpGet]
        [Route("Delete")]
        //[Authorize]
        public void Delete(string Id)
        {
            accountRepository.Delete(Id);
        }
        [HttpGet]
        [Route("GetUser")]
        //[Authorize]
        public async Task<ApplicationUser> getUser(string username)
        {
            ApplicationUser applicationUser = await accountRepository.getUser(username);
            return applicationUser;
        }
    }
}
