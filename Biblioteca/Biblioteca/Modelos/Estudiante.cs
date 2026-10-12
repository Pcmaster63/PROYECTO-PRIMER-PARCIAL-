namespace Biblioteca.App.Modelos;

public class Estudiante : Usuario
{
    public Estudiante(string nombre, string email) : base(nombre, email) { }
    public override int MaxPrestamos => 3;
}
