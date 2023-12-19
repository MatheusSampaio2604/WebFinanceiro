using System.Security.Claims;
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
    public class MensagemController : ControllerBase
    {
        private readonly IMapper _iMapper;
        private readonly IMensagemApp _iMensagemApp;

        public MensagemController(IMapper iMapper, IMensagemApp iMensagemApp)
        {
            _iMapper = iMapper;
            _iMensagemApp = iMensagemApp;
        }

        //Recuperar usuario para recuperar id 
        private async Task<string> ReturnLoggedUser()
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
        [HttpPost("Create")]
        public async Task<List<Notifies>> Create(MensagemViewModel mensagemViewModel)
        {
            mensagemViewModel.UserId = await ReturnLoggedUser();
            await _iMensagemApp.CreateAsync(mensagemViewModel);
            return mensagemViewModel.Notificacoes;
        }

        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Edit")]
        public async Task<List<Notifies>> Edit(MensagemViewModel mensagemViewModel)
        {
            //mensagemViewModel.UserId = await ReturnLoggedUser();
            await _iMensagemApp.EditAsync(mensagemViewModel);
            return mensagemViewModel.Notificacoes;
        }

        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Delete")]
        public async Task<IEnumerable<Notifies>> Delete(MensagemViewModel mensagemViewModel)
        {
            var map = _iMapper.Map<Mensagem>(mensagemViewModel);
            await _iMensagemApp.Remove(map);
            return mensagemViewModel.Notificacoes;
        }

        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("Details")]
        public async Task<MensagemViewModel> Details(Mensagem mensagem)
        {
            var data = await _iMensagemApp.FindOneAsync(mensagem.Id);
            return data;
        }

        [Authorize]
        [Produces("Application/Json")]
        [HttpPost("FindAll")]
        public async Task<IEnumerable<MensagemViewModel>> FindAll()
        {
            var data = await _iMensagemApp.FindAllAsync();
            return data;
        }

    }
}