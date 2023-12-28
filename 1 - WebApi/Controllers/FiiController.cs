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
    public class FiiController : ControllerBase
    {
        private readonly IFiiApp _iFiiApp;
        private readonly IMapper _mapper;
        public FiiController(IMapper mapper, IFiiApp iFiiApp)
        {
            _iFiiApp = iFiiApp;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var index = await _iFiiApp.FindAllAsync();
            if (index is null)
                return BadRequest("Não foi possivel completar a Requisição");
            return Ok(index);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(FiiViewModel fii)
        {
            fii.Nome = fii.Nome.ToUpper();

            var create = await _iFiiApp.CreateAsync(fii);

            if (create is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("Details")]
        public async Task<IActionResult> Details(int id)
        {
            var details = await _iFiiApp.FindOneAsync(id);

            if (details is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(details);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var edit = await _iFiiApp.FindOneAsync(id);

            if (edit is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(edit);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(FiiViewModel fii)
        {
            fii.Nome = fii.Nome.ToUpper();

            var create = await _iFiiApp.EditAsync(fii);

            if (create is null)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }

        [AllowAnonymous]
        [Produces("Application/Json")]
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove(FiiViewModel fii)
        {
            var m = _mapper.Map<Fii>(fii);
            var create = await _iFiiApp.Remove(m);

            if (create is 0)
                return BadRequest("Não foi possivel completar a Requisição");

            return Ok(create);
        }

    }
}