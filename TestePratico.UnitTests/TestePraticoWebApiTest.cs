using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestePratico.Api.Controllers;
using TestePratico.Domain;
using TestePratico.Domain.DTO;
using TestePratico.Infrastructure.DataContexts;
using Xunit;

namespace TestePratico.UnitTests
{
    public class TestePraticoWebApiTest
    {
        private readonly TestePraticoDataContext _context;

        public TestePraticoWebApiTest()
        {
            _context = new TestePraticoDataContext();
        }

        [Fact]
        public async Task Transfer_between_accounts_success()
        {
            //Arrange
            var transferenciaController = new TransferenciaController(_context);

            var transferencia = new TransferenciaDTO()
            {
                Origem = new ContaCorrente()
                {
                    Agencia = "5207",
                    NumeroConta = "000000000015489",
                    Digito = "02"
                },
                Destino = new ContaCorrente()
                {
                    Agencia = "9512",
                    NumeroConta = "000000000026841",
                    Digito = "12"
                },
                Valor = 300
            };

            //Act
            var actionResult = await transferenciaController.EnviaDinheiroAsync(transferencia) as OkResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task Transfer_between_accounts_bad_request()
        {
            //Arrange
            var transferenciaController = new TransferenciaController(_context);

            var transferencia = new TransferenciaDTO()
            {
                Origem = new ContaCorrente()
                {
                    Agencia = "5207",
                    NumeroConta = "000000000015489",
                    Digito = "02"
                },
                Destino = new ContaCorrente()
                {
                    Agencia = "9512",
                    NumeroConta = "000000000026841",
                    Digito = "12"
                },
                Valor = 3000
            };

            //Act
            var actionResult = await transferenciaController.EnviaDinheiroAsync(transferencia) as BadRequestResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Transfer_between_accounts_negative_value()
        {
            //Arrange
            var transferenciaController = new TransferenciaController(_context);

            var transferencia = new TransferenciaDTO()
            {
                Origem = new ContaCorrente()
                {
                    Agencia = "5207",
                    NumeroConta = "000000000015489",
                    Digito = "02"
                },
                Destino = new ContaCorrente()
                {
                    Agencia = "9512",
                    NumeroConta = "000000000026841",
                    Digito = "12"
                },
                Valor = -300
            };

            //Act
            var actionResult = await transferenciaController.EnviaDinheiroAsync(transferencia) as BadRequestResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Transfer_between_accounts_origem_not_exist()
        {
            //Arrange
            var transferenciaController = new TransferenciaController(_context);

            var transferencia = new TransferenciaDTO()
            {
                Origem = new ContaCorrente()
                {
                    Agencia = "3245",
                    NumeroConta = "0000000000012345",
                    Digito = "99"
                },
                Destino = new ContaCorrente()
                {
                    Agencia = "9512",
                    NumeroConta = "000000000026841",
                    Digito = "12"
                },
                Valor = 300
            };

            //Act
            var actionResult = await transferenciaController.EnviaDinheiroAsync(transferencia) as BadRequestResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Transfer_between_accounts_destino_not_exist()
        {
            //Arrange
            var transferenciaController = new TransferenciaController(_context);

            var transferencia = new TransferenciaDTO()
            {
                Origem = new ContaCorrente()
                {
                    Agencia = "5207",
                    NumeroConta = "000000000015489",
                    Digito = "02"
                },
                Destino = new ContaCorrente()
                {
                    Agencia = "1093",
                    NumeroConta = "000000000032654",
                    Digito = "99"
                },
                Valor = 300
            };

            //Act
            var actionResult = await transferenciaController.EnviaDinheiroAsync(transferencia) as BadRequestResult;

            //Assert
            Assert.Equal(actionResult.StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
        }
    }
}
