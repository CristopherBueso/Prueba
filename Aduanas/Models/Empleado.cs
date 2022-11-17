using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aduanas.Models
{
    public partial class Empleado
    {
        public int IdPersona { get; set; }
        public int IdAgencia { get; set; }
        public int IdRol { get; set; }
        [Required]
        public string Usuario { get; set; } = null!;
        [Required, MinLength(8)]
        public string Clave { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Agencia IdAgenciaNavigation { get; set; } = null!;
        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
