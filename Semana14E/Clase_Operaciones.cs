public class Operaciones
{
    private ArbolesBinarios arbol;

    public Operaciones(ArbolesBinarios arbol)
    {
        this.arbol = arbol;
    }

    // Método para insertar un valor en el árbol
    public void Insertar(int valor)
    {
        arbol.SetRaiz(InsertarRecursivo(arbol.GetRaiz(), valor));
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            return new Nodo(valor);
        }

        if (valor < nodo.Valor)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
        }

        return nodo;
    }

    // Método para eliminar un valor del árbol
    public void Eliminar(int valor)
    {
        arbol.SetRaiz(EliminarRecursivo(arbol.GetRaiz(), valor));
    }

    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
        {
            return nodo;
        }

        if (valor < nodo.Valor)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);
        }
        else
        {
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            nodo.Valor = Minimo(nodo.Derecha);
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Valor);
        }

        return nodo;
    }

    private int Minimo(Nodo nodo)
    {
        int min = nodo.Valor;
        while (nodo.Izquierda != null)
        {
            min = nodo.Izquierda.Valor;
            nodo = nodo.Izquierda;
        }
        return min;
    }
}
