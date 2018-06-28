
using Banco.Domain.Conta_Corrente.ValueObjects;

namespace Banco.Domain.Conta_Corrente
{
    public class ContaCorrente
    {
        private decimal Saldo { get; set; }
        private decimal SaldoBloqueado { get; set; }
        private decimal SaldoDisponivel { get; set; }

        public ContaCorrente(decimal _saldo, decimal _saldoBloqueado, decimal _saldoDisponivel)
        {
            Saldo = _saldo;
            SaldoBloqueado = _saldoBloqueado;
            SaldoDisponivel = _saldoDisponivel;
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
            var retornoTransacao = ValidarValorTransacao(valor);
            if (retornoTransacao.Retorno != TipoRetorno.Sucesso)
            {
                return retornoTransacao;
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
            var retornoTransacao = ValidarValorTransacao(valor);
            if (retornoTransacao.Retorno != TipoRetorno.Sucesso)
            {
                return retornoTransacao;
            }

            if (ObterSaldoDisponivel() < valor)
            {
                return new RetornoTransacao("Não é possível sacar um valor superior aos fundos.", TipoRetorno.Erro);
            }

            Saldo -= valor;
            return new RetornoTransacao("Saque efetuado com sucesso.", TipoRetorno.Sucesso);
        }
    }
}
