using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;


namespace CapAplicacion.Servicio
{
    public class ServicioPreguntas : IPreguntasServicio
    {
        private readonly IPreguntasRepository preguntasRepository;

        public ServicioPreguntas(IPreguntasRepository preguntasRepositor)
        {
            preguntasRepository = preguntasRepositor;
        }

        public void ActualizarPregunta(Preguntas pregunta)
        {
            preguntasRepository.Update(pregunta);

        }

        public Preguntas CrearPregunta(Preguntas pregunta)
        {
            preguntasRepository.Add(pregunta);
            return pregunta;
        }

        public void EliminarPregunta(int id)
        {
            preguntasRepository.Delete(id);
        }

        public IEnumerable<Preguntas> ObtenerPorEncuestaId(int encuestaId)
        {
            return new List<Preguntas> { preguntasRepository.GetById(encuestaId) };
        }

        public IEnumerable<Preguntas> ObtenerPorTipoPregunta(TipoPregunta tipoPregunta)
        {
            return preguntasRepository.GetAll().Where(p => p.TipoPregunta == tipoPregunta);
        }

        public Preguntas ObtenerPreguntaId(int id)
        {
          return  preguntasRepository.GetById(id);
           
        }

        public IEnumerable<Preguntas> ObtenerTodo()
        {
            return preguntasRepository.GetAll();
        }
    }
}
