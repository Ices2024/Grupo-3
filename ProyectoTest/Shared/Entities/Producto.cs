﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    internal class Producto : Consumicion
    {
        public int Id_Producto { get; set; }
        public string TipoProducto { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Consumicion> Consumicion { get; set; }

    }
}
