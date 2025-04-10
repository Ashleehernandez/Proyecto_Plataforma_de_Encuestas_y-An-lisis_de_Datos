using CapDominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPdominioProyectofinal.InterfaceServicio
{
    public interface IPreguntasServicio
    {
        Preguntas ObtenerPreguntaId(int id);
        IEnumerable<Preguntas> ObtenerTodo();
        Preguntas CrearPregunta(Preguntas pregunta);
        void ActualizarPregunta(Preguntas pregunta);
        void EliminarPregunta(int id);

        IEnumerable<Preguntas> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta);
        IEnumerable<Preguntas> ObtenerPorEncuestaId(int encuestaId);
    }
}
