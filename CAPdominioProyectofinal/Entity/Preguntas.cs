using CapDominio.Entity;

public class Preguntas
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public TipoPregunta TipoPregunta { get; set; }
    public int EncuestaId { get; set; }

    // Para preguntas de opción múltiple
    public virtual ICollection<Opcion> Opciones { get; set; }

    // Para preguntas de escala
    public int? EscalaMin { get; set; }
    public int? EscalaMax { get; set; }

    // Relaciones
    public virtual Encuesta Encuesta { get; set; }
    public virtual ICollection<Respuestas> Respuestas { get; set; }
    public int UsuarioId { get; set; }
}

public class Opcion
    {
        public int Id { get; set; }
        public string Texto { get; set; } // Texto de la opción
    }

    public class EscalaCalificacion
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public enum TipoPregunta
    {
        OpcionMultiple,
        EscalaCalificacion
    }

