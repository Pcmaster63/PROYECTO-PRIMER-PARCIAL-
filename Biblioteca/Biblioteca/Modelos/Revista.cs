namespace Biblioteca.App.Modelos;

public class Revista : Recurso
{
    public int NumeroEdicion { get; }

    public Revista(string titulo, int numeroEdicion) : base(titulo)
    {
        NumeroEdicion = numeroEdicion;
    }

    public override int DiasPrestamo => 7;
    protected override decimal MultaPorDia => 0.25m;
    public override string Descripcion() => $"Revista: {Titulo} #{NumeroEdicion}";
}
