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
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public ConsumicionesLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaConsumicion(int cantidad, decimal precio, int codProducto)
        {
            var nuevaConsumicion = new Consumiciones
            {
                Cantidad = cantidad,
                Precio = precio,
                Cod_Producto = codProducto
            };
            _context.Consumiciones.Add(nuevaConsumicion);
            _context.SaveChanges();
        }

        public void ModificarConsumicion(int consumicionID, int nuevaCantidad, decimal nuevoPrecio)
        {
            var consumicion = _context.Consumiciones.Find(consumicionID);
            if (consumicion != null)
            {
                consumicion.Cantidad = nuevaCantidad;
                consumicion.Precio = nuevoPrecio;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró una consumición con ID {consumicionID}.");
            }
        }

        public void BajaConsumicion(int consumicionID)
        {
            var consumicion = _context.Consumiciones.Find(consumicionID);
            if (consumicion != null)
            {
                _context.Consumiciones.Remove(consumicion);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró una consumición con ID {consumicionID}.");
            }
        }
    }

}
