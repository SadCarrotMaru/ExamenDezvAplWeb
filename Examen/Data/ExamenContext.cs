using Examen.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Data
{
    public class ExamenContext: DbContext
    {
        public ExamenContext(DbContextOptions<ExamenContext> options) : base(options) { }

        public DbSet<TestModel> TestModels {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
