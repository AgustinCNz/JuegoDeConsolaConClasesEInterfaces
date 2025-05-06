public class Jugador : IJugador
{
    public required string Nombre { get; set; }
    public int Puntaje { get; set;}
    public List<(Pregunta pregunta, string respuesta, int puntos )> Respuestas {get ; set;}= new (); // Inicializar la lista en el constructor
}
