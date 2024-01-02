namespace Programación_Funcional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculadora");
            Console.WriteLine("--------------------------------\n");

            while (true)
            {
                Console.Write("Ingrese la operación (por ejemplo, 5 + 3): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                try
                {
                    var resultado = RealizarOperacion(input);
                    Console.WriteLine($"Resultado: {resultado}\n");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: No se puede dividir entre cero.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n");
                }
            }
        }

        static Func<double, double, double> ObtenerOperacion(string operador)
        {
            switch (operador)
            {
                case "+": return (a, b) => a + b;
                case "-": return (a, b) => a - b;
                case "*": return (a, b) => a * b;
                case "/": return (a, b) => a / b;
                default: throw new ArgumentException("Operador no válido");
            }
        }

        static double RealizarOperacion(string input)
        {
            var partes = input.Split(' ');
            if (partes.Length != 3)
                throw new ArgumentException("Formato de entrada no válido");

            double num1 = double.Parse(partes[0]);
            string operador = partes[1];
            double num2 = double.Parse(partes[2]);

            if (operador == "/" && num2 == 0)
            {
                throw new DivideByZeroException();
            }

            var operacion = ObtenerOperacion(operador);
            return operacion(num1, num2);
        }
    }
}
