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
    public class PreguntasRepository : IPreguntasRepository
    {
        private readonly ContextoDB contextoDB;

        public PreguntasRepository(ContextoDB contexto)
        {
            contextoDB = contexto;
        }

        public void Add(Preguntas pregunta)
        {
            contextoDB.Add(pregunta);
            contextoDB.SaveChanges();
        }

        public void Delete(int id)
        {
            var pregunta = contextoDB.Preguntas.Find(id);
            if (pregunta == null)
            {
                contextoDB.Preguntas.Remove(pregunta);
                contextoDB.SaveChanges();
            }
        }

        public IEnumerable<Preguntas> GetAll()
        {
            return contextoDB.Preguntas.ToList();
        }

        public Preguntas GetById(int id)
        {
            return contextoDB.Preguntas.Find(id);
        }

        public void Update(Preguntas pregunta)
        {
            var preguntaActual = contextoDB.Preguntas.Find(pregunta.Id);
            if (preguntaActual != null)
            {
                contextoDB.Preguntas.Update(pregunta);
                contextoDB.SaveChanges();
            }
        }
    }
}
