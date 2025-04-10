using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapDominio.Entity
{
    public class RespuestaDto
    {
        public int Id { get; set; } // Opcional para la actualización
        public int UsuarioId { get; set; }
        public int PreguntaId { get; set; }
        public string RespuestaTexto { get; set; }
        public string RespuestaSeleccionada { get; set; }
        public int Puntaje { get; set; }
    }
}
