using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear catálogo de medicamentos
        List<Medicamento> catalogo = new List<Medicamento>();
        catalogo.Add(new Medicamento("Ibuprofeno", "Pastillas", 50, 200, new DateTime(2025, 1, 1)));
        catalogo.Add(new Medicamento("Paracetamol", "Pastillas", 100, 500, new DateTime(2024, 6, 1)));
        catalogo.Add(new Medicamento("Amoxicilina", "Jarabe", 30, 250, new DateTime(2023, 12, 1)));
        catalogo.Add(new Medicamento("Dipirona", "Inyección", 10, 500, new DateTime(2026, 3, 1)));
        catalogo.Add(new Medicamento("Benzocaína", "Pomada", 20, 50, new DateTime(2024, 9, 1)));

        // Crear cliente
        Cliente cliente = new Cliente();
        Console.WriteLine("Ingresa tu nombre: ");
        cliente.Nombre = Console.ReadLine();
        Console.WriteLine("Ingresa tu apellido: ");
        cliente.Apellido = Console.ReadLine();
        Console.WriteLine("Ingresa tu edad: ");
        cliente.edad = int.Parse(Console.ReadLine());
        Enfermedad enfermedad = new Enfermedad();
        Console.WriteLine("****Enfermedades****");
        Console.WriteLine("\n"+enfermedad.enfermedad1);
        Console.WriteLine("\n"+enfermedad.enfermedad2);
        Console.WriteLine("\n"+enfermedad.enfermedad3);
        Console.WriteLine("\n"+enfermedad.enfermedad4);
        Console.WriteLine("\nSelecciona una enfermedad: ");
        enfermedad.opc = int.Parse(Console.ReadLine());
        if (enfermedad.opc != null)
        {
            Console.Clear();
            // Mostrar catálogo
            Console.WriteLine("Catálogo de medicamentos:");
            foreach (Medicamento medicamento in catalogo)
            {
                Console.WriteLine("- " + medicamento.Nombre + " (" + medicamento.Tipo + ")");
                Console.WriteLine("  Cantidad: " + medicamento.Cantidad + " " + medicamento.Unidad);
                Console.WriteLine("  Fecha de vencimiento: " + medicamento.FechaVencimiento.ToString("dd/MM/yyyy"));
            }

            // Realizar venta
            Console.WriteLine("Ingrese el nombre del medicamento que desea comprar:");
            string nombreMedicamento = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad que desea comprar:");
            int cantidad = int.Parse(Console.ReadLine());
            Medicamento medicamentoSeleccionado = catalogo.Find(m => m.Nombre == nombreMedicamento);
            if (medicamentoSeleccionado != null && medicamentoSeleccionado.Cantidad >= cantidad)
            {
                double precioTotal = cantidad * medicamentoSeleccionado.Precio;
            

                // Actualizar inventario
                medicamentoSeleccionado.Cantidad -= cantidad;

                // Registrar venta
                Venta venta = new Venta(cliente, medicamentoSeleccionado, cantidad, precioTotal, DateTime.Now);
                Console.WriteLine("La venta ha sido registrada correctamente.");
                Console.WriteLine("\nLa Factura esta a nombre de\n" + cliente.Nombre + "\nApellido: "+cliente.Apellido + "\nEdad: " + cliente.edad);
                Console.WriteLine("El precio total es: $" + precioTotal);
            }
            else
            {
                Console.WriteLine("El medicamento seleccionado no está disponible o no existe.");
            }
        }
    }
        }
        

class Medicamento
{
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Cantidad { get; set; }
    public int Dosis { get; set; }
    public string Unidad { get; set; }
    public double Precio { get; set; }
    public DateTime FechaVencimiento { get; set; }

    public Medicamento(string nombre, string tipo, int cantidad, int dosis, DateTime fechaVencimiento)
    {
        Nombre = nombre;
        Tipo = tipo;
        Cantidad = cantidad;
        Dosis = dosis;
        FechaVencimiento = fechaVencimiento;

        if (tipo == "Pastillas")
        {
            Unidad = "unidades";
            Precio = 0.02;
        }
        else if (tipo == "Jarabe")
        {
            Unidad = "miligramos";
            Precio = 0.01; // Precio por miligramo
        }
        else if (tipo == "Inyección")
        {
            Unidad = "miligramos";
            Precio = 0.02; // Precio por miligramo
        }
        else if (tipo == "Pomada")
        {
            Unidad = "gramos";
            Precio = 0.05; // Precio por gramo
        }
    }
}
class Cliente
{
    public string Nombre;
    public string Apellido;
    public int edad;
}
class Venta
{
    public Cliente Cliente { get; set; }
    public Medicamento Medicamento { get; set; }
    public int Cantidad { get; set; }
    public double PrecioTotal { get; set; }
    public DateTime FechaVenta { get; set; }
    public Venta(Cliente cliente, Medicamento medicamento, int cantidad, double precioTotal, DateTime fechaVenta)
    {
        Cliente = cliente;
        Medicamento = medicamento;
        Cantidad = cantidad;
        PrecioTotal = precioTotal;
        FechaVenta = fechaVenta;
    }
}

class Enfermedad
{
    public string enfermedad1 = "1.Calentura", enfermedad2 = "2.Gripe", enfermedad3 = "3.Diarrea",enfermedad4 = "4.Migraña";
    public int opc;
}