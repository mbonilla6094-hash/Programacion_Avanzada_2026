using System;
using ProyectoTesis.Datos.Repositorios;

namespace ProyectoTesis.Datos
{
    public class UnitOfWork : IDisposable
    {
        private readonly SistemaTesisEntities _context;
        private bool _disposed;

        public UnitOfWork()
        {
            _context = new SistemaTesisEntities();
        }

        public UnitOfWork(SistemaTesisEntities context)
        {
            _context = context;
        }

        private ProfesorRepositorio _profesorRepositorio;
        private EstudianteRepositorio _estudianteRepositorio;
        private InformeCabeceraRepositorio _informeCabeceraRepositorio;
        private InformeDetalleRepositorio _informeDetalleRepositorio;
        private HistorialRepositorio _historialRepositorio;

        public ProfesorRepositorio ProfesorRepositorio =>
            _profesorRepositorio ?? (_profesorRepositorio = new ProfesorRepositorio(_context));

        public EstudianteRepositorio EstudianteRepositorio =>
            _estudianteRepositorio ?? (_estudianteRepositorio = new EstudianteRepositorio(_context));

        public InformeCabeceraRepositorio InformeCabeceraRepositorio =>
            _informeCabeceraRepositorio ?? (_informeCabeceraRepositorio = new InformeCabeceraRepositorio(_context));

        public InformeDetalleRepositorio InformeDetalleRepositorio =>
            _informeDetalleRepositorio ?? (_informeDetalleRepositorio = new InformeDetalleRepositorio(_context));

        public HistorialRepositorio HistorialRepositorio =>
            _historialRepositorio ?? (_historialRepositorio = new HistorialRepositorio(_context));

        public SistemaTesisEntities ObtenerContexto()
        {
            return _context;
        }

        public int Guardar()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
