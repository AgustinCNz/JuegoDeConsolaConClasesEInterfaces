using System;
using System.Text.Json;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("🎮 ¡Bienvenido al Juego de Preguntas!");
        Console.Write("Por favor, ingresá tu nombre: ");
        string nombre = Console.ReadLine() ?? "Jugador";

        Jugador jugador = new Jugador
        {
            Nombre = nombre,
            Puntaje = 0,
            Respuestas = new()
        };

        JuegoPreguntas juego = new JuegoPreguntas();
        juego.Iniciar(jugador);
    }
}
