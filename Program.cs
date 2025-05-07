using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Juego de Preguntas y Respuestas";

        Console.WriteLine("🎮 Bienvenido al Juego de Preguntas y Respuestas");
        Console.Write("Por favor, ingresá tu nombre: ");
        string? nombre = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("⚠️ Nombre inválido. Cerrando juego...");
            return;
        }

        Jugador jugador = new Jugador(nombre);
        JuegoPreguntas juego = new JuegoPreguntas();

        juego.Iniciar(jugador);

        Console.WriteLine("\nGracias por jugar. ¡Hasta la próxima!");
        Console.ReadKey();
    }
}
