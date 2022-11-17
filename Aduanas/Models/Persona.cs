using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aduanas.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdPersona { get; set; }
        [Required]
        public string Nombres { get; set; } = null!;
        [Required]
        public string Apellidos { get; set; } = null!;
        [Required]
        public string Telefono { get; set; } = null!;
        [Required, EmailAddress]
        public string Correo { get; set; } = null!;
        public int? IdPaisOrigen { get; set; }
        public int? IdPaisNaturalizacion { get; set; }
        public int? IdSexo { get; set; }
        [Required, StringLength(13)]
        public string Identidad { get; set; } = null!;

        public virtual Paise? IdPaisNaturalizacionNavigation { get; set; }
        public virtual Paise? IdPaisOrigenNavigation { get; set; }
        public virtual Sexo? IdSexoNavigation { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
