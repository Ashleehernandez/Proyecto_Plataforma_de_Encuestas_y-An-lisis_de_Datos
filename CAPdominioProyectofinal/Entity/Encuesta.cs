
using System.Text.Json.Serialization;

namespace CapDominio.Entity
{

    public class Encuesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsPublica { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public EstadoEncuesta Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Preguntas> Preguntas { get; set; }

    }
    public enum EstadoEncuesta
    {
        Activa,
        Inativa

    }
}


