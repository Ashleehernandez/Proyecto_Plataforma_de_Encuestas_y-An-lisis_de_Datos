using System.Collections.Generic;

public class Usuario
{
    public int IdUsuario { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contrasena { get; set; }
    public string Rol { get; set; }
    public DateTime FechaRegistro { get; set; }

    [JsonIgnore]
    public ICollection<Cuenta> Cuentas { get; set; }
    [JsonIgnore]
    public ICollection<Respuestas> respuestas { get; set; }
}
