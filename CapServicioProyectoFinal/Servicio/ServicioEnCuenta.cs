using System;
using System.Collections.Generic;
using System.Linq;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CAPdominioProyectofinal.InterfaceServicio;
using CapInfraestructura.Repository;

namespace CapAplicacion.Servicio
{
    public class ServicioEncuesta : IEncuestaServicio
    {
        private readonly ICuentaRepository _encuestaRepository;

        public ServicioEncuesta(ICuentaRepository encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;
        }

        public void Actualizar(Encuesta encuesta)
        {
            _encuestaRepository.Update(encuesta);
        }

        public void CambiarEstado(int id, EstadoEncuesta nuevoEstado)
        {
            _encuestaRepository.Update(new Encuesta
            {
                Id = id,
                Estado = nuevoEstado
            });

        }

        public Encuesta Crear(Encuesta encuesta)
        {
            if (encuesta == null)
                throw new ArgumentNullException("La encuesta no puede ser nula");

            if (string.IsNullOrWhiteSpace(encuesta.Nombre))
                throw new ArgumentException("El nombre es requerido");

            encuesta.FechaCreacion = DateTime.Now;
            encuesta.Estado = EstadoEncuesta.Activa;

            _encuestaRepository.Add(encuesta);
            return encuesta;
        }

        public void Eliminar(int id)
        {
            var encuesta = _encuestaRepository.ObtenerPorId(id);
            if (encuesta == null)
                throw new KeyNotFoundException("Encuesta no encontrada");
            _encuestaRepository.Delete(id);

        }

        public Encuesta ObtenerPorId(int id)
        {
            var encuesta = _encuestaRepository.ObtenerPorId(id);
            if (encuesta == null)
                throw new KeyNotFoundException("Encuesta no encontrada");
            return encuesta;

        }

        public IEnumerable<Encuesta> ObtenerPorUsuario(int usuarioId)
        {
            var encuestas = _encuestaRepository.ObtenerPorUsuario(usuarioId);
            if (encuestas == null || !encuestas.Any())
                throw new KeyNotFoundException("No se encontraron encuestas para el usuario especificado");
            return encuestas;
        }

        public IEnumerable<Encuesta> ObtenerPublicas()
        {
            var encuestas = _encuestaRepository.ObtenerPublicas();
            if (encuestas == null || !encuestas.Any())
                throw new KeyNotFoundException("No se encontraron encuestas públicas");
            return encuestas;
        }

        public IEnumerable<Encuesta> ObtenerTodas()
        {
            var encuestas = _encuestaRepository.ObtenerTodas();
            if (encuestas == null || !encuestas.Any())
                throw new KeyNotFoundException("No se encontraron encuestas");
            return encuestas;
        }
    }
}