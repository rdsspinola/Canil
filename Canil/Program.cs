using System;
using System.Globalization;

namespace Canil
{
    class Program
    {
        private static CalculaMenorPreco calculo;

        static void Main(string[] args)
        {
            calculo = new CalculaMenorPreco();
            ValidaEntrada(args);

            var a = new CalculaMenorPreco();

            Console.WriteLine(calculo.CalculaMelhorOferta());
        }

        private static void ValidaEntrada(string[] args)
        {
            DateTime data;
            int qtcaespequenos, qtcaesgrandes;
            string diasemana;

            if (args.Length != 3) { throw new Exception("Número incorreto de argumentos"); }


            if (!DateTime.TryParse(args[0], new CultureInfo("pt-BR"), DateTimeStyles.None, out data))
            {
                throw new Exception("A data informada é inválida");
            }

            if (!int.TryParse(args[1], out qtcaespequenos)) { throw new Exception("O número de cães pequenos informado não é válido"); }
            if (!int.TryParse(args[2], out qtcaesgrandes)) { throw new Exception("O número de cães grandes informado não é válido"); }

            diasemana = (((int)data.DayOfWeek) + 1).ToString();

            calculo.data = data;
            calculo.qtcaespequenos = qtcaespequenos;
            calculo.qtcaesgrandes = qtcaesgrandes;
            calculo.diasemana = diasemana;
        }
    }
}
