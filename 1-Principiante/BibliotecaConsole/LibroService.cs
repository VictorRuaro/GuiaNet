namespace BibliotecaConsole;

public class LibroService
{
    private List<Libro> libros;
    public LibroService()
    {
        libros = new List<Libro>();
    }
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }
    public List<Libro> ObtenerLibros()
    {
        return libros;
    }
}
