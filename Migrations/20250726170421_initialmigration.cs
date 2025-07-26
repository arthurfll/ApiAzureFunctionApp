using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAzureFunctionApp.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Nota1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota3 = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota4 = table.Column<int>(type: "INTEGER", nullable: false),
                    Media = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
