using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CapInfraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapInfraestructura.Repository
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly ContextoDB contextoDB;

        public RespuestaRepository(ContextoDB contexto)
        {
            contextoDB = contexto;

        }


        public void Add(Respuestas respuesta)
        {
            contextoDB.Add(respuesta);
            contextoDB.SaveChanges();
        }

        public void Delete(int id)
        {
           var respuesta = contextoDB.Respuestas.Find(id);
            if (respuesta == null)
            {
                contextoDB.Respuestas.Remove(respuesta);
                contextoDB.SaveChanges();
            }
        }

        public IEnumerable<Respuestas> GetaAll()
        {
            return contextoDB.Respuestas.ToList();
        }

        public Task<IEnumerable<Respuestas>>? GetByEncuestaId(int encuestaId)
        {
            throw new NotImplementedException();
        }

        public Respuestas GetById(int id)
        {
            return contextoDB.Respuestas.Find(id);
        }

        public Task<IEnumerable<Respuestas>>? GetByTipoPregunta(int tipoPreguntaId)
        {
            throw new NotImplementedException();
        }

        public void Update(Respuestas respuesta)
        {
            var resp = contextoDB.Respuestas.Find(respuesta.Id);
            if (resp != null)
            {
                resp.UsuarioId = respuesta.UsuarioId;
                resp.PreguntaId = respuesta.PreguntaId;
                resp.RespuestaTexto = respuesta.RespuestaTexto;
                resp.RespuestaSeleccionada = respuesta.RespuestaSeleccionada;
                resp.Puntaje = respuesta.Puntaje;
                resp.FechaRespuesta = respuesta.FechaRespuesta;
            }
        }

        public void Update(object respuesta)
        {
            throw new NotImplementedException();
        }
    }
}
