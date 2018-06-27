namespace Calculadora
{
    public class Calculos
    {
        public static int Adicao(int v1, int v2)
        {
            return v1 + v2;
        }

        public static int Subtracao(int v1, int v2)
        {
            return v1 - v2;
        }

        public static int Multiplicacao(int v1, int v2)
        {
            return v1 *v2;
        }

        public static int Divisao(int v1, int v2)
        {
            return v1 / v2;
        }

        public static bool EhImpar(int v1)
        {
            return v1 % 2 != 0;
        }
    }
}
