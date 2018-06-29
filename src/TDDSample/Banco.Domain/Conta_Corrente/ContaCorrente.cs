
using Banco.Domain.Conta_Corrente.ValueObjects;
using System.Collections.Generic;

namespace Banco.Domain.Conta_Corrente
{
    public class ContaCorrente
    {
        private decimal Saldo { get; set; }
        private decimal SaldoBloqueado { get; set; }
        private decimal SaldoDisponivel { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ContaCorrente(decimal _saldo, decimal _saldoBloqueado, decimal _saldoDisponivel)
        {
            Saldo = _saldo;
            SaldoBloqueado = _saldoBloqueado;
            SaldoDisponivel = _saldoDisponivel;
            ValidationResult = new ValidationResult();
        }

        public ContaCorrente()
        {

        }

        public decimal ConsultarSaldo()
        {
            return ObterSaldoDisponivel();
        }

        private decimal ObterSaldoDisponivel()
        {
            SaldoDisponivel = Saldo - SaldoBloqueado;
            return SaldoDisponivel;
        }

        public RetornoTransacao Depositar(decimal valor)
        {
            if (!ValidarTransacao(valor, TipoTransacao.Deposito))
            {
                return new RetornoTransacao("Não foi possível efetuar o depósito.", TipoRetorno.Erro);
            }

            Saldo += valor;
            return new RetornoTransacao("Depósito efetuado com sucesso.", TipoRetorno.Sucesso);
        }

        private static RetornoTransacao ValidarValorTransacao(decimal valor)
        {
            if (valor == 0)
            {
                return new RetornoTransacao("Não é possível realizar transações de valores igual a 0.", TipoRetorno.Erro);
            }

            if (valor < 0)
            {
                return new RetornoTransacao("Não é possível realizar transações de valores negativos.", TipoRetorno.Erro);
            }

            return new RetornoTransacao("", TipoRetorno.Sucesso);
        }

        public RetornoTransacao Sacar(decimal valor)
        {
            if (!ValidarTransacao(valor, TipoTransacao.Saque))
            {
                return new RetornoTransacao("Não foi possível efetuar o saque.", TipoRetorno.Erro);
            }

            Saldo -= valor;
            return new RetornoTransacao("Saque efetuado com sucesso.", TipoRetorno.Sucesso);
        }

        private bool ValidarTransacao(decimal valor, TipoTransacao tipoTransacao)
        {
            if (valor == 0)
            {
                ValidationResult.AdicionarErro("Valor 0", "Não é possível realizar transações de valores igual a 0.");
            }

            if (valor < 0)
            {
                ValidationResult.AdicionarErro("Valor negativo","Não é possível realizar transações de valores negativos.");
            }

            if (tipoTransacao == TipoTransacao.Saque)
            {
                if (ObterSaldoDisponivel() < valor)
                {
                    ValidationResult.AdicionarErro("Saldo insuficiente", "Não é possível sacar um valor superior aos fundos.");
                }
            }

            return ValidationResult.IsValid();
        }
    }
}
