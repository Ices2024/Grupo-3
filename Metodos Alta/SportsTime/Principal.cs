using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime
{
    public class Principal
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

        public void AltaAdministrador(string nombre, string email)
        {
            Administrador nuevoAdministrador = new Administrador
            {
                Nombre = nombre,
                Email = email
            };

            context.Administradores.Add(nuevoAdministrador);
            context.SaveChanges();
        }

        public void AltaCancha(int codigoDeporte, Deportes deporte)
        {
            Canchas nuevaCancha = new Canchas
            {
                Codigo_Deporte = codigoDeporte,
                Deporte = deporte
            };

            context.Canchas.Add(nuevaCancha);
            context.SaveChanges();
        }

        public void AltaTurno(int adminId, int canchaId, DateTime horaInicio, DateTime horaFin, int consumicionId)
        {
            
            Administrador administrador = context.Administradores.Find(adminId);
            Canchas cancha = context.Canchas.Find(canchaId);
            Consumiciones consumicion = context.Consumiciones.Find(consumicionId);

            if (administrador != null && cancha != null && consumicion != null)
            {
                Turnos nuevoTurno = new Turnos
                {
                    Admin_ID = adminId,
                    Cancha_ID = canchaId,
                    HoraInicio = horaInicio,
                    HoraFin = horaFin,
                    Consumicion_ID = consumicionId,
                    Administrador = administrador,
                    Canchas = cancha,
                    Consumicion = consumicion
                };

                context.Turnos.Add(nuevoTurno);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error: Administrador, Cancha o Consumición no encontrados.");
            }
        }
    }
}
    }
}
}
