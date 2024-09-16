using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido, ingrese la cantidad de mascotas:");
        int cantMascotas = int.Parse(Console.ReadLine());
        string[] nombreMascota = new string[cantMascotas];
        string[] especieMascota = new string[cantMascotas];
        int[] edadMascota = new int[cantMascotas];

        for (int i = 0; i < cantMascotas; i++)
        {
            AgregarMascota(nombreMascota, edadMascota, especieMascota, i);
        }

        Console.WriteLine("¿Qué especie quieres buscar?");
        string especie = Console.ReadLine();
        MostrarMascotas(nombreMascota, edadMascota, especieMascota, especie);

        MetodoSeleccion(edadMascota, nombreMascota, especieMascota);
        Mostrar(nombreMascota, edadMascota, especieMascota);

        Console.WriteLine("¿Qué nombre de mascota quieres buscar?");
        string nombre = Console.ReadLine();
        BuscarNombre(nombre, edadMascota, especieMascota, nombreMascota);
        Console.ReadKey();
    }

    static void AgregarMascota(string[] nombreMascota, int[] edadMascota, string[] especieMascota, int index)
    {
        Console.WriteLine($"Ingrese el nombre de la mascota {index + 1}:");
        nombreMascota[index] = Console.ReadLine();

        Console.WriteLine($"Ingrese la especie de {nombreMascota[index]}:");
        especieMascota[index] = Console.ReadLine();

        Console.WriteLine($"Ingrese la edad de {nombreMascota[index]}:");
        edadMascota[index] = int.Parse(Console.ReadLine());
    }

    static void MostrarMascotas(string[] nombreMascota, int[] edadMascota, string[] especieMascota, string especie)
    {
        Console.WriteLine($"Mascotas de la especie {especie}:");
        for (int i = 0; i < nombreMascota.Length; i++)
        {
            if (especieMascota[i].Equals(especie, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Nombre: {nombreMascota[i]}, Edad: {edadMascota[i]}");
            }
        }
    }

    static void MetodoSeleccion(int[] edadMascota, string[] nombreMascota, string[] especieMascota)
    {
        for (int i = 0; i < edadMascota.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < edadMascota.Length; j++)
            {
                if (edadMascota[j] < edadMascota[minIndex])
                {
                    minIndex = j;
                }
            }
            
            if (minIndex != i)
            {
               
                int tempEdad = edadMascota[i];
                edadMascota[i] = edadMascota[minIndex];
                edadMascota[minIndex] = tempEdad;

               
                string tempNombre = nombreMascota[i];
                nombreMascota[i] = nombreMascota[minIndex];
                nombreMascota[minIndex] = tempNombre;

               
                string tempEspecie = especieMascota[i];
                especieMascota[i] = especieMascota[minIndex];
                especieMascota[minIndex] = tempEspecie;
            }
        }
    }
    static void Mostrar(string[] nombreMascota, int[] edadMascota, string[] especieMascota)
    {
        Console.WriteLine("Registro de mascotas:");
        for (int i = 0; i < nombreMascota.Length; i++)
        {
            Console.WriteLine($"Nombre: {nombreMascota[i]}, Especie: {especieMascota[i]}, Edad: {edadMascota[i]}");
        }
    }

    static void BuscarNombre(string nombre, int[] edadMascota, string[] especieMascota, string[] nombreMascota)
    {
        for (int i = 0; i < edadMascota.Length; i++)
        {
            if (nombreMascota[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Buscaste la mascota {nombre}");
                Console.WriteLine($"Especie: {especieMascota[i]}");
                Console.WriteLine($"Edad: {edadMascota[i]}");
                return;
            }
        }
        Console.WriteLine("Mascota no encontrada.");
    }
}