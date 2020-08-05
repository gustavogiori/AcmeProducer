using System;
using System.Collections.Generic;

namespace AcmeProducer.Model
{
    public partial class Fatura
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime? DataLeitura { get; set; }
        public DateTime? DataVencimento { get; set; }
        public string NumeroLeitura { get; set; }
        public decimal? ValorConta { get; set; }
        public int? IdInstalacao { get; set; }

        public virtual Instalacao IdInstalacaoNavigation { get; set; }
    }
}
