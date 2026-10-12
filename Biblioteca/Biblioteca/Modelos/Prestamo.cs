namespace Biblioteca.App.Modelos;

public class Prestamo
{
    public Guid Id { get; } = Guid.NewGuid();
    public Recurso Recurso { get; }
    public Usuario Usuario { get; }
    public DateTime FechaPrestamo { get; }
    public DateTime FechaVencimiento { get; }
    public DateTime? FechaDevolucion { get; private set; }

    public bool Activo => FechaDevolucion is null;

    public Prestamo(Recurso recurso, Usuario usuario, DateTime fechaPrestamo)
    {
        Recurso = recurso;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaPrestamo.AddDays(recurso.DiasPrestamo);
    }

    /// <summary>Registra la devolución y retorna la multa (0 si no hay retraso).</summary>
    public decimal Devolver(DateTime fecha)
    {
        if (!Activo)
            throw new InvalidOperationException("El préstamo ya fue devuelto.");

        FechaDevolucion = fecha;
        Recurso.MarcarDisponible();

        var diasRetraso = (int)Math.Ceiling((fecha - FechaVencimiento).TotalDays);
        return Recurso.CalcularMulta(diasRetraso);
    }
}
