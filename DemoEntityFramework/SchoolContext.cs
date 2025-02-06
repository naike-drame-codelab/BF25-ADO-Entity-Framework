using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework
{
    // Une instance de DbContext représentera une session avec la base de données, qui permettra d'interagir directement avec elle.
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
