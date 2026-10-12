using Biblioteca.App.Excepciones;
using Biblioteca.App.Modelos;
using Biblioteca.App.Repositorios;
using Biblioteca.App.Servicios;

var recursos = new RepositorioEnMemoria<Recurso>();
var usuarios = new RepositorioEnMemoria<Usuario>();
var servicio = new ServicioBiblioteca(recursos, usuarios, new RelojSistema());

var libro = new Libro("Clean Code", "Robert C. Martin");
var revista = new Revista("National Geographic", 245);
var audio = new Audiolibro("Sapiens", 900);
recursos.Agregar(libro);
recursos.Agregar(revista);
recursos.Agregar(audio);

var ana = new Estudiante("Ana Pérez", "ana@correo.com");
usuarios.Agregar(ana);

try
{
    var prestamo = servicio.Prestar(libro.Id, ana.Id);
    Console.WriteLine($"Préstamo: {prestamo.Recurso.Descripcion()} vence {prestamo.FechaVencimiento:d}");

    Console.WriteLine($"Préstamos vencidos: {servicio.ObtenerPrestamosVencidos().Count}");

    servicio.Prestar(libro.Id, ana.Id); // debe fallar: ya está prestado
}
catch (BibliotecaExcepcion ex)
{
    Console.WriteLine($"Error de negocio: {ex.Message}");
}
