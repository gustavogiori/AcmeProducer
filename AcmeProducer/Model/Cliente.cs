using System;
using System.Collections.Generic;

namespace AcmeProducer.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            Instalacao = new HashSet<Instalacao>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Instalacao> Instalacao { get; set; }
    }
}
