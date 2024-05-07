using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecmanage.eProcessor.Services.FakeFetch.FakeFetch.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SampleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FakeFetchLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeFetchLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FakeFetchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Reminder = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Done = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeFetchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FakeFetchItems_FakeFetchLists_ListId",
                        column: x => x.ListId,
                        principalTable: "FakeFetchLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FakeFetchItems_ListId",
                table: "FakeFetchItems",
                column: "ListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeFetchItems");

            migrationBuilder.DropTable(
                name: "FakeFetchLists");
        }
    }
}
