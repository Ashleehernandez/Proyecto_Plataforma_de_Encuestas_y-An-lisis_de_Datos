﻿using CapDominio.Entity;

public class Preguntas
{
    public int Id { get; set; }
    public string Texto { get; set; }
    public TipoPregunta TipoPregunta { get; set;  }
    public int EncuestaId { get; set; } = 5;
    //public int Min { get; set; } = 1;
    //public int Max { get; set; } = 100;
    // Para preguntas de opción múltiple
    //public virtual ICollection<Opciones> Opciones { get; set; }

    // Para preguntas de escala
    public int? EscalaMin { get; set; }
    public int? EscalaMax { get; set; }

    // Relaciones
    public virtual Encuesta Encuesta { get; set; }
    public virtual ICollection<Respuestas> Respuestas { get; set; }
    public int UsuarioId { get; set; }
}
 

    public enum TipoPregunta
    {
        OpcionMultiple,
        EscalaCalificacion
    }

