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
    
    public partial class DetalleEstadoUsuario
    {
        public int IdDetalleEstadoUsuario { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFIN { get; set; }
        public Nullable<int> idUsuario { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual USUARIO_LOGIN USUARIO_LOGIN { get; set; }
    }
}
