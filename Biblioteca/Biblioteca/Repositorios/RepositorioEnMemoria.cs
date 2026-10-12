using Biblioteca.App.Interfaces;

namespace Biblioteca.App.Repositorios;

public class RepositorioEnMemoria<T> : IRepositorio<T> where T : IEntidad
{
    private readonly Dictionary<Guid, T> _datos = new();

    public void Agregar(T entidad) => _datos[entidad.Id] = entidad;

    public T? ObtenerPorId(Guid id) =>
        _datos.TryGetValue(id, out var entidad) ? entidad : default;

    public IReadOnlyList<T> ObtenerTodos() => _datos.Values.ToList();
}
