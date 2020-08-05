using System;
using System.Collections.Generic;

namespace AcmeProducer.Model
{
    public partial class Endereco
    {
        public Endereco()
        {
            Cliente = new HashSet<Cliente>();
        }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Uf { get; set; }
        public string Logradouro { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
