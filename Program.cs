using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static void Main(string[] args)
    {
        using (var context = new Context())
        {
 
            Console.WriteLine("Registros en la base de datos:");
            var asignaturas = context.asignaturas.ToList();
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine($"ID: {asignatura.id}, Nombre: {asignatura.nombre}, Unidades Valorativas: {asignatura.unidadesvalorativas}, Ciclo: {asignatura.ciclo}, Inscritos: {asignatura.inscritos}");
            }

            Console.WriteLine("\nIngrese los datos del nuevo registro:");
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Unidades Valorativas: ");
            var unidadesValorativas = Console.ReadLine();
            Console.Write("Ciclo: ");
            var ciclo = Console.ReadLine();
            Console.Write("Inscritos: ");
            var inscritos = int.Parse(Console.ReadLine());

            var nuevaAsignatura = new asignaturas
            {
                nombre = nombre,
                unidadesvalorativas = unidadesValorativas,
                ciclo = ciclo,
                inscritos = inscritos
            };

            context.asignaturas.Add(nuevaAsignatura);
            context.SaveChanges();



            Console.WriteLine("\nModificar un registro existente:");
            Console.Write("ID del registro que desea modificar: ");
            var idModificar = int.Parse(Console.ReadLine());
            var asignaturaModificar = context.asignaturas.FirstOrDefault(a => a.id == idModificar);

            if (asignaturaModificar != null)
            {
                Console.Write("Ingrese el nuevo nombre: ");
                asignaturaModificar.nombre = Console.ReadLine();
                Console.Write("Ingrese Unidades Valorativas: ");
                asignaturaModificar.unidadesvalorativas = Console.ReadLine();
                Console.Write("Ingrese el Ciclo: ");
                asignaturaModificar.ciclo = Console.ReadLine();
                Console.Write("Ingrese cuantos Inscritos: ");
                asignaturaModificar.inscritos = int.Parse(Console.ReadLine());

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("No se encontró un registro con el ID ingresado.");
            }

        }
    }
}

