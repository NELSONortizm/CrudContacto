using System;
using System.Collections.Generic;

namespace CrudContacto.Models
{
    public partial class Origen
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
