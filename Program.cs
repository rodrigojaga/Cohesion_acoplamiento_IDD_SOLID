using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperacionesCliente clienteOps = new OperacionesCliente();
            clienteOps.Registrar("Ana", 25, "ana@mail.com");

            Cliente cliente = new Cliente { Nombre = "Ana", Edad = 25, Email = "ana@mail.com" };
            OperacionesReserva reservaOps = new OperacionesReserva(new Correo);
            reservaOps.Crear(cliente, "AV123");
        }
    }
}
