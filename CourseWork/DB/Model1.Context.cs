﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseWork.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class k_08Entities : DbContext
    {
        public k_08Entities()
            : base("name=k_08Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookReservation> BookReservation { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<lending_of_books> lending_of_books { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<StatusBook> StatusBook { get; set; }
    }
}
