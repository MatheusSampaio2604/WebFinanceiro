

using System.ComponentModel.DataAnnotations.Schema;

namespace Application.ViewModels
{
    public class Notifies
    {
        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notificacoes { get; set; }

        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrEmpty(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatorio",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }


        public bool ValidarPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatorio",
                    NomePropriedade = nomePropriedade
                });
                return false;
            }
            return true;
        }





    }
}