using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class QuantidadeController : ControllerBase
    {
        private readonly IQuantidadesApp _iQuantidadesApp;
        public QuantidadeController(IQuantidadesApp quantidadesApp)
        {
            _iQuantidadesApp = quantidadesApp;
        }

        private string ReturnLoggedUser()
        {
            if (User != null)
            {
                Claim? idUser = User.FindFirst("idUser");
                return idUser.Value;
            }
            return string.Empty;
        }

        [Authorize]
        [Produces("Application/Json")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var index =  _iQuantidadesApp.FindAllAsync().Result.Where(x=>x.UserId == ReturnLoggedUser());
            return Ok(index);
        }
    }
}