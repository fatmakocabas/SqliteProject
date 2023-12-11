using Microsoft.EntityFrameworkCore;

namespace SqLiteProject.Models
{
    public class SqLiteContext:DbContext

    {
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\Data\SqliteDb.db");
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
