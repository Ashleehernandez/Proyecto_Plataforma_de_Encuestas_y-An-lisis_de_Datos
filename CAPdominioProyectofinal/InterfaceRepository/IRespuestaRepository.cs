using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;    

namespace CAPdominioProyectofinal.InterfaceRepository
{
    public interface IRespuestaRepository
    {
       IEnumerable<Respuestas> GetaAll();
        Respuestas GetById(int id);
        void Add(Respuestas respuesta);
        void Update(Respuestas respuesta);
        void Delete(int id);
        Task<IEnumerable<Respuestas>>? GetByEncuestaId(int encuestaId);
        Task<IEnumerable<Respuestas>>? GetByTipoPregunta(int tipoPreguntaId);
        void Update(object respuesta);
    }
}
