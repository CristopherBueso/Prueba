using System;
using System.Collections.Generic;

namespace Aduanas.Models
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdRol { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
