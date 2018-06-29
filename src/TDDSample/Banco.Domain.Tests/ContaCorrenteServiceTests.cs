
using Banco.Domain.Conta_Corrente;
using Banco.Domain.Conta_Corrente.Repository.Interfaces;
using Banco.Domain.Conta_Corrente.Services;
using Banco.Domain.Conta_Corrente.ValueObjects;
using Moq;
using Xunit;

namespace Banco.Domain.Tests
{
    public class ContaCorrenteServiceTests
    {
        [Fact(DisplayName ="Deposito em Conta")]
        [Trait("Category", "Operações ContaCorrenteService")]
        public void ContaService_RealizarDeposito_ValidarTransacaoComSucesso()
        {
            // Arrange
            var conta = new ContaCorrente(100, 0, 100);
            var deposito = 500M;
            var repo = new Mock<IContaCorrenteRepository>();

            // Quando chamar o método ObterContaPorNumer com parametro 01234, retorna o object conta criado anteriormente
            repo.Setup(r => r.ObterContaPorNumero("01234")).Returns(conta);

            var contaService = new ContaCorrenteService(repo.Object);

            // Act
            var transacao = contaService.EfetuarDeposito("01234", deposito);

            // Assert
            repo.Verify(r => r.Atualizar(conta), Times.Once);
            Assert.Equal("Depósito efetuado com sucesso.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.Retorno);
        }
    }
}
