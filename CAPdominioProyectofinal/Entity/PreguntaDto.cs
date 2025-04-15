namespace CapDominio.Entity
{
    public class PreguntaDto
    {
        public string Texto { get; set; }
        public TipoPregunta TipoPregunta { get; set; }
        public int EncuestaId { get; set; }
        public int UsuarioId { get; set; }
        //public List<string> Opciones { get; set; } 
        public int? EscalaMin { get; set; }
        public int? EscalaMax { get; set; }
    }
}
