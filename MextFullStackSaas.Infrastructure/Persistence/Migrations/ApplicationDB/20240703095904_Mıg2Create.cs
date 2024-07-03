using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullStackSaas.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class Mıg2Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfileImage" },
                values: new object[] { "6201b9c9-d7bb-4a0b-9372-3be7a3125f41", "AQAAAAIAAYagAAAAEKh1axtQwWaZc22h3XuCgLm0ThtdXEdRxJoswdehUWag/DTs06ZYMeOcWhiedRZ+2w==", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9160420-172d-4dc0-adea-c7468e9ceb7d", "AQAAAAIAAYagAAAAEMXALLlEWjlfKlO4avjDuVbCkb/b+HAkAD3j0OXo/Y/izq6fCF58+JdrfDh4kV7XEA==" });
        }
    }
}
