using Microsoft.EntityFrameworkCore;
using Negocio.Contracts;
using Shared.Dtos;
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
        public void AltaCancha(int codigoDeporte)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevaCancha = new Canchas
                {
                    Codigo_Deporte = codigoDeporte
                };
                context.Canchas.Add(nuevaCancha);
                context.SaveChanges();
            }
        }

        public void ModificarCancha(int canchaID, int nuevoCodigoDeporte)
        {
            using (var context = new ProyectoDbContext())
            {
                var cancha = context.Canchas.Find(canchaID);
                if (cancha != null)
                {
                    cancha.Codigo_Deporte = nuevoCodigoDeporte;
                    context.SaveChanges();
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
            }
        }
    }

}
