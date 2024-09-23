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
    public class ElementosLogic : InterfaceElementos
    {
        public void AltaElemento(string nombre, int cantidad, int canchaID)
        {
            using (var context = new ProyectoDbContext())
            {
                var nuevoElemento = new Elementos
                {
                    Nombre = nombre,
                    Cantidad = cantidad,
                    Cancha_ID = canchaID
                };
                context.Elementos.Add(nuevoElemento);
                context.SaveChanges();
            }
        }

        public void ModificarElemento(int elementoID, string nuevoNombre, int nuevaCantidad)
        {
            using (var context = new ProyectoDbContext())
            {
                var elemento = context.Elementos.Find(elementoID);
                if (elemento != null)
                {
                    elemento.Nombre = nuevoNombre;
                    elemento.Cantidad = nuevaCantidad;
                    context.SaveChanges();
                }
            }
        }

        public void BajaElemento(int elementoID)
        {
            using (var context = new ProyectoDbContext())
            {
                var elemento = context.Elementos.Find(elementoID);
                if (elemento != null)
                {
                    context.Elementos.Remove(elemento);
                    context.SaveChanges();
                }
            }
        }
    }

}
