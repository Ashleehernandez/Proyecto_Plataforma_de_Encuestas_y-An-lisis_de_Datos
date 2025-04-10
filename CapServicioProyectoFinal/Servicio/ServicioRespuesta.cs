using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;

namespace CapAplicacion.Servicio
{
    public class ServicioRespuesta : IPreguntasServicio
    {
        private readonly IRespuestaRepository respuestaServicio;

        public ServicioRespuesta(IRespuestaRepository respuesta)
        {
            respuestaServicio = respuesta;
        }

        public void ActualizarPregunta(Preguntas pregunta)
        {
            // Necesitas convertir Preguntas a Respuestas antes de actualizar
            Respuestas respuesta = MapPreguntaToRespuesta(pregunta);
            respuestaServicio.Update(respuesta);
        }

        public Preguntas CrearPregunta(Preguntas pregunta)
        {
            // Necesitas convertir Preguntas a Respuestas, añadirlo, y luego convertir la respuesta de nuevo a Pregunta
            Respuestas respuesta = MapPreguntaToRespuesta(pregunta);
            respuestaServicio.Add(respuesta); // Add method returns 
            return MapRespuestaToPregunta(respuesta);
        }

        public void EliminarPregunta(int id)
        {
            respuestaServicio.Delete(id);
        }

        public async Task<IEnumerable<Preguntas>> ObtenerPorEncuestaId(int encuestaId)
        {
            IEnumerable<Respuestas> respuestas = await respuestaServicio.GetByEncuestaId(encuestaId) ?? Enumerable.Empty<Respuestas>();
            return respuestas.Select(r => MapRespuestaToPregunta(r));
        }

        public async Task<IEnumerable<Preguntas>> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta)
        {
            IEnumerable<Respuestas> respuestas = await respuestaServicio.GetByTipoPregunta((int)tipoPregunta) ?? Enumerable.Empty<Respuestas>();
            return respuestas.Select(r => MapRespuestaToPregunta(r));
        }

        public Preguntas ObtenerPreguntaId(int id)
        {
            Respuestas respuesta = respuestaServicio.GetById(id);
            return MapRespuestaToPregunta(respuesta);
        }

        public IEnumerable<Preguntas> ObtenerTodo()
        {
            IEnumerable<Respuestas> respuestas = respuestaServicio.GetaAll();
            return respuestas.Select(r => MapRespuestaToPregunta(r));
        }

        // Métodos privados para hacer los mapeos
        private Respuestas MapPreguntaToRespuesta(Preguntas pregunta)
        {
            return new Respuestas
            {
                Id = pregunta.Id,
                RespuestaTexto = pregunta.Texto,
                UsuarioId = pregunta.UsuarioId,
                PreguntaId = pregunta.Id,


            };
        }

        private Preguntas MapRespuestaToPregunta(Respuestas respuesta)
        {
            return new Preguntas
            {
                Id = respuesta.Id,
                Texto = respuesta.RespuestaTexto,
                UsuarioId = respuesta.UsuarioId,
                TipoPregunta = TipoPregunta.OpcionMultiple,

            };
        }

        IEnumerable<Preguntas> IPreguntasServicio.ObtenerPorEncuestaId(int encuestaId)
        {
            var respuestas = respuestaServicio.GetByEncuestaId(encuestaId).Result;
            return respuestas.Select(r => MapRespuestaToPregunta(r));
        }

        IEnumerable<Preguntas> IPreguntasServicio.ObtenerPorTipoPregunta(TipoPregunta tipoPregunta)
        {
            return respuestaServicio.GetByTipoPregunta((int)tipoPregunta).Result.Select(r => MapRespuestaToPregunta(r));
        }
    }
}