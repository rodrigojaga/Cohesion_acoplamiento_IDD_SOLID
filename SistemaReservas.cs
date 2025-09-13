using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    
    public class OperacionesCliente
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void Registrar(string nombre, int edad, string email)
        {
            Cliente c = new Cliente();// Referencia a la clase Cliente
            c.Nombre = nombre;
            c.Edad = edad;
            c.Email = email;
            clientes.Add(c);

            ConsolaLog log = new ConsolaLog(); // Referencia a la clase ConsolaLog
            log.agregar("Cliente registrado: " + c.Nombre);

            //CBO = 2 (Cliente, ConsolaLog)
            //Teoricamente esta clase tiene un bajo acoplamiento ya que CBO < 5
        }

    }
    //Intentando aplica inyeccion de dependencias
    public class OperacionesReserva
    {

        private readonly IOperaciones _operaciones;

        public OperacionesReserva(IOperaciones _operaciones)// Referencia a la interfaz IOperaciones
        {
            this._operaciones = _operaciones;
        }

        public void Crear(Cliente cliente, // Referencia a la clase Cliente
            string vuelo)        {
            
            if (cliente.Edad < 18)
            {
                Console.WriteLine("El cliente no puede reservar.");
            }
            else
            {
                Console.WriteLine("Reserva creada para " + cliente.Nombre);
                _operaciones.Enviar(cliente.getContacto, "Reserva confirmada en vuelo " + vuelo);
            }

            //CBO = 2 (Cliente, IOperaciones)
            //Teoricamente esta clase tiene un bajo acoplamiento ya que CBO < 5
        }

    }


    public interface IOperaciones
    {
        public void Enviar(string destino, string mensaje);
    }

    public class Correo: IOperaciones
    {
        public void Enviar(string destino, string mensaje)
        {
            
            Console.WriteLine("Enviando correo a " + destino + ": " + mensaje);
        }

        //CBO = 0
        //Teoricamente esta clase tiene un bajo acoplamiento ya que CBO < 5
    }

    public class WhatsApp: IOperaciones
    {
        public void Enviar(string destino, string mensaje)
        {
            Console.WriteLine("Enviando WhatsApp a " + destino + ": " + mensaje);
        }

        //CBO = 0
    }

}

    //internal class SistemaReservas
    //{
    //    //No es necesario mantener una lista de clientes en este ejemplo
    //    //private List<Cliente> clientes = new List<Cliente>();

    //    public void RegistrarCliente(string nombre, int edad, string email)
    //    {
    //        Cliente c = new Cliente();
    //        c.Nombre = nombre;
    //        c.Edad = edad;
    //        c.Email = email;
    //        clientes.Add(c);

    //        // Escribe directamente en logs globales -> acoplamiento común
    //        Globals.logs.Add("Cliente registrado: " + c.Nombre);
    //    }

    //    public void CrearReserva(Cliente cliente, string vuelo)
    //    {
    //        // Acceso directo a atributos de Cliente -> acoplamiento de contenido
    //        if (cliente.Edad < 18)
    //        {
    //            Console.WriteLine("El cliente no puede reservar.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Reserva creada para " + cliente.Nombre);
    //            EnviarCorreo(cliente.Email, "Reserva confirmada en vuelo " + vuelo);
    //        }
    //    }

    //    public void EnviarCorreo(string destino, string mensaje)
    //    {
    //        // Método dentro del mismo sistema -> baja cohesión
    //        Console.WriteLine("Enviando correo a " + destino + ": " + mensaje);
    //    }
    //}
