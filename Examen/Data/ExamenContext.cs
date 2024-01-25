using Examen.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Examen.Data
{
    public class ExamenContext : DbContext
    {
        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options) { }

        public DbSet<Autor> Autori { get; set; }
        public DbSet<Carte> Carti { get; set; }
        public DbSet<Editura> Edituri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.AutorId, mr.CarteId });

            // One to many for m-m
            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Autor)
                        .WithMany(m3 => m3.ModelsRelations)
                        .HasForeignKey(mr => mr.AutorId);

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Carte)
                        .WithMany(m4 => m4.ModelsRelations)
                        .HasForeignKey(mr => mr.CarteId);


            modelBuilder.Entity<Editura>()
                .HasMany(e => e.Autori)
                .WithOne(b => b.EdituraCarte);
        }
    }
}
