namespace Biblioteca.App.Modelos;

public class Docente : Usuario
{
    public Docente(string nombre, string email) : base(nombre, email) { }
    public override int MaxPrestamos => 5;
}
