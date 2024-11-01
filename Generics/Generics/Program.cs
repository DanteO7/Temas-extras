namespace Generics
{
    public class Almacen<T>
    {
        private T _item;

        public void Guardar(T nuevoItem)
        {
            _item = nuevoItem;
            Console.WriteLine($"Item guardado: {_item}");
        }

        public T Obtener()
        {
            return _item;
        }
    }

    // T != any

    public class Utilidades
    {
        public static void Intercambiar<T>(ref T a,ref T b)
        {
            T temporal = a;
            a = b;
            b = temporal;
        }
    }

    public delegate T Operacion<T>(T valor1, T valor2);

    public class Calculadora
    {
        public static int Sumar(int a, int b) => a + b;

        public static string Concatenar(string a, string b) => a + " " + b;


    }

    public class Program
    {
        static void Main()
        {
            Ejemplo3();
        }

        static void Ejemplo1()
        {
            Almacen<int> almacenEnteros = new();
            almacenEnteros.Guardar(2);
            Console.WriteLine($"Item recuperado: {almacenEnteros.Obtener()}");

            Almacen<string> almacenTexto = new();
            almacenTexto.Guardar("Hola generics!");
            Console.WriteLine($"Item recuperado: {almacenTexto.Obtener()}");
        }

        static void Ejemplo2()
        {
            int x = 10;
            int y = 20;

            Console.WriteLine($"Antes de intercambiar: X = {x}, Y = {y}");
            Utilidades.Intercambiar(ref x,ref y);
            Console.WriteLine($"despues de intercambiar: X = {x}, Y = {y}");

            string str1 = "Hola";
            string str2 = "Mundo";

            Console.WriteLine($"Antes de intercambiar: str1 = {str1}, str2 = {str2}");
            Utilidades.Intercambiar(ref str1, ref str2);
            Console.WriteLine($"despues de intercambiar: str1 = {str1}, str2 = {str2}");
        }

        static void Ejemplo3()
        {
            Operacion<int> operacionSuma = Calculadora.Sumar;
            Console.WriteLine($"Suma de enteros: {operacionSuma(5,11)}\n");

            Operacion<string> operacionConcatenar = Calculadora.Concatenar;
            Console.WriteLine($"Concatenación de cadenas: {operacionConcatenar("Hola","Mundo")}");
        }
    }
}


//public interface IRepository<T> where T : class
//{
//    IEnumerable<T> ObtenerTodos();
//    T ObtenerUno();
//    T Actualizar(T entidad);
//    T Crear(T entidad);
//    void Eliminar(T entidad);
//}
//public class Repository<T> : IRepository<T> where T : class
//{
//    private List<T> lista = new List<T>();

//    public T Actualizar(T entidad)
//    {
//        lista.Remove(entidad);
//        lista.Add(entidad);
//        return entidad;
//    }

//    public T Crear(T entidad)
//    {
//        lista.Add(entidad);
//        return entidad;
//    }

//    public void Eliminar(T entidad)
//    {
//        lista.Remove(entidad);
//    }

//    public IEnumerable<T> ObtenerTodos()
//    {
//        return lista;
//    }

//    public T ObtenerUno()
//    {
//        return lista.First();
//    }
//}

//public interface ILibroRepository : IRepository<string> { }
//public class LibroRepository : Repository<string>, ILibroRepository { }
 