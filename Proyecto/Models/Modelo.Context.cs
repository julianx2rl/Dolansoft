﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BACKLOG> BACKLOG { get; set; }
        public virtual DbSet<MILESTONE> MILESTONE { get; set; }
        public virtual DbSet<PERMISSION> PERMISSION { get; set; }
        public virtual DbSet<PROJECT> PROJECT { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<SCENARIO> SCENARIO { get; set; }
        public virtual DbSet<SPRINT> SPRINT { get; set; }
        public virtual DbSet<TASK> TASK { get; set; }
        public virtual DbSet<USER_STORY> USER_STORY { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
    }
}
