using System.IO;
using System.Text.Json;

namespace BibliotecaConsole;

public class Repositorio
{
    // 1. Crear los datos básicos (un objeto anónimo o una clase)
    public string GuardarDatos<T>(List<T> datos, string nombreArchivo)
    {
        string result = string.Empty;
        try
        {
            // 2. Definir la ruta del archivo
            string ruta = AppDomain.CurrentDomain.BaseDirectory;
            string rutaJson = $"{ruta}/{nombreArchivo}.json";

            // 3. Serializar a JSON con formato legible (opcional) y guardar
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(datos, opciones);

            // 4. Guardar el JSON en un archivo
            File.WriteAllText(rutaJson, json);

            result=$"Datos guardados en JSON en: {Path.GetFullPath(rutaJson)}";

            return result;
        }
        catch (Exception ex)
        {
            result = $"Error al guardar los datos: {ex.Message}";
            return result;
        }
    }
}
