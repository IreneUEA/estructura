public class ArbolBinario {
    private Nodo raiz;

    public ArbolBinario() {
        raiz = null;
    }

    public void Insertar(int valor) {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo raiz, int valor) {
        if (raiz == null) {
            raiz = new Nodo(valor);
            return raiz;
        }

        if (valor < raiz.valor) {
            raiz.izquierdo = InsertarRecursivo(raiz.izquierdo, valor);
        } else if (valor > raiz.valor) {
            raiz.derecho = InsertarRecursivo(raiz.derecho, valor);
        }

        return raiz;
    }

    public bool Buscar(int valor) {
        return BuscarRecursivo(raiz, valor);
    }

    private bool BuscarRecursivo(Nodo raiz, int valor) {
        if (raiz == null) {
            return false;
        }

        if (valor == raiz.valor) {
            return true;
        } else if (valor < raiz.valor) {
            return BuscarRecursivo(raiz.izquierdo, valor);
        } else {
            return BuscarRecursivo(raiz.derecho, valor);
        }
    }

    public void InOrden() {
        InOrdenRecursivo(raiz);
    }

    private void InOrdenRecursivo(Nodo raiz) {
        if (raiz != null) {
            InOrdenRecursivo(raiz.izquierdo);
            Console.Write(raiz.valor + " ");
            InOrdenRecursivo(raiz.derecho);
        }
    }
}
