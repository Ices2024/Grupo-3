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

        public void AltaDeporte(string tipo)
        {
            Deportes deporteNuevo = new Deportes
            {
                Tipo = tipo,
            };

            context.Deportes.Add(deporteNuevo);
            context.SaveChanges();
        }

        public void AltaElementos(string nombre, int cantidad, int canchaId)
        {
            Canchas canchas = context.Canchas.Find(canchaId);

            if (canchas != null)
            {
                Elementos elementoNuevo = new Elementos
                {
                    Nombre = nombre,
                    Cantidad = cantidad,
                    Cancha_ID = canchaId,
                    Canchas = canchas
                };

                context.Elementos.Add(elementoNuevo);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error: Cancha no encontrada.");
            }
        }


        public void AltaProducto(string tipo, string descripcion, int proveedorId)
        {
            Proveedores proveedor = context.Proveedores.Find(proveedorId);

            if (proveedor != null)
            {
                Productos nuevoProducto = new Productos
                {
                    Tipo = tipo,
                    Descripcion = descripcion,
                    Proveedor_ID = proveedorId,
                    Proveedores = proveedor
                };

                context.Productos.Add(nuevoProducto);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error: Proveedor no encontrado.");
            }
        }
        
        public void AltaProveedor(string nombre, string email, string telefono)
        {
            Proveedores nuevoProveedor = new Proveedores
            {
                Nombre = nombre,
                Email = email,
                Telefono = telefono
            };

            context.Proveedores.Add(nuevoProveedor);
            context.SaveChanges();
        }

        public void AltaConsumicion(int cantidad, bool precio, int codProducto)
        {
            Productos productos = context.Productos.Find(codProducto);

            if (productos != null)  // Corrige la condición
            {
                Consumiciones nuevaConsumicion = new Consumiciones
                {
                    Cantidad = cantidad,
                    Precio = precio,
                    Cod_Producto = codProducto,
                    Producto = productos
                };

                context.Consumiciones.Add(nuevaConsumicion);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Error: Producto no encontrado.");
            }
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
    


