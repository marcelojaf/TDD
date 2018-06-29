using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Domain.Conta_Corrente.Repository.Interfaces
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente ObterContaPorNumero(string numeroConta);
        void Atualizar(ContaCorrente contaCorrente);
    }
}
