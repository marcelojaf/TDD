using System;
using Xunit;

namespace Calculadora.Tests
{
    public class CalculosTests
    {
        [Fact(DisplayName = "Calculo de Soma")]
        [Trait("Category", "Calculos Simples")]
        public void Calculadora_Adicionar_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(4, Calculos.Adicao(2, 2));
        }

        [Fact(DisplayName = "Calculo de Subtração")]
        [Trait("Category", "Calculos Simples")]
        public void Calculadora_Subtrair_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(2, Calculos.Subtracao(4, 2));
        }

        [Fact(DisplayName = "Calculo de Multiplicação")]
        [Trait("Category", "Calculos Simples")]
        public void Calculadora_Multiplicacao_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(4, Calculos.Multiplicacao(2, 2));
        }

        [Fact(DisplayName = "Calculo de Divisão")]
        [Trait("Category", "Calculos Simples")]
        public void Calculadora_Divisao_DeveRetornarResultadoCorreto()
        {
            Assert.Equal(4, Calculos.Divisao(8, 2));
        }

        [Fact(DisplayName = "Calculo de Divisão por Zero")]
        [Trait("Category", "Situações de Erro")]
        public void Calculadora_DivisaoPorZero_DeveRetornarException()
        {
            var exception = Assert.Throws<DivideByZeroException>(() => Calculos.Divisao(8, 0));
            Assert.Equal("Attempted to divide by zero.", exception.Message);
        }

        [Theory(DisplayName = "Validações de Divisão")]
        [Trait("Category", "Validações")]
        [InlineData(8,2,4)]
        [InlineData(16, 4, 4)]
        [InlineData(25, 5, 5)]
        public void Calculadora_DivisaoMultiplosNumeros_DeveRetornarSemErros(int v1, int v2, int r1)
        {
            Assert.Equal(r1, Calculos.Divisao(v1, v2));
        }
    }
}
