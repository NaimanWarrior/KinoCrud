using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KinoCrud.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrailersEmbedUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "2ff07bdc-5168-4dee-b25a-e571fe046b3e");

            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "3307b63a-62a3-4e6a-9267-942d1f2811a7");

            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "d52f13fd-9775-4ce7-ab27-9791023f7f95");

            migrationBuilder.RenameColumn(
                name: "TrailterUrl",
                table: "Kinos",
                newName: "TrailerUrl");

            migrationBuilder.InsertData(
                table: "Kinos",
                columns: new[] { "Id", "Description", "Name", "PosterUrl", "Rate", "TrailerUrl" },
                values: new object[,]
                {
                    { "a1b2c3d4-0001-0000-0000-000000000001", "Когда засуха и вымирание растений приводят человечество к продовольственному кризису...", "Интерстеллар", "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=500&q=80", 8.5999999999999996, "https://www.youtube.com/embed/qcPfI0y7wRU" },
                    { "a1b2c3d4-0002-0000-0000-000000000002", "Кобб — вор, лучший из лучших в опасном искусстве извлечения...", "Начало", "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=500&q=80", 8.8000000000000007, "https://www.youtube.com/embed/RWUnA-9_b0c" },
                    { "a1b2c3d4-0003-0000-0000-000000000003", "Бэтмен поднимает ставки в войне с криминалом...", "Темный рыцарь", "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?w=500&q=80", 9.0, "https://www.youtube.com/embed/ZAaUUkOIeqI" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-0001-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-0002-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Kinos",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-0003-0000-0000-000000000003");

            migrationBuilder.RenameColumn(
                name: "TrailerUrl",
                table: "Kinos",
                newName: "TrailterUrl");

            migrationBuilder.InsertData(
                table: "Kinos",
                columns: new[] { "Id", "Description", "Name", "PosterUrl", "Rate", "TrailterUrl" },
                values: new object[,]
                {
                    { "2ff07bdc-5168-4dee-b25a-e571fe046b3e", "Когда засуха и вымирание растений приводят человечество к продовольственному кризису...", "Интерстеллар", "https://images.unsplash.com/photo-1534447677768-be436bb09401?w=500&q=80", 8.5999999999999996, "" },
                    { "3307b63a-62a3-4e6a-9267-942d1f2811a7", "Бэтмен поднимает ставки в войне с криминалом...", "Темный рыцарь", "https://images.unsplash.com/photo-1509198397868-475647b2a1e5?w=500&q=80", 9.0, "" },
                    { "d52f13fd-9775-4ce7-ab27-9791023f7f95", "Кобб — вор, лучший из лучших в опасном искусстве извлечения...", "Начало", "https://images.unsplash.com/photo-1440404653325-ab127d49abc1?w=500&q=80", 8.8000000000000007, "" }
                });
        }
    }
}
