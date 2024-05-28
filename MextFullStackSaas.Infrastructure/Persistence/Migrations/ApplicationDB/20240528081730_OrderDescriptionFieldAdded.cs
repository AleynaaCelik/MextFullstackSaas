using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullStackSaas.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class OrderDescriptionFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9160420-172d-4dc0-adea-c7468e9ceb7d", "AQAAAAIAAYagAAAAEMXALLlEWjlfKlO4avjDuVbCkb/b+HAkAD3j0OXo/Y/izq6fCF58+JdrfDh4kV7XEA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3797dd3-6112-404e-8a2f-12f3dec541f5", "AQAAAAIAAYagAAAAEDBYO0tsb9DbvvbDJySb9Ta3nECjCEXlX709VQXvs6hr4a1y1wDTPpGltAssDZwOaQ==" });
        }
    }
}
