using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using API.Data;
using Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Implementations
{
    public class ConsumicionesLogic : InterfaceConsumicion
    {
        public void AltaConsumicion(int cantidad, bool precio, int codProducto)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevaConsumicion = new Consumiciones
                {
                    Cantidad = cantidad,
                    Precio = precio,
                    Cod_Producto = codProducto
                };
                context.Consumiciones.Add(nuevaConsumicion);
                context.SaveChanges();
            }
        }

        public void ModificarConsumicion(int consumicionID, int nuevaCantidad, bool nuevoPrecio)
        {
            using (var context = new ProyectoDbContext())
            {
                var consumicion = context.Consumiciones.Find(consumicionID);
                if (consumicion != null)
                {
                    consumicion.Cantidad = nuevaCantidad;
                    consumicion.Precio = nuevoPrecio;
                    context.SaveChanges();
                }
            }
        }

        public void BajaConsumicion(int consumicionID)
        {
            using (var context = new ProyectoDbContext())
            {
                var consumicion = context.Consumiciones.Find(consumicionID);
                if (consumicion != null)
                {
                    context.Consumiciones.Remove(consumicion);
                    context.SaveChanges();
                }
            }
        }
    }

}
