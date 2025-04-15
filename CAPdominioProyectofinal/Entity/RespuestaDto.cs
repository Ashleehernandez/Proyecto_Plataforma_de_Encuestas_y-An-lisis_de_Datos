namespace CapDominio.Entity
{
    public class RespuestaDto
    {
        public int Id { get; set; } 
        public int UsuarioId { get; set; }
        public int PreguntaId { get; set; }
        public string RespuestaTexto { get; set; }
        public string RespuestaSeleccionada { get; set; }
        public int Puntaje { get; set; }
    }
}
