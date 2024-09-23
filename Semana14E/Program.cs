using System;

class Program
{
    static void Main(string[] args)
    {
        ArbolesBinarios arbol = new ArbolesBinarios();
        Operaciones operaciones = new Operaciones(arbol);

        operaciones.Insertar(50);
        operaciones.Insertar(30);
        operaciones.Insertar(70);
        operaciones.Insertar(20);
        operaciones.Insertar(40);
        operaciones.Insertar(60);
        operaciones.Insertar(80);

        Console.WriteLine("Árbol binario creado con éxito.");

        operaciones.Eliminar(20);
        Console.WriteLine("Nodo con valor 20 eliminado.");

        operaciones.Eliminar(30);
        Console.WriteLine("Nodo con valor 30 eliminado.");

        operaciones.Eliminar(50);
        Console.WriteLine("Nodo con valor 50 eliminado.");
    }
}
