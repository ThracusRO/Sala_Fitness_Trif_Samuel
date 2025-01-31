using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sala_Fitness_Trif_Samuel.Models;

namespace Sala_Fitness_Trif_Samuel.Data
{
    public class Sala_Fitness_Trif_SamuelContext : DbContext
    {
        public Sala_Fitness_Trif_SamuelContext (DbContextOptions<Sala_Fitness_Trif_SamuelContext> options)
            : base(options)
        {
        }

        public DbSet<Sala_Fitness_Trif_Samuel.Models.Abonament> Abonament { get; set; } = default!;
        public DbSet<Sala_Fitness_Trif_Samuel.Models.Antrenor> Antrenor { get; set; } = default!;
        public DbSet<Sala_Fitness_Trif_Samuel.Models.Programare> Programare { get; set; } = default!;
        public DbSet<Sala_Fitness_Trif_Samuel.Models.Specializare> Specializare { get; set; } = default!;
        public DbSet<Sala_Fitness_Trif_Samuel.Models.TipAbonament> TipAbonament { get; set; } = default!;
        public DbSet<Sala_Fitness_Trif_Samuel.Models.Utilizator> Utilizator { get; set; } = default!;
    }
}
