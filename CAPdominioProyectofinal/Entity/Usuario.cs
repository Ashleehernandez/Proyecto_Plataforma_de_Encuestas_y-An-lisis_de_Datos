
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CapDominio.Entity
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Contrasena { get; set; }  
        public string Rol { get; set; }
        public DateTime FechaRegistro { get; set; }


        [JsonIgnore]
        public ICollection<Respuestas> respuestas { get; set; } = new List<Respuestas>();

        [JsonIgnore]
        public ICollection<Encuesta> Cuentas { get; set; } = new List<Encuesta>();
    }
    public enum Rol
    {
        Administrador,
        UsuarioEstandar

    }
}
