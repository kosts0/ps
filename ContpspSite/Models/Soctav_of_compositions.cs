//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Soctav_of_compositions
    {
        public bool Guest { get; set; }
        public System.Guid ID_composition { get; set; }
        public System.Guid ID_Project { get; set; }
    
        public virtual Compositions Compositions { get; set; }
        public virtual Projects Projects { get; set; }
    }
}
