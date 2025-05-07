using System.Text.Json;

public class JuegoPreguntas
{
    private List<Pregunta> preguntas;

    public JuegoPreguntas()
    {
        string json = File.ReadAllText("Preguntas.json");
        preguntas = JsonSerializer.Deserialize<List<Pregunta>>(json) ?? new List<Pregunta>();
    }

    public void Iniciar(Jugador jugador)
    {
        Console.WriteLine($"\n🎯 Bienvenido {jugador.Nombre} al juego de preguntas!");
        string[] categorias = { "Naturaleza", "Clima", "Arte", "Países", "Espacio", "Plantas" };

        int rondas = 5;
        Random rnd = new Random();

        for (int i = 0; i < rondas; i++)
        {
            Console.WriteLine($"\nRonda {i + 1}: Presione Enter para tirar el dado...");
            Console.ReadKey();

            int dado = rnd.Next(1, 7); // 1 a 6
            string categoriaSeleccionada = categorias[dado - 1];
            Console.WriteLine($"🎲 Dado: {dado} → Categoría: {categoriaSeleccionada}");

            var preguntasCategoria = preguntas.Where(p => p.Categoria == categoriaSeleccionada).ToList();
            if (preguntasCategoria.Count == 0)
            {
                Console.WriteLine("⚠️ No hay preguntas en esta categoría.");
                continue;
            }

            Pregunta pregunta = preguntasCategoria[rnd.Next(preguntasCategoria.Count)];

            // Mostrar pregunta
            Console.WriteLine($"\n🧠 {pregunta.Enunciado}");
            Console.WriteLine($"1. {pregunta.Respuesta1}");
            Console.WriteLine($"2. {pregunta.Respuesta2}");
            Console.WriteLine($"3. {pregunta.Respuesta3}");
            Console.WriteLine($"4. {pregunta.Respuesta4}");

            int puntos = 0;
            bool acertado = false;

            for (int intento = 1; intento <= 2; intento++)
            {
                Console.Write("\nIngrese el número de su respuesta (1 a 4): ");
                string ? respuestaNum = Console.ReadLine();
                string? respuestaElegida = respuestaNum switch
                {
                    "1" => pregunta.Respuesta1,
                    "2" => pregunta.Respuesta2,
                    "3" => pregunta.Respuesta3,
                    "4" => pregunta.Respuesta4,
                    _ => null
                };

                if (respuestaElegida == null)
                {
                    Console.WriteLine("❌ Opción inválida.");
                    intento--; // No cuenta intento inválido
                    continue;
                }

                if (respuestaElegida == pregunta.RespuestaCorrecta)
                {
                    puntos = intento == 1 ? 2 : 1;
                    jugador.Puntaje += puntos;
                    Console.WriteLine($"✅ ¡Correcto! +{puntos} puntos");
                    acertado = true;
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Incorrecto");
                }
            }

            if (!acertado)
                Console.WriteLine($"😢 La respuesta correcta era: {pregunta.RespuestaCorrecta}");

            jugador.Respuestas.Add((pregunta, acertado ? pregunta.RespuestaCorrecta : "Sin acierto", puntos));
        
            
        }
        MostrarResultado(jugador);

    }
                private void MostrarResultado(Jugador jugador)
            {
                Console.WriteLine("\n📋 RESULTADOS FINALES");
                Console.WriteLine("------------------------");

                foreach (var respuesta in jugador.Respuestas)
                {
                    var pregunta = respuesta.pregunta;
                    var respuestaDada = respuesta.respuesta;
                    var puntos = respuesta.puntos;

                    Console.WriteLine($"\n🔹 Pregunta: {pregunta.Enunciado}");
                    Console.WriteLine($"Categoría: {pregunta.Categoria}");
                    Console.WriteLine($"Respuesta correcta: {pregunta.RespuestaCorrecta}");
                    Console.WriteLine($"Tu respuesta: {respuestaDada}");
                    Console.WriteLine($"Puntos obtenidos: {puntos}");
                }

                Console.WriteLine($"\n🎯 Puntaje final de {jugador.Nombre}: {jugador.Puntaje} puntos");
            
                Console.WriteLine("\n🏆 PREMIO FINAL");

                    if (jugador.Puntaje >= 8 && jugador.Puntaje <= 10)
                    {
                        Console.WriteLine("🎉 ¡Felicitaciones! Ganaste un viaje virtual al conocimiento. ¡Sos un genio!");
                    }
                    else if (jugador.Puntaje >= 4 && jugador.Puntaje < 8)
                    {
                        Console.WriteLine("💪 Buen trabajo. Estás en el camino correcto, seguí así.");
                    }
                    else
                    {
                        Console.WriteLine("🔥 No te rindas. Jugá otra vez y demostrá de lo que sos capaz.");
                    }

            }

}
