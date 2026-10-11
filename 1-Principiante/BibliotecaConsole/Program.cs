using BibliotecaConsole;

bool salir = false;
LibroService libro = new LibroService();

while (!salir)
{
    Console.Clear();
    Console.WriteLine("=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Listar libros");
    Console.WriteLine("2. Agregar libro");
    Console.WriteLine("3. Salir");
    Console.Write("\nSelecciona una opción: ");

    string? opcion = Console.ReadLine();
    

    switch (opcion)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Has seleccionado la Listar libros");
            var libros = libro.ObtenerLibros();
            if (libros.Count == 0)
            {
                Console.WriteLine("No hay libros disponibles.");
            }
            else
            {
                foreach (var l in libros)
                {
                    Console.WriteLine($"ID: {l.Id}, Título: {l.Titulo}, Precio: {l.Precio}");
                }
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("Has seleccionado la Agregar libro");

            Console.Write("Ingresa el ID del libro: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Ingresa el título del libro: ");
            string titulo = Console.ReadLine()!;
            Console.Write("Ingresa el precio del libro: ");
            decimal precio = decimal.Parse(Console.ReadLine()!);
            Libro nuevoLibro = new Libro { Id = id, Titulo = titulo, Precio = precio };
            libro.AgregarLibro(nuevoLibro);

            Console.WriteLine("Libro agregado exitosamente.");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            break;

        case "3":
            salir = true;
            Console.WriteLine("¡Hasta luego!");
            break;

        default:
            Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

