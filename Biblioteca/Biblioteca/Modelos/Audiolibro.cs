namespace Biblioteca.App.Modelos;

public class Audiolibro : Recurso
{
    public int DuracionMinutos { get; }

    public Audiolibro(string titulo, int duracionMinutos) : base(titulo)
    {
        DuracionMinutos = duracionMinutos;
    }

    public override int DiasPrestamo => 10;
    protected override decimal MultaPorDia => 0.75m;
    public override string Descripcion() => $"Audiolibro: {Titulo} ({DuracionMinutos} min)";
}
