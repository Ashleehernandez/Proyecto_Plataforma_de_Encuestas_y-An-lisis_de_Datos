using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapDominio.Entity;

namespace CAPdominioProyectofinal.InterfaceRepository
{
    public interface ICuentaRepository
    {
        void Add(Encuesta encuesta);
        void Update(Encuesta encuesta);
        void Delete(int id);
        Encuesta ObtenerPorId(int id);
        IEnumerable<Encuesta> ObtenerTodas();
        IEnumerable<Encuesta> ObtenerPublicas();
        IEnumerable<Encuesta> ObtenerPorUsuario(int usuarioId);
    }
}
