namespace linq.Models
{
    public class Program
    {
        static void Main()
        {
            Ejemplo4();
        }

        static void Ejemplo1()
        {
            List<Producto> productos = new List<Producto>
            {
                new Producto{ Id = 1, Nombre = "Camiseta", Precio = 25 },
                new Producto{ Id = 2, Nombre = "Pantalon", Precio = 55 },
                new Producto{ Id = 3, Nombre = "Zapatos", Precio = 75 },
                new Producto{ Id = 4, Nombre = "Sombrero", Precio = 30 },
            };

            var productosFiltrados = from p in productos
                                     where p.Precio > 50
                                     orderby p.Nombre ascending
                                     select p;

            foreach (var p in productosFiltrados)
            {
                Console.WriteLine($"{p.Nombre} - {p.Precio:C}");
            }
        }
        static void Ejemplo2()
        {
            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante{ Nombre  = "Juan", Calificacion = 100 },
                new Estudiante{ Nombre  = "Pedro", Calificacion = 100 },
                new Estudiante{ Nombre = "Luis", Calificacion = 88 },
                new Estudiante{ Nombre = "Ana", Calificacion = 92 },
                new Estudiante{ Nombre = "Maria", Calificacion = 74 },
                new Estudiante{ Nombre = "Carlos", Calificacion = 50 },
            };

            var estudiantesPorCalificacion = from est in estudiantes
                                             group est by est.Calificacion into grupo
                                             select grupo;

            foreach (var grupo in estudiantesPorCalificacion)
            {
                Console.WriteLine($"Calificacion: {grupo.Key}");
                foreach (var estudiante in grupo)
                {
                    Console.WriteLine($"Estudiante: {estudiante.Nombre}");
                }
            }
        }

        static void Ejemplo3()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente{ Id = 1, Nombre = "Pedro" },
                new Cliente{ Id = 2, Nombre = "Ana"},
                new Cliente{ Id = 3, Nombre = "Julia"},
            };

            List<Pedido> pedidos = new List<Pedido>
            {
                new Pedido{Id = 1, Cliente_id = 1, Producto = "Libro"},
                new Pedido{Id = 2, Cliente_id = 3, Producto = "Pala" },
                new Pedido{Id = 3, Cliente_id = 2, Producto = "Tabla"},
                new Pedido{Id = 4, Cliente_id = 1, Producto = "Cuadernillo"},
            };

            var pedidosClientes = from c in clientes
                                  join p in pedidos on c.Id equals p.Cliente_id
                                  select new { c.Nombre, p.Producto };

            foreach (var item in pedidosClientes)
            {
                Console.WriteLine($"{item.Nombre} ha comprado un(a) {item.Producto}");
            }
        }

        static void Ejemplo4()
        {
            List<string> nombres = new List<string>
            {
                "Ana",
                "Luis",
                "Carlos",
                "Luis",
                "Sofia",
                "Ana"
            };

            var nombresUnicos = (from nombre in nombres
                                select nombre).Distinct();

            foreach(var nombre in nombresUnicos)
            {
                Console.WriteLine(nombre);
            }
        }
    }
}