using Biblioteca.App.Interfaces;

namespace Biblioteca.App.Modelos;

public abstract class Usuario : IEntidad
{
    private readonly List<Prestamo> _prestamosActivos = new();

    public Guid Id { get; } = Guid.NewGuid();
    public string Nombre { get; }
    public string Email { get; }
    public IReadOnlyList<Prestamo> PrestamosActivos => _prestamosActivos;

    protected Usuario(string nombre, string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
        Nombre = nombre;
        Email = email;
    }

    public abstract int MaxPrestamos { get; }

    public bool PuedePrestar() => _prestamosActivos.Count < MaxPrestamos;

    public void RegistrarPrestamo(Prestamo prestamo) => _prestamosActivos.Add(prestamo);
    public void QuitarPrestamo(Prestamo prestamo) => _prestamosActivos.Remove(prestamo);
}
