
using Banco.Domain.Conta_Corrente;
using Banco.Domain.Conta_Corrente.ValueObjects;
using Xunit;

namespace Banco.Domain.Tests
{
    // Classe que simula uma conta bancária

    // Consultar o saldo
    // Depositar dinheiro
    // Sacar o dinheiro
    // Não permitir saque superior aos fundos
    // Não permitir saque de valor negativo

    // Conta com CH especial

    public class ContaCorrenteTests
    {
        private readonly ContaCorrente _conta;
        private readonly decimal _saldoInicial;

        public ContaCorrenteTests()
        {
            _saldoInicial = 100M;
            _conta = new ContaCorrente(_saldoInicial, 0M, 100M);
        }

        // AAA
        [Fact(DisplayName = "Consultar Saldo")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_ConsultarSaldo_SaldoDeveEstarConsistente()
        {
            // Arrange
            var conta = new ContaCorrente(_saldoInicial, 50M, 50M);

            // Act
            var saldo = conta.ConsultarSaldo();

            // Assert
            Assert.Equal(50M, saldo);
        }

        [Fact(DisplayName = "Depositar Dinheiro")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_DepositarDinheiro_ValidarTransacaoComSucesso()
        {
            // Arrange
            var deposito = 100M;

            // Act
            var transacao = _conta.Depositar(deposito);

            // Assert
            var saldo = _conta.ConsultarSaldo();
            Assert.Equal(deposito + _saldoInicial, saldo);
            Assert.Equal("Depósito efetuado com sucesso.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.Retorno);
        }

        [Fact(DisplayName = "Depositar Dinheiro com Valor 0")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_DepositarDinheiroValorZero_ValidarTransacaoComFalha()
        {
            // Arrange
            var deposito = 0M;

            // Act
            var transacao = _conta.Depositar(deposito);

            // Assert
            Assert.Equal(deposito + _saldoInicial, _conta.ConsultarSaldo());
            Assert.Equal("Não foi possível efetuar o depósito.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiro_ValidarTransacaoComSucesso()
        {
            // Arrange
            var saque = 50M;

            // Act
            var transacao = _conta.Sacar(saque);

            // Assert
            Assert.Equal(_saldoInicial - saque, _conta.ConsultarSaldo());
            Assert.Equal("Saque efetuado com sucesso.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro Acima do Limite")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiroAcimaDoLimite_ValidarTransacaoComFalha()
        {
            // Arrange
            var saque = 500M;

            // Act
            var transacao = _conta.Sacar(saque);

            // Assert
            Assert.Equal(_saldoInicial, _conta.ConsultarSaldo());
            Assert.Equal("Não foi possível efetuar o saque.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro Valor Negativo")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiroValorNegativo_ValidarTransacaoComFalha()
        {
            // Arrange
            var saque = -100M;

            // Act
            var transacao = _conta.Sacar(saque);

            // Assert
            Assert.Equal(_saldoInicial, _conta.ConsultarSaldo());
            Assert.Equal("Não foi possível efetuar o saque.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

    }
}
