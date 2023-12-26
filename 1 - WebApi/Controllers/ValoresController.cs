using Application;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ValoresController : ControllerBase
    {
        private readonly IValoresApp _iValoresApp;
        private readonly IMapper _mapper;

        public ValoresController(IMapper mapper,IValoresApp iValoresApp)
        {
            _mapper = mapper;
            _iValoresApp = iValoresApp;
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpGet("Index")]
        public ActionResult Index()
        {
            try
            {
                var index = _iValoresApp.FindAllAsync().Result;
                return Ok(index);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpGet("Details")]
        public ActionResult Details(int id)
        {
            try
            {
                var details = _iValoresApp.FindOneAsync(id);
                return Ok(details);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }


        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Create")]
        public IActionResult Create(ValoresViewModel valores)
        {
            try
            {
                var create = _iValoresApp.CreateAsync(valores);
                return Ok(create);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Edit")]
        public ActionResult Edit(ValoresViewModel valores)
        {
            try
            {
                var edit = _iValoresApp.EditAsync(valores);
                return Ok(edit);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Remove")]
        public ActionResult Remove(ValoresViewModel valores)
        {
            try
            {
                var map = _mapper.Map<Valores>(valores);
                var remove = _iValoresApp.Remove(map);
                return Ok(remove);
            }
            catch (Exception e)
            { return BadRequest("Não foi possivel completar a solicitação..." + e.Message); }
        }
    }
}
