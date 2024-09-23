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
        public void AltaDeporte(string tipo)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoDeporte = new Deportes
                {
                    Tipo = tipo
                };
                context.Deportes.Add(nuevoDeporte);
                context.SaveChanges();
            }
        }

        public void ModificarDeporte(int deporteID, string nuevoTipo)
        {
            using (var context = new ProyectoDbContext())
            {
                var deporte = context.Deportes.Find(deporteID);
                if (deporte != null)
                {
                    deporte.Tipo = nuevoTipo;
                    context.SaveChanges();
                }
            }
        }

        public void BajaDeporte(int deporteID)
        {
            using (var context = new ProyectoDbContext())
            {
                var deporte = context.Deportes.Find(deporteID);
                if (deporte != null)
                {
                    context.Deportes.Remove(deporte);
                    context.SaveChanges();
                }
            }
        }
    }

}
