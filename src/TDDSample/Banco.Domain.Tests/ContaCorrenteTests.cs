
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
        // AAA
        [Fact(DisplayName = "Consultar Saldo")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_ConsultarSaldo_SaldoDeveEstarConsistente()
        {
            // Arrange
            var conta = new ContaCorrente(100M, 50M, 50M);

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
            var saldoInicial = 100M;
            var conta = new ContaCorrente(saldoInicial, 0, saldoInicial);
            var deposito = 100M;

            // Act
            var transacao = conta.Depositar(deposito);

            // Assert
            var saldo = conta.ConsultarSaldo();
            Assert.Equal(deposito + saldoInicial, saldo);
            Assert.Equal("Depósito efetuado com sucesso.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.Retorno);
        }

        [Fact(DisplayName = "Depositar Dinheiro com Valor 0")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_DepositarDinheiroValorZero_ValidarTransacaoComFalha()
        {
            // Arrange
            var saldoInicial = 100M;
            var conta = new ContaCorrente(saldoInicial, 0, saldoInicial);
            var deposito = 0M;

            // Act
            var transacao = conta.Depositar(deposito);

            // Assert
            var saldo = conta.ConsultarSaldo();
            Assert.Equal(deposito + saldoInicial, saldo);
            Assert.Equal("Não é possível realizar transações de valores igual a 0.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiro_ValidarTransacaoComSucesso()
        {
            // Arrange
            var saldoInicial = 100M;
            var conta = new ContaCorrente(saldoInicial, 0, saldoInicial);
            var saque = 50M;

            // Act
            var transacao = conta.Sacar(saque);

            // Assert
            Assert.Equal(saldoInicial - saque, conta.ConsultarSaldo());
            Assert.Equal("Saque efetuado com sucesso.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Sucesso, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro Acima do Limite")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiro_ValidarTransacaoComFalha()
        {
            // Arrange
            var saldoInicial = 100M;
            var conta = new ContaCorrente(saldoInicial, 0, saldoInicial);
            var saque = 500M;

            // Act
            var transacao = conta.Sacar(saque);

            // Assert
            Assert.Equal(saldoInicial, conta.ConsultarSaldo());
            Assert.Equal("Não é possível sacar um valor superior aos fundos.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

        [Fact(DisplayName = "Sacar Dinheiro Valor Negativo")]
        [Trait("Category", "Operações de Conta Corrente")]
        public void ContaCorrente_SacarDinheiroValorNegativo_ValidarTransacaoComFalha()
        {
            // Arrange
            var saldoInicial = 100M;
            var conta = new ContaCorrente(saldoInicial, 0, saldoInicial);
            var saque = -100M;

            // Act
            var transacao = conta.Sacar(saque);

            // Assert
            Assert.Equal(saldoInicial, conta.ConsultarSaldo());
            Assert.Equal("Não é possível realizar transações de valores negativos.", transacao.Mensagem);
            Assert.Equal(TipoRetorno.Erro, transacao.Retorno);
        }

    }
}
