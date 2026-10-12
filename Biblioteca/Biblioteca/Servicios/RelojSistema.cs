using Biblioteca.App.Interfaces;

namespace Biblioteca.App.Servicios;

public class RelojSistema : IReloj
{
    public DateTime Ahora => DateTime.Now;
}
