//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestiónEmpleados.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class JefeEquipos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JefeEquipos()
        {
            this.Tecnicos = new HashSet<Tecnicos>();
        }
    
        public int Id { get; set; }
        public int IdDT { get; set; }
    
        public virtual TrabajoresDT TrabajoresDT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tecnicos> Tecnicos { get; set; }
    }
}
