using System.Text.Json.Serialization;
namespace CapDominio.Entity
{
    public class Respuestas
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } 
        public int PreguntaId { get; set; } 
        public string RespuestaTexto { get; set; } 
        public string RespuestaSeleccionada { get; set; } 
        public int Puntaje { get; set; } 
        public DateTime FechaRespuesta { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public Preguntas Pregunta { get; set; }
        public int EncuentaId { get; set; }
    }
}
