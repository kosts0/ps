﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IDZnewEntities1 : DbContext
    {
        public IDZnewEntities1()
            : base("name=IDZnewEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Albom> Albom { get; set; }
        public virtual DbSet<Compositions> Compositions { get; set; }
        public virtual DbSet<Compositions_in_album> Compositions_in_album { get; set; }
        public virtual DbSet<Musicians> Musicians { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Soctav_of_compositions> Soctav_of_compositions { get; set; }
        public virtual DbSet<Sostav_of_project> Sostav_of_project { get; set; }
    }
}
