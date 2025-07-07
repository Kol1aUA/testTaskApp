using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace testTaskApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "EndDate", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 7, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(330), new DateTime(2025, 5, 7, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(190), "Free" },
                    { 2, new DateTime(2025, 7, 14, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(460), new DateTime(2025, 6, 30, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(440), "Trial" },
                    { 3, new DateTime(2026, 1, 7, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(460), new DateTime(2025, 7, 7, 5, 1, 17, 575, DateTimeKind.Utc).AddTicks(460), "Super" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "SubscriptionId" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice", 1 },
                    { 2, "bob@example.com", "Bob", 3 },
                    { 3, "carlos@example.com", "Carlos", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
