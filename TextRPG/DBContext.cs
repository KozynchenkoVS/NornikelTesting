using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TextRPG
{
    public class RPGContext : DbContext
    {
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Character>? Characters { get; set; }
        public virtual DbSet<Skill>? Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=DESKTOP-TSHMHUG;Database=RPGAlpha;Trusted_Connection=True;");
            base.OnConfiguring(options);
        }
        public void CreateIfDontExist()
        {
            this.Database.EnsureCreated();
        }
        
    }
}
