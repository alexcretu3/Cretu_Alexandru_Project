using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Data
{
    public class Cretu_Alexandru_ProjectContext : DbContext
    {
        public Cretu_Alexandru_ProjectContext (DbContextOptions<Cretu_Alexandru_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Cretu_Alexandru_Project.Models.Reprezentant> Reprezentant { get; set; } = default!;

        public DbSet<Cretu_Alexandru_Project.Models.Trupa> Trupa { get; set; }

        public DbSet<Cretu_Alexandru_Project.Models.Sala> Sala { get; set; }

        public DbSet<Cretu_Alexandru_Project.Models.Echipament> Echipament { get; set; }

        public DbSet<Cretu_Alexandru_Project.Models.Rezervare> Rezervare { get; set; }
    }
}
