using System;
using System.Collections.Generic;
using System.Linq;
public interface IEncuestaServicio
{
    Encuesta Crear(Encuesta encuesta);
    void Actualizar(Encuesta encuesta);
    void Eliminar(int id);
    Encuesta ObtenerPorId(int id);
    IEnumerable<Encuesta> ObtenerTodas();
    IEnumerable<Encuesta> ObtenerPublicas();
    IEnumerable<Encuesta> ObtenerPorUsuario(int usuarioId);
    void CambiarEstado(int id, EstadoEncuesta nuevoEstado);
}