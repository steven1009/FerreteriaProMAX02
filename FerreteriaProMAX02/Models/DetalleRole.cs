//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FerreteriaProMAX02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleRole
    {
        public int Id_DetalleRoles { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<System.DateTime> FechaMOD { get; set; }
        public Nullable<int> IdRoles { get; set; }
    
        public virtual USUARIO_LOGIN USUARIO_LOGIN { get; set; }
        public virtual Role Role { get; set; }
    }
}
