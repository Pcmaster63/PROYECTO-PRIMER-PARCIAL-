using Biblioteca.App.Excepciones;
using Biblioteca.App.Interfaces;
using Biblioteca.App.Modelos;

namespace Biblioteca.App.Servicios;

public class ServicioBiblioteca
{
    private readonly IRepositorio<Recurso> _recursos;
    private readonly IRepositorio<Usuario> _usuarios;
    private readonly IReloj _reloj;
    private readonly List<Prestamo> _prestamos = new();

    public ServicioBiblioteca(
        IRepositorio<Recurso> recursos,
        IRepositorio<Usuario> usuarios,
        IReloj reloj)
    {
        _recursos = recursos;
        _usuarios = usuarios;
        _reloj = reloj;
    }

    public IReadOnlyList<Prestamo> Prestamos => _prestamos;

    public Prestamo Prestar(Guid recursoId, Guid usuarioId)
    {
        var recurso = _recursos.ObtenerPorId(recursoId)
            ?? throw new EntidadNoEncontradaExcepcion(nameof(Recurso), recursoId);
        var usuario = _usuarios.ObtenerPorId(usuarioId)
            ?? throw new EntidadNoEncontradaExcepcion(nameof(Usuario), usuarioId);

        if (!usuario.PuedePrestar())
            throw new LimitePrestamosExcepcion(usuario.Nombre);

        recurso.MarcarPrestado();

        var prestamo = new Prestamo(recurso, usuario, _reloj.Ahora);
        usuario.RegistrarPrestamo(prestamo);
        _prestamos.Add(prestamo);
        return prestamo;
    }

    public decimal Devolver(Guid prestamoId)
    {
        var prestamo = _prestamos.FirstOrDefault(p => p.Id == prestamoId)
            ?? throw new EntidadNoEncontradaExcepcion(nameof(Prestamo), prestamoId);

        var multa = prestamo.Devolver(_reloj.Ahora);
        prestamo.Usuario.QuitarPrestamo(prestamo);
        return multa;
    }

    public IReadOnlyList<Prestamo> ObtenerPrestamosVencidos()
    {
        var ahora = _reloj.Ahora;
        return _prestamos
            .Where(p => p.Activo && p.FechaVencimiento < ahora)
            .ToList();
    }
}
