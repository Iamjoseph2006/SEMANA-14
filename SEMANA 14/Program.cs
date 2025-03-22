using System;

class Nodo
{
    public string Valor;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(string valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

class ArbolBinarioBusqueda
{
    private Nodo raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // Insertar un valor en el árbol binario de búsqueda
    public void Insertar(string valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
        {
            return new Nodo(valor);
        }

        if (string.Compare(valor, nodo.Valor) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor);
        }
        else if (string.Compare(valor, nodo.Valor) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor);
        }

        return nodo;
    }

    // Buscar un valor en el árbol
    public Nodo Buscar(string valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    private Nodo BuscarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null || nodo.Valor == valor)
        {
            return nodo;
        }

        if (string.Compare(valor, nodo.Valor) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, valor);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, valor);
        }
    }

    // Eliminar un valor del árbol
    public void Eliminar(string valor)
    {
        raiz = EliminarRecursivo(raiz, valor);
    }

    private Nodo EliminarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
        {
            return nodo;
        }

        if (string.Compare(valor, nodo.Valor) < 0)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor);
        }
        else if (string.Compare(valor, nodo.Valor) > 0)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor);
        }
        else
        {
            // Nodo con solo un hijo o sin hijos
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            // Nodo con dos hijos
            nodo.Valor = ObtenerValorMinimo(nodo.Derecha);
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Valor);
        }
        return nodo;
    }

    private string ObtenerValorMinimo(Nodo nodo)
    {
        string minValue = nodo.Valor;
        while (nodo.Izquierda != null)
        {
            minValue = nodo.Izquierda.Valor;
            nodo = nodo.Izquierda;
        }
        return minValue;
    }

    // Recorrer el árbol en orden (InOrden)
    public void RecorrerInOrden()
    {
        RecorrerInOrdenRecursivo(raiz);
        Console.WriteLine(); // Nueva línea después del recorrido
    }

    private void RecorrerInOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorrerInOrdenRecursivo(nodo.Izquierda);
            Console.Write(nodo.Valor + " ");
            RecorrerInOrdenRecursivo(nodo.Derecha);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();  // Crear un árbol binario de búsqueda
        int opcion;
        string valor;

        do
        {
            // Mostrar menú de opciones
            Console.WriteLine("\n--- Menú Árbol Binario de Cadenas ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Recorrido InOrden");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine());

            // Ejecutar la opción seleccionada por el usuario
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese palabra a insertar: ");
                    valor = Console.ReadLine();
                    arbol.Insertar(valor);  // Insertar la palabra en el árbol
                    break;
                case 2:
                    Console.Write("Ingrese palabra a buscar: ");
                    valor = Console.ReadLine();
                    Console.WriteLine(arbol.Buscar(valor) != null ? "Palabra encontrada" : "Palabra no encontrada");
                    break;
                case 3:
                    Console.Write("Ingrese palabra a eliminar: ");
                    valor = Console.ReadLine();
                    arbol.Eliminar(valor);  // Eliminar la palabra ingresada
                    break;
                case 4:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.RecorrerInOrden();  // Mostrar el recorrido inorden del árbol
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");  // Salir del programa
                    break;
                default:
                    Console.WriteLine("Opción no válida.");  // Mensaje en caso de opción incorrecta
                    break;
            }
        } while (opcion != 5);  // Repetir el menú hasta que el usuario elija salir
    }
}
