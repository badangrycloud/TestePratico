using System;
using System.Collections.Generic;
using System.Text;

namespace TestePratico.Domain
{
    public class Lancamento
    {
        public Guid Id { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public string TipoOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
        public decimal Valor { get; set; }

    }
}
