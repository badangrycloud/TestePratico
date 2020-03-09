using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestePratico.Domain.DTO
{
    [NotMapped]
    public class TransferenciaDTO
    {
        public ContaCorrente Origem { get; set; }
        public ContaCorrente Destino { get; set; }
        public decimal Valor { get; set; }
    }
}
