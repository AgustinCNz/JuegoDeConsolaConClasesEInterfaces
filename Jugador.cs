public class Jugador : IJugador
{
    public string Nombre { get; set; }
    public int Puntaje { get; set; }
    public List<(Pregunta pregunta, string respuesta, int puntos)> Respuestas { get; set; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Puntaje = 0;
        Respuestas = new List<(Pregunta, string, int)>();
    }
}
