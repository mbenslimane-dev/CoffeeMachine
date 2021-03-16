namespace MugDomain
{
    using MugDomain.Model;
    using Microsoft.EntityFrameworkCore;

    public class MugDBContext : DbContext
    {
        public MugDBContext(DbContextOptions<MugDBContext> options)
            : base(options)
        {
        }

        public DbSet<Mug> Mugs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mug>().ToTable("Mug");
        }

    }
}
