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
    public class CanchasLogic : InterfaceCanchas
    {
        private readonly ProyectoDbContext _context;

        // Constructor donde se inyecta el DbContext
        public CanchasLogic(ProyectoDbContext context)
        {
            _context = context;
        }

        public void AltaCancha(int deporteID)
        {
            // Opcional: validar si el deporte con el ID existe
            var deporte = _context.Deportes.Find(deporteID);
            if (deporte == null)
            {
                throw new Exception($"No se encontró un deporte con el ID {deporteID}.");
            }

            var nuevaCancha = new Canchas
            {
                Deporte_ID = deporteID // Utiliza la clave foránea correcta
            };
            _context.Canchas.Add(nuevaCancha);
            _context.SaveChanges();
        }

        public void ModificarCancha(int canchaID, int nuevoDeporteID)
        {
            var cancha = _context.Canchas.Find(canchaID);
            if (cancha != null)
            {
                // Opcional: validar si el deporte con el nuevo ID existe
                var nuevoDeporte = _context.Deportes.Find(nuevoDeporteID);
                if (nuevoDeporte == null)
                {
                    throw new Exception($"No se encontró un deporte con el ID {nuevoDeporteID}.");
                }

                cancha.Deporte_ID = nuevoDeporteID; // Actualiza la clave foránea
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró una cancha con el ID {canchaID}.");
            }
        }

        public void BajaCancha(int canchaID)
        {
            var cancha = _context.Canchas.Find(canchaID);
            if (cancha != null)
            {
                _context.Canchas.Remove(cancha);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"No se encontró una cancha con el ID {canchaID}.");
            }
        }
    }
}
