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
                    Id = "a1b2c3d4-0001-0000-0000-000000000001",
                    Name = "Интерстеллар",
                    Rate = 8.6,
                    Description = "Когда засуха и вымирание растений приводят человечество к продовольственному кризису...",
                    PosterUrl = "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=500&q=80",
                    TrailterUrl = "https://www.youtube.com/watch?v=qcPfI0y7wRU"
                },
                new Kino
                {
                    Id = "a1b2c3d4-0002-0000-0000-000000000002",
                    Name = "Начало",
                    Rate = 8.8,
                    Description = "Кобб — вор, лучший из лучших в опасном искусстве извлечения...",
                    PosterUrl = "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=500&q=80",
                    TrailterUrl = "https://www.youtube.com/watch?v=RWUnA-9_b0c"
                },
                new Kino
                {
                    Id = "a1b2c3d4-0003-0000-0000-000000000003",
                    Name = "Темный рыцарь",
                    Rate = 9.0,
                    Description = "Бэтмен поднимает ставки в войне с криминалом...",
                    PosterUrl = "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?w=500&q=80",
                    TrailterUrl = "https://www.youtube.com/watch?v=ZAaUUkOIeqI"
                }
            );
        }
    }
}
