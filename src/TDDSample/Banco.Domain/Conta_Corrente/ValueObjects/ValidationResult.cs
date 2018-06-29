using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco.Domain.Conta_Corrente.ValueObjects
{
    public class ValidationResult
    {
        public Dictionary<string, string> Erros { get; set; }

        public ValidationResult()
        {
            Erros = new Dictionary<string, string>();
        }

        public void AdicionarErro(string erro, string mensagemErro)
        {
            Erros.Add(erro, mensagemErro);
        }

        public bool IsValid()
        {
            return !Erros.Any();
        }
    }
}
