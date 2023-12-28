using System.Security.Claims;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class QuantidadeController : ControllerBase
    {
        private readonly IQuantidadesApp _iQuantidadesApp;
        private readonly IMapper _mapper;
        public QuantidadeController(IMapper mapper,IQuantidadesApp quantidadesApp)
        {
            _mapper = mapper;
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

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            IEnumerable<QuantidadesViewModel>? index =  _iQuantidadesApp.FindAllAsync().Result.Where(x=>x.UserId == ReturnLoggedUser());
            return Ok(index);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [Produces("Application/Json")]
        [HttpPost("Create")]
        public IActionResult Create(QuantidadesViewModel quantidades) {
            try
            {
                var create = _iQuantidadesApp.CreateAsync(quantidades);
                return Ok(create);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            try
            {
                var details = _iQuantidadesApp.FindOneAsync(id);
                return Ok(details);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }


        [Authorize]
        [ValidateAntiForgeryToken]
        [Produces("Application/Json")]
        [HttpPost("Edit")]
        public IActionResult Edit(QuantidadesViewModel quantidades)
        {
            try
            {
                var edit = _iQuantidadesApp.EditAsync(quantidades).Result;
                return Ok(edit);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [Produces("Application/Json")]
        [HttpPost("Remove")]
        public IActionResult Remove(QuantidadesViewModel quantidades)
        {

            try
            {
                var map = _mapper.Map<Quantidades>(quantidades);
                var remove = _iQuantidadesApp.Remove(map);
                return Ok(remove);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }
    }
}