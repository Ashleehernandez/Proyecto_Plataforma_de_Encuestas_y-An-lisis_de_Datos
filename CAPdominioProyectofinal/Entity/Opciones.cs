

namespace CapDominio.Entity
{
    public class Opciones
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int PreguntaId { get; set; }
        public int EncuestaId { get; set; }

        // public virtual Preguntas Pregunta { get; set; }
    }
}
