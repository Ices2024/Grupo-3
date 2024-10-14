﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class ProveedorDTO
    {
        public int Proveedor_ID { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        // Si quieres mostrar o asociar productos del proveedor en el DTO
        public List<ProductoDTO>? Productos { get; set; }
    }
}
