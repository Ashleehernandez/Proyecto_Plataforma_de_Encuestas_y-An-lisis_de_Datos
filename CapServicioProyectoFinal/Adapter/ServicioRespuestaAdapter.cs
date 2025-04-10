using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;

namespace CapAplicacion.Servicio
{
    public class ServicioRespuestaAdapters
    {
        private readonly IRespuestaRepository respuestaRepository;

        public ServicioRespuestaAdapters(IRespuestaRepository respuestaRepository)
        {
            this.respuestaRepository = respuestaRepository;
        }

        public async Task<Respuestas> ActualizarRespuesta(Respuestas respuesta)
        {
            await Task.Run(() => respuestaRepository.Update(respuesta));
            return respuesta;
        }

        public async Task<Respuestas> CrearRespuesta(Respuestas respuesta)
        {
            await Task.Run(() => respuestaRepository.Add(respuesta));
            return respuesta;
        }

        public async Task<Respuestas> EliminarPreguntaId(int id)
        {
            await Task.Run(() => respuestaRepository.Delete(id));
            return null;
        }

        public async Task<IEnumerable<Respuestas>> RespuestasPorEncuestaId(int encuestaId)
        {
            return await Task.Run(() => respuestaRepository.GetByEncuestaId(encuestaId));
        }

        public async Task<IEnumerable<Respuestas>> RespuestaporTipoDePreguntas(int tipoPreguntaId)
        {
            return await Task.Run(() => respuestaRepository.GetByTipoPregunta(tipoPreguntaId));
        }

        public async Task<Respuestas> RespuestasPorId(int id)
        {
            return await Task.Run(() => respuestaRepository.GetById(id));
        }

        public async Task<IEnumerable<Respuestas>> ObtenerTodo()
        {
            return await Task.Run(() => respuestaRepository.GetaAll());
        }
    }
}
