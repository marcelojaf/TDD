
using Banco.Domain.Conta_Corrente.Repository.Interfaces;
using Banco.Domain.Conta_Corrente.Services.Interfaces;
using Banco.Domain.Conta_Corrente.ValueObjects;

namespace Banco.Domain.Conta_Corrente.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public RetornoTransacao EfetuarDeposito(string numeroConta, decimal valor)
        {
            var conta = _contaCorrenteRepository.ObterContaPorNumero(numeroConta);

            var transacao = conta.Depositar(valor);
            if (transacao.Retorno == TipoRetorno.Sucesso)
            {
                _contaCorrenteRepository.Atualizar(conta);
            }

            return transacao;
        }
    }
}
