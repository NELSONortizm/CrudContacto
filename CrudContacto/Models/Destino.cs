using System;
using System.Collections.Generic;

namespace CrudContacto.Models
{
    public partial class Destino
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
