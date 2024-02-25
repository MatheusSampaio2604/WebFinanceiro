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
    public class AcoesController : ControllerBase
    {
        private readonly IAcoesApp _iAcoesApp;
        private readonly IMapper _mapper;
        public AcoesController(IMapper mapper, IAcoesApp iAcoesApp)
        {
            _iAcoesApp = iAcoesApp;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("findAll")]
        public async Task<IActionResult> FindAll()
        {
            var index = await _iAcoesApp.FindAllAsync();
            return Ok(index);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(AcoesViewModel acoes)
        {
            acoes.Nome = acoes.Nome.ToUpper();

            var create = await _iAcoesApp.CreateAsync(acoes);

            if (create is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _iAcoesApp.FindOneAsync(id);

            if (details is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(details);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _iAcoesApp.FindOneAsync(id);

            if (edit is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(edit);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(AcoesViewModel acoes)
        {
            acoes.Nome = acoes.Nome.ToUpper();

            var create = await _iAcoesApp.EditAsync(acoes);

            if (create is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove(AcoesViewModel acoes)
        {
            var m = _mapper.Map<Acoes>(acoes);
            var create = await _iAcoesApp.Remove(m);

            if (create is 0)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }
    }
}