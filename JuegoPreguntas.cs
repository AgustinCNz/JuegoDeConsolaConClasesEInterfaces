using System.Runtime.CompilerServices;
using System.Text.Json;
public class JuegoPreguntas
{
// Constructor
private List<Pregunta> preguntas;
public JuegoPreguntas()
{
    string json = File.ReadAllText("Preguntas.json");
    preguntas = JsonSerializer.Deserialize<List<Pregunta>>(json) ?? new List<Pregunta>();
}

// Método principal del juego
public void Iniciar(Jugador jugador)
{
    
    Console.WriteLine($"🎯 ¡Hola {jugador.Nombre}! Empezamos el juego...");

        Random rnd = new Random();
        int dado = rnd.Next(1, 7); // 1 a 6

        string[] categorias = { "Geografia", "Historia", "Ciencia", "Matematica", "Deportes", "Entretenimiento" };
        string categoria = categorias[dado - 1];

        Console.WriteLine($"🎲 Te tocó la categoría: {categoria}");
    
}

// Método privado para mostrar el resultado final
private void MostrarResultado(Jugador jugador){}
}