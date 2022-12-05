using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app_house.Models;

    public class apphouseContext : DbContext
    {
        public apphouseContext (DbContextOptions<apphouseContext> options)
            : base(options)
        {
        }

        public DbSet<app_house.Models.Casa> Casa { get; set; } = default!;

        public DbSet<app_house.Models.Cliente>? Cliente { get; set; }

        public DbSet<app_house.Models.Localidad>? Localidad { get; set; }

        public DbSet<app_house.Models.Alquiler>? Alquiler { get; set; }

        public DbSet<app_house.Models.Devolver>? Devolver { get; set; }
    }
