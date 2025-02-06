using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework
{
    // DbContext : class d'EF qui va définir la class de base de notre Context : la class définit les tables et DbContext définit le contexte
    public class SchoolContext : DbContext
    {
        // définir une liste connectée à la db via DbSet
        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Sections { get; set; }

        // configurer notre DbContext avec nos infos de connexion et le driver utilisé pour se connecter, ici SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-E563U3H;database=DbSlide;integrated security=true;trustservercertificate=true");
        }
    }
}
