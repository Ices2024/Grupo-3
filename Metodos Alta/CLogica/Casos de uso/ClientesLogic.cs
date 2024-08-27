using SportsTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLogica.Casos_de_uso
{
    public class ClientesLogic
    {
        public ProyectoDBcontext context = new ProyectoDBcontext();

        public void AltaCliente(string nombre, int telefono)
        {
            Clientes nuevoCliente = new Clientes
            {
                Nombre = nombre,
                NumeroTelefono = telefono
            };

            context.Clientes.Add(nuevoCliente);
            context.SaveChanges();
        }
    }
}
