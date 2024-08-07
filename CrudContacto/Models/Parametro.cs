using System;
using System.Collections.Generic;

namespace CrudContacto.Models
{
    public partial class Parametro
    {
        public int Id { get; set; }
        public int? AgenciaId { get; set; }
        public string? OrigenId { get; set; }
        public string DestinoId { get; set; } = null!;
        public string Parametro1 { get; set; } = null!;
        public string? Valor { get; set; }
        public byte[]? ValorCifrado { get; set; }
    }
}
