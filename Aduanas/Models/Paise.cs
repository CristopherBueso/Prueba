using System;
using System.Collections.Generic;

namespace Aduanas.Models
{
    public partial class Paise
    {
        public Paise()
        {
            Agencia = new HashSet<Agencia>();
            PersonaIdPaisNaturalizacionNavigations = new HashSet<Persona>();
            PersonaIdPaisOrigenNavigations = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Habilitado { get; set; }

        public virtual ICollection<Agencia> Agencia { get; set; }
        public virtual ICollection<Persona> PersonaIdPaisNaturalizacionNavigations { get; set; }
        public virtual ICollection<Persona> PersonaIdPaisOrigenNavigations { get; set; }
    }
}
