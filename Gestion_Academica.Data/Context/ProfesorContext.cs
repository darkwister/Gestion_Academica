﻿using Gestion_Academica.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Data.Context
{
    public class ProfesorContext : DbContext
    {
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options) 
        {
            
        }
        public ProfesorContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Profesores");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
