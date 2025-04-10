using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;

namespace CAPdominioProyectofinal.InterfaceRepository
{
    public interface IPreguntasRepository
    {
       IEnumerable<Preguntas> GetAll();
        Preguntas GetById(int id);
        void Add(Preguntas pregunta);
        void Update(Preguntas pregunta);
        void Delete(int id);

    }
}

