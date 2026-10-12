namespace Biblioteca.App.Excepciones;

public abstract class BibliotecaExcepcion : Exception
{
    protected BibliotecaExcepcion(string mensaje) : base(mensaje) { }
}

public class RecursoNoDisponibleExcepcion : BibliotecaExcepcion
{
    public RecursoNoDisponibleExcepcion(string titulo)
        : base($"El recurso '{titulo}' no está disponible.") { }
}

public class LimitePrestamosExcepcion : BibliotecaExcepcion
{
    public LimitePrestamosExcepcion(string nombre)
        : base($"{nombre} alcanzó su límite de préstamos.") { }
}

public class EntidadNoEncontradaExcepcion : BibliotecaExcepcion
{
    public EntidadNoEncontradaExcepcion(string tipo, Guid id)
        : base($"{tipo} con id {id} no existe.") { }
}
