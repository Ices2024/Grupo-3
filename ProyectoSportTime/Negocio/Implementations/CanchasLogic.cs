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
        public void AltaCancha(int deporteID)
        {
            using (var context = new ProyectoDbContext())
            {
                // Opcional: validar si el deporte con el ID existe
                var deporte = context.Deportes.Find(deporteID);
                if (deporte == null)
                {
                    throw new Exception($"No se encontró un deporte con el ID {deporteID}.");
                }

                var nuevaCancha = new Canchas
                {
                    Deporte_ID = deporteID // Utiliza la clave foránea correcta
                };
                context.Canchas.Add(nuevaCancha);
                context.SaveChanges();
            }
        }

        public void ModificarCancha(int canchaID, int nuevoDeporteID)
        {
            using (var context = new ProyectoDbContext())
            {
                var cancha = context.Canchas.Find(canchaID);
                if (cancha != null)
                {
                    // Opcional: validar si el deporte con el nuevo ID existe
                    var nuevoDeporte = context.Deportes.Find(nuevoDeporteID);
                    if (nuevoDeporte == null)
                    {
                        throw new Exception($"No se encontró un deporte con el ID {nuevoDeporteID}.");
                    }

                    cancha.Deporte_ID = nuevoDeporteID; // Actualiza la clave foránea
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró una cancha con el ID {canchaID}.");
                }
            }
        }

        public void BajaCancha(int canchaID)
        {
            using (var context = new ProyectoDbContext())
            {
                var cancha = context.Canchas.Find(canchaID);
                if (cancha != null)
                {
                    context.Canchas.Remove(cancha);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception($"No se encontró una cancha con el ID {canchaID}.");
                }
            }
        }
    }


}
