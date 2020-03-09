using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestePratico.Domain;
using TestePratico.Domain.DTO;
using TestePratico.Infrastructure.DataContexts;

namespace TestePratico.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly TestePraticoDataContext _context;

        public TransferenciaController(TestePraticoDataContext context)
        {
            _context = context;
        }

        [Route("envio")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EnviaDinheiroAsync([FromBody] TransferenciaDTO transferencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                transferencia.Origem.Id = _context.ContasCorrentes.Where(x => x.Agencia == transferencia.Origem.Agencia
                            && x.NumeroConta == transferencia.Origem.NumeroConta
                            && x.Digito == transferencia.Origem.Digito).FirstOrDefault().Id;

                transferencia.Destino.Id = _context.ContasCorrentes.Where(x => x.Agencia == transferencia.Destino.Agencia
                            && x.NumeroConta == transferencia.Destino.NumeroConta
                            && x.Digito == transferencia.Destino.Digito).FirstOrDefault().Id;

                var saldo = _context.Lancamentos.Where(x => x.ContaCorrenteId == transferencia.Origem.Id)
                            .Sum(x => x.Valor);

                if (saldo <= 0 || transferencia.Valor <= 0 || saldo < transferencia.Valor)
                {
                    return BadRequest();
                }

                var lancamentoDebito = new Lancamento()
                {
                    Id = Guid.NewGuid(),
                    ContaCorrenteId = transferencia.Origem.Id,
                    TipoOperacao = "Debito",
                    Valor = -transferencia.Valor,
                    DataOperacao = DateTime.UtcNow
                };

                var lancamentoCredito = new Lancamento()
                {
                    Id = Guid.NewGuid(),
                    ContaCorrenteId = transferencia.Destino.Id,
                    TipoOperacao = "Credito",
                    Valor = transferencia.Valor,
                    DataOperacao = DateTime.UtcNow
                };

                var lancamentos = new List<Lancamento>() { lancamentoDebito, lancamentoCredito };

                var transfer = _context.Lancamentos.AddRangeAsync(lancamentos).IsCompletedSuccessfully;

                if (!transfer)
                {
                    return BadRequest();
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}