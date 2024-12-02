using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class create_full_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImgPath", "LastName", "Password", "Phone", "UserName" },
                values: new object[,]
                {
                    { 1L, "admin@example.com", "Karim", null, "Khairy", "AQAAAAEAACcQAAAAEIHwIQs4yBoSwjyOcKLVBOqOLEG3SorntvkC+eaKsu8plBmtuhpCDbRjV9UhleyVDQ==", "01112202144", "admin" },
                    { 2L, "admin2@example.com", "Mohamed", null, "Gazzar", "AQAAAAEAACcQAAAAED9EMoRBp+l+V74kHwsKOpD6I7C+L/yiNdZJarH0f56O03AD1vAASn7UJ9rF26LCLA==", null, "admin2" },
                    { 3L, "karim.khairy@example.com", "Karim2", null, "Khairy2", "AQAAAAEAACcQAAAAEFOLTXpn6deLP4Y6e9j9UlcqYmq1tb6p/atrUX0OhEwKdRicq64FROAnU8rU34QHmg==", null, "karim.khairy" },
                    { 4L, "mohmaed.diaa@example.com", "Mohamed", null, "Diaa", "AQAAAAEAACcQAAAAEMTwUp35fWj2FijPG8xEciLOS3mt0/ii0XPLuB7WeocDgHmYmwJJsvxI4ffdV9+knA==", null, "mohmaed.diaa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
