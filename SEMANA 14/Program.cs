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

    // Método público para recorrer el árbol en orden (PostOrden)
    public void RecorrerPostOrden()
    {
        RecorrerPostOrdenRecursivo(raiz);
        Console.WriteLine(); // Salto de línea después del recorrido
    }

    // Método recursivo para el recorrido PostOrden
    private void RecorrerPostOrdenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorrerPostOrdenRecursivo(nodo.Izquierda); // Primero el subárbol izquierdo
            RecorrerPostOrdenRecursivo(nodo.Derecha); // Luego el subárbol derecho
            Console.Write(nodo.Valor + " "); // Finalmente el nodo actual
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
            Console.WriteLine("3. Recorrido InOrden");
            Console.WriteLine("4. Recorrido PostOrden");
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
                    Console.WriteLine("Recorrido InOrden:");
                    arbol.RecorrerInOrden(); // Mostrar el recorrido inorden del árbol
                    break;
                case 4:
                    Console.WriteLine("Recorrido PostOrden:");
                    arbol.RecorrerPostOrden(); // Mostrar el recorrido postorden del árbol
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
