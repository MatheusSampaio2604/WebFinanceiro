using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application
{
    public class MensagemApp : App<MensagemViewModel, Mensagem>, IMensagemApp
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagemApp(IMapper mapper, IMensagemRepository mensagemRepository) : base(mapper, mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        public async Task<int> CreateMessage(MensagemViewModel mensagem)
        {
            var validateTitle = mensagem.ValidarPropriedadeString(mensagem.Titulo, "Título");

            if (validateTitle)
            {
                mensagem.DataCadastro = DateTime.Now;
                mensagem.DataAlteracao = DateTime.Now;

                Mensagem map = _mapper.Map<MensagemViewModel, Mensagem>(mensagem);
                return await _mensagemRepository.CreateAsync(map);
            }
            return 0;
        }

        public async Task<IEnumerable<MensagemViewModel>> FindAllMessages()
        {
            IEnumerable<Mensagem> models =  await _mensagemRepository.FindAllMessages(m => m.Ativo);
            IEnumerable<MensagemViewModel> modelViews = _mapper.Map<IEnumerable<Mensagem>, IEnumerable<MensagemViewModel>>(models);

            return modelViews;
        }

        public async Task<MensagemViewModel> EditMessage(MensagemViewModel mensagem)
        {
            bool validateTitle = mensagem.ValidarPropriedadeString(mensagem.Titulo, "Título");
            if (validateTitle)
            {
                mensagem.DataAlteracao = DateTime.Now;

                Mensagem map = _mapper.Map<MensagemViewModel, Mensagem>(mensagem);
                await _mensagemRepository.EditAsync(map);

                return mensagem;
            }
            return null;
        }
    }
}
