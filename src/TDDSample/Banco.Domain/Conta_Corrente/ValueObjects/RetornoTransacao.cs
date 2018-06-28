
using System;

namespace Banco.Domain.Conta_Corrente.ValueObjects
{
    public class RetornoTransacao
    {
        public Guid NumeroTransacao { get; set; }
        public string Mensagem { get; set; }
        public TipoRetorno Retorno { get; set; }

        public RetornoTransacao(string _mensagem, TipoRetorno _retorno)
        {
            NumeroTransacao = Guid.NewGuid();
            Mensagem = _mensagem;
            Retorno = _retorno;
        }
    }

    public enum TipoRetorno
    {
        Sucesso = 0,
        Erro,
        Violacao
    }
}
