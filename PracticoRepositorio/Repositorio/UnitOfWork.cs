using PracticoRepositorio.Models;

namespace PracticoRepositorio.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaEntityContext _context;
        private IGenericRepository<Curso> _cursos;
        private IGenericRepository<Estudiante> _estudiantes;

        public UnitOfWork(PruebaEntityContext context)
        {
            _context = context;
        }

        public IGenericRepository<Curso> Cursos
        {
            get { return _cursos ??= new GenericRepository<Curso>(_context); }
        }

        public IGenericRepository<Estudiante> Estudiantes
        {
            get { return _estudiantes ??= new GenericRepository<Estudiante>(_context); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
