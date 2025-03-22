using System;

// Definición de la clase Nodo para representar cada elemento del árbol
class Nodo
{
    public string Valor; // Almacena el valor del nodo (en este caso, una cadena de texto)
    public Nodo Izquierda; // Referencia al hijo izquierdo
    public Nodo Derecha; // Referencia al hijo derecho

    // Constructor para inicializar un nodo con un valor dado
    public Nodo(string valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

// Clase del Árbol Binario de Búsqueda
class ArbolBinarioBusqueda
{
    private Nodo raiz; // Nodo raíz del árbol

    // Constructor: Inicializa el árbol como vacío
    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // Método público para insertar un valor en el árbol
    public void Insertar(string valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    // Método recursivo para insertar un nodo en el árbol
    private Nodo InsertarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null) // Si el nodo es nulo, se crea un nuevo nodo con el valor
        {
            return new Nodo(valor);
        }

        // Comparar el valor a insertar con el nodo actual
        if (string.Compare(valor, nodo.Valor) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, valor); // Insertar en el subárbol izquierdo
        }
        else if (string.Compare(valor, nodo.Valor) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, valor); // Insertar en el subárbol derecho
        }

        return nodo; // Retorna el nodo actualizado
    }

    // Método público para buscar un valor en el árbol
    public Nodo Buscar(string valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    // Método recursivo para buscar un nodo en el árbol
    private Nodo BuscarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null || nodo.Valor == valor) // Si el nodo es nulo o se encuentra el valor, retorna el nodo
        {
            return nodo;
        }

        // Si el valor es menor, buscar en el subárbol izquierdo
        if (string.Compare(valor, nodo.Valor) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, valor);
        }
        else // Si es mayor, buscar en el subárbol derecho
        {
            return BuscarRecursivo(nodo.Derecha, valor);
        }
    }

    // Método público para eliminar un valor del árbol
    public void Eliminar(string valor)
    {
        raiz = EliminarRecursivo(raiz, valor);
    }

    // Método recursivo para eliminar un nodo del árbol
    private Nodo EliminarRecursivo(Nodo nodo, string valor)
    {
        if (nodo == null)
        {
            return nodo; // Si el nodo es nulo, no se hace nada
        }

        if (string.Compare(valor, nodo.Valor) < 0)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, valor); // Buscar en el subárbol izquierdo
        }
        else if (string.Compare(valor, nodo.Valor) > 0)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, valor); // Buscar en el subárbol derecho
        }
        else
        {
            // Caso 1: Nodo con un solo hijo o sin hijos
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            // Caso 2: Nodo con dos hijos
            nodo.Valor = ObtenerValorMinimo(nodo.Derecha); // Obtener el sucesor inmediato
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Valor); // Eliminar el sucesor inmediato
        }
        return nodo;
    }

    // Método para obtener el valor mínimo del subárbol derecho
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

    // Método público para recorrer el árbol en orden (InOrden)
    public void RecorrerInOrden()
    {
        RecorrerInOrdenRecursivo(raiz);
        Console.WriteLine(); // Salto de línea después del recorrido
    }

    // Método recursivo para el recorrido InOrden
    private void RecorrerInOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorrerInOrdenRecursivo(nodo.Izquierda); // Primero el subárbol izquierdo
            Console.Write(nodo.Valor + " "); // Luego el nodo actual
            RecorrerInOrdenRecursivo(nodo.Derecha); // Finalmente el subárbol derecho
        }
    }
}

// Clase principal del programa
class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda(); // Crear un árbol binario de búsqueda
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
                    arbol.Insertar(valor); // Insertar la palabra en el árbol
                    break;
                case 2:
                    Console.Write("Ingrese palabra a buscar: ");
                    valor = Console.ReadLine();
                    Console.WriteLine(arbol.Buscar(valor) != null ? "Palabra encontrada" : "Palabra no encontrada");
                    break;
                case 3:
                    Console.Write("Ingrese palabra a eliminar: ");
                    valor = Console.ReadLine();
                    arbol.Eliminar(valor); // Eliminar la palabra ingresada
                    break;
                case 4:
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.RecorrerInOrden(); // Mostrar el recorrido inorden del árbol
                    break;
                case 5:
                    Console.WriteLine("Saliendo..."); // Salir del programa
                    break;
                default:
                    Console.WriteLine("Opción no válida."); // Mensaje en caso de opción incorrecta
                    break;
            }
        } while (opcion != 5); // Repetir el menú hasta que el usuario elija salir
    }
}
