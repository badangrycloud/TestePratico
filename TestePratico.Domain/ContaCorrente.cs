using System;
using System.Collections.Generic;

namespace TestePratico.Domain
{
    public class ContaCorrente
    {
        public Guid Id { get; set; }
        public string Agencia { get; set; }
        public string NumeroConta { get; set; }
        public string Digito { get; set; }
        public virtual List<Lancamento> Lancamentos { get; set; }
    }
}
