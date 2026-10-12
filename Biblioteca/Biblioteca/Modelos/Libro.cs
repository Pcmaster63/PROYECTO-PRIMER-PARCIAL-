namespace Biblioteca.App.Modelos;

public class Libro : Recurso
{
    public string Autor { get; }

    public Libro(string titulo, string autor) : base(titulo)
    {
        Autor = autor;
    }

    public override int DiasPrestamo => 14;
    protected override decimal MultaPorDia => 0.50m;
    public override string Descripcion() => $"Libro: {Titulo} ({Autor})";
}
