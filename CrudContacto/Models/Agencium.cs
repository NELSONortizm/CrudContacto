using System;
using System.Collections.Generic;

namespace CrudContacto.Models
{
    public partial class Agencium
    {
        public int Id { get; set; }
        public string AgencyId { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Departamento { get; set; } = null!;
        public bool Activo { get; set; }
    }
}
