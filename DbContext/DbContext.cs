using KinoCrud.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KinoCrud.DbContext
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Kino> Kinos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kino>().HasData(
                new Kino
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Интерстеллар",
                    Rate = 8.6,
                    Description = "Когда засуха и вымирание растений приводят человечество к продовольственному кризису...",
                    PosterUrl = "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=500&q=80"
                },
                new Kino
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Начало",
                    Rate = 8.8,
                    Description = "Кобб — вор, лучший из лучших в опасном искусстве извлечения...",
                    PosterUrl = "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=500&q=80"
                },
                new Kino
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Темный рыцарь",
                    Rate = 9.0,
                    Description = "Бэтмен поднимает ставки в войне с криминалом...",
                    PosterUrl = "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?w=500&q=80"
                }
            );
        }
    }
}
