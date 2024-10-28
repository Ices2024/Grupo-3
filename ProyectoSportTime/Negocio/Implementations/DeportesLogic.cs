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
    public class DeportesLogic : InterfaceDeportes
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public DeportesLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaDeporte(string tipo)
        {
            var nuevoDeporte = new Deportes
            {
                Tipo = tipo
            };
            _context.Deportes.Add(nuevoDeporte);
            _context.SaveChanges();
        }

        public void ModificarDeporte(int deporteID, string nuevoTipo)
        {
            var deporte = _context.Deportes.Find(deporteID);
            if (deporte != null)
            {
                deporte.Tipo = nuevoTipo;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un deporte con ID {deporteID}.");
            }
        }

        public void BajaDeporte(int deporteID)
        {
            var deporte = _context.Deportes.Find(deporteID);
            if (deporte != null)
            {
                _context.Deportes.Remove(deporte);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró un deporte con ID {deporteID}.");
            }
        }
    }

}
