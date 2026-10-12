using Biblioteca.App.Excepciones;
using Biblioteca.App.Interfaces;

namespace Biblioteca.App.Modelos;

public abstract class Recurso : IEntidad
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Titulo { get; }
    public bool Disponible { get; private set; } = true;

    protected Recurso(string titulo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("El título es obligatorio.", nameof(titulo));
        Titulo = titulo;
    }

    public abstract int DiasPrestamo { get; }
    protected abstract decimal MultaPorDia { get; }
    public abstract string Descripcion();

    public decimal CalcularMulta(int diasRetraso) =>
        diasRetraso <= 0 ? 0 : diasRetraso * MultaPorDia;

    public void MarcarPrestado()
    {
        if (!Disponible) throw new RecursoNoDisponibleExcepcion(Titulo);
        Disponible = false;
    }

    public void MarcarDisponible() => Disponible = true;
}
