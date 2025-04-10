using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CapDominio.Entity;
using CAPdominioProyectofinal.InterfaceRepository;
using CapInfraestructura.Context;

namespace CapInfraestructura.Repository
{
    public class EncuestaRepository : ICuentaRepository
    {
        private readonly ContextoDB _contexto;

        public EncuestaRepository(ContextoDB contexto)
        {
            _contexto = contexto;
        }

        public void Add(Encuesta encuesta)
        {
            try
            {
                // Validación básica
                if (encuesta == null)
                    throw new ArgumentNullException(nameof(encuesta));

                // Asignar fecha de creación si no está establecida
                if (encuesta.FechaCreacion == default)
                    encuesta.FechaCreacion = DateTime.Now;

                // Establecer estado por defecto si no está establecido
                if (encuesta.Estado == default)
                    encuesta.Estado = EstadoEncuesta.Activa;

                _contexto.Encuenta.Add(encuesta);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error al guardar en la base de datos", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var encuesta = _contexto.Encuenta
                    .Include(e => e.Preguntas)
                    .ThenInclude(p => p.Respuestas)
                    .FirstOrDefault(e => e.Id == id);

                if (encuesta == null)
                    throw new KeyNotFoundException("Encuesta no encontrada");

                // Verificar si tiene respuestas antes de eliminar
                if (encuesta.Preguntas?.Any(p => p.Respuestas?.Any() == true) == true)
                    throw new InvalidOperationException("No se puede eliminar una encuesta con respuestas");

                _contexto.Encuenta.Remove(encuesta);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error al eliminar de la base de datos", ex);
            }
        }

        public Encuesta ObtenerPorId(int id)
        {
            return _contexto.Encuenta
                .Include(e => e.Preguntas)
                    .ThenInclude(p => p.Opciones)
                .Include(e => e.Preguntas)
                    .ThenInclude(p => p.Respuestas)
                .Include(e => e.Usuario)
                .FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Encuesta> ObtenerPorUsuario(int usuarioId)
        {
            return _contexto.Encuenta
                .Where(e => e.UsuarioId == usuarioId)
                .Include(e => e.Preguntas)
                .OrderByDescending(e => e.FechaCreacion)
                .ToList();
        }

        public IEnumerable<Encuesta> ObtenerPublicas()
        {
            var ahora = DateTime.Now;
            return _contexto.Encuenta
                .Where(e => e.EsPublica &&
                            e.Estado == EstadoEncuesta.Activa &&
                            e.FechaExpiracion > ahora)
                .Include(e => e.Preguntas)
                .OrderByDescending(e => e.FechaCreacion)
                .ToList();
        }

        public IEnumerable<Encuesta> ObtenerTodas()
        {
            return _contexto.Encuenta
                .Include(e => e.Preguntas)
                .Include(e => e.Usuario)
                .OrderByDescending(e => e.FechaCreacion)
                .ToList();
        }

        public void Update(Encuesta encuesta)
        {
            try
            {
                // Validación básica
                if (encuesta == null)
                    throw new ArgumentNullException(nameof(encuesta));

                var existing = _contexto.Encuenta.Find(encuesta.Id);
                if (existing == null)
                    throw new KeyNotFoundException("Encuesta no encontrada");

                // Actualizar propiedades
                _contexto.Entry(existing).CurrentValues.SetValues(encuesta);

                // Guardar cambios
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error al actualizar en la base de datos", ex);
            }
        }
    }
}
