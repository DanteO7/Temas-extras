using System.Security.Cryptography.X509Certificates;

namespace Delegados
{

    public delegate void MiDelegado(string mensaje);
    public delegate int Operacion(int a, int b);
    public delegate void NotificarEvento();

    public class Sistema
    {
        public static void EventoUno()
        {
            Console.WriteLine("Ejecutando evento uno...");
        }

        public static void EventoDos()
        {
            Console.WriteLine("Ejecutando evento dos...");
        }

        public static void EventoTres()
        {
            Console.WriteLine("Ejecutando evento tres...");
        }
    }

    public class Calculadora
    {
        public static int Sumar(int a, int b) => a + b;

        public static int Restar(int a, int b) => a - b;

        public static void EjecutarOperacion(Operacion operacion, int a, int b)
        {
            int resultado = operacion(a, b);
            Console.WriteLine($"Resultado: {resultado}");
        }
    }

    public class Program
    {
        static void Main()
        {
            Ejemplo3();
        }

        static void Ejemplo1()
        {
            void MostrarMensajeEnMayus(string mensaje)
            {
                Console.WriteLine($"Mensaje mostrado: {mensaje.ToUpper()}");
            }

            void MostrarMensaje(string mensaje)
            {
                Console.WriteLine($"Mensaje mostrado: {mensaje}");
            }

            MiDelegado delegado = MostrarMensaje;

            delegado("Hola mundo!");

            delegado = MostrarMensajeEnMayus;

            delegado("Hola mundo en mayus!");
        }

        static void Ejemplo2()
        {
            Operacion operacionSuma = Calculadora.Sumar;
            Operacion operacionResta = Calculadora.Restar;

            Calculadora.EjecutarOperacion(operacionSuma, 10, 5);
            Calculadora.EjecutarOperacion(operacionResta, 10, 5);
        }

        static void Ejemplo3()
        {
            NotificarEvento eventos = Sistema.EventoUno;

            eventos += Sistema.EventoDos;
            eventos += Sistema.EventoTres;

            eventos();
        }
    }
}