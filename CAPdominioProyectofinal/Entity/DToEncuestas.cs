

namespace CapDominio.Entity
{
    public class DToEncuestas
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool EsPublica { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int UsuarioId { get; set; }
        public List<PreguntaDto> Preguntas { get; set; }
    }
}
