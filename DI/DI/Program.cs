namespace DI
{
    public interface INotificador
    {
        void Enviar(string mensaje);
    }

    public class NotificadorSMS : INotificador
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando SMS: {mensaje}");
        }
    }

    public class NotificadorEmail : INotificador
    {
        public void Enviar(string mensaje)
        {
            Console.WriteLine($"Enviando Email: {mensaje}");
        }
    }

    public class ServicioNotificacion
    {
        private readonly INotificador _notificador;

        public ServicioNotificacion (INotificador notificador)
        {
            _notificador = notificador;
        }

        public void NotificarUsuario(string mensaje)
        {
            _notificador.Enviar(mensaje);
        }
    }

    public class Program
    {
        static void Main()
        {
            INotificador notificador = new NotificadorSMS();
            ServicioNotificacion servicioNotificacion = new ServicioNotificacion(notificador);

            servicioNotificacion.NotificarUsuario("Hola desde el sistema, paga lo que debes");
        }
    }
}