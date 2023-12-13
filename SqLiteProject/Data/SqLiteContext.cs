using Microsoft.EntityFrameworkCore;
using SqLiteProject.Models;

namespace SqLiteProject.Data
{
    public class SqLiteContext : DbContext

    {
        public DbSet<UserModel> Users { get; set; }

        public SqLiteContext(DbContextOptions<SqLiteContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(@"Data Source=.\\Data\\SqliteDb.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.UserName);
                entity.Property(e => e.Email);

                entity.HasData(new UserModel { Id = 1, Name = "Fatma", UserName = "fkocabas", Email = "fkocabas3581@gmail.com" });

            });
            base.OnModelCreating(modelBuilder);
        }
    }

}
