using Banco.Domain.Conta_Corrente.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco.Domain.Conta_Corrente.Services.Interfaces
{
    public interface IContaCorrenteService
    {
        RetornoTransacao EfetuarDeposito(string numeroConta, decimal valor);
    }
}
