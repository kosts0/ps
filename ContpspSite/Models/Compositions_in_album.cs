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
    
    public partial class Compositions_in_album
    {
        public int Number { get; set; }
        public System.Guid ID_Composition { get; set; }
        public System.Guid ID_Albom { get; set; }
    
        public virtual Albom Albom { get; set; }
        public virtual Compositions Compositions { get; set; }
    }
}