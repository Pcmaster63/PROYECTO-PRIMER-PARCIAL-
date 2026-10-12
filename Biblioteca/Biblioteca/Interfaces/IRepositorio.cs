namespace Biblioteca.App.Interfaces;

public interface IRepositorio<T> where T : IEntidad
{
    void Agregar(T entidad);
    T? ObtenerPorId(Guid id);
    IReadOnlyList<T> ObtenerTodos();
}
