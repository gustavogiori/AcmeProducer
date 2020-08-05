using System;
using System.Collections.Generic;

namespace AcmeProducer.Model
{
    public partial class Instalacao
    {
        public Instalacao()
        {
            Fatura = new HashSet<Fatura>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime? DataInstalacao { get; set; }
        public int? IdCliente { get; set; }
        public int? IdEndereco { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Fatura> Fatura { get; set; }
    }
}
