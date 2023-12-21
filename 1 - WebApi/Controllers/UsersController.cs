
using System.Text;
using Application.ViewModels;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("CreateTokenIdentity")]
        public async Task<IActionResult> CreateTokenIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                return Unauthorized();
            }

            Microsoft.AspNetCore.Identity.SignInResult? result = await _signInManager.PasswordSignInAsync(login.Email, login.Senha, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                ApplicationUser? userCurrent = await _userManager.FindByEmailAsync(login.Email);
                string? idUser = userCurrent.Id;

                JwtToken? token = new JwtTokenBuilder()
                .AddSecurityKey(JwtSecurityKey.Create("Secret_Key_26042002"))
                .AddSubject("Minhas Financas")
                .AddIssuer("Testing.Security.Bearer")
                .AddAudience("Testing.Security.Bearer")
                .AddClaim("idUser", idUser)
                .AddExpiry(5)
                .Builder();

                return Ok(token.Value);
            }
            else
                return Unauthorized();
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("AddUserIdentity")]
        public async Task<IActionResult> AddUserIdentity([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return Unauthorized("Faltam Informações...");

            ApplicationUser? user = new ApplicationUser()
            {
                UserName = login.Email,
                Email = login.Email,
                CPF = login.CPF ?? string.Empty,
                TipoUsuario = TypeUser.Comun,
            };

            IdentityResult? result = await _userManager.CreateAsync(user, login.Senha);

            if (result.Errors.Any())
                return BadRequest(result.Errors);

            //Confirmação
            string? userId = await _userManager.GetUserIdAsync(user);
            string? code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            IdentityResult? result2 = await _userManager.ConfirmEmailAsync(user, code);

            if (result2.Succeeded)
                return Ok("Usuário Adicionado com Sucesso.");
            else
                return BadRequest("Erro ao Adicionar, Verifique os dados.");

        }
    }
}