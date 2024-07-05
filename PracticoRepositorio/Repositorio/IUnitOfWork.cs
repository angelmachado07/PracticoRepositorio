using PracticoRepositorio.Models;
using System;


namespace PracticoRepositorio.Repositorio
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Curso> Cursos { get; }
        IGenericRepository<Estudiante> Estudiantes { get; }
        void Save();

    }
}
