using System;
using System.Collections.Generic;

public class BusquedaLibro
{
    // Método para realizar una búsqueda secuencial iterativa
    public bool BuscarPorTituloIterativo(List<string> biblioteca, string libroBuscado)
    {
        foreach (string libro in biblioteca)
        {
            if (libro.Equals(libroBuscado, StringComparison.CurrentCultureIgnoreCase))
            {
                return true; // Si el libro es encontrado
            }
        }
        return false; // Si no se encuentra el libro
    }

    // Método para realizar una búsqueda secuencial recursiva
    public bool BuscarPorTituloRecursivo(List<string> biblioteca, string libroBuscado, int posicion = 0)
    {
        if (posicion >= biblioteca.Count) return false; // Si se llega al final sin encontrar el libro
        if (biblioteca[posicion].Equals(libroBuscado, StringComparison.CurrentCultureIgnoreCase)) return true; // Si se encuentra el libro
        return BuscarPorTituloRecursivo(biblioteca, libroBuscado, posicion + 1); // Llamada recursiva para la siguiente posición
    }
}
