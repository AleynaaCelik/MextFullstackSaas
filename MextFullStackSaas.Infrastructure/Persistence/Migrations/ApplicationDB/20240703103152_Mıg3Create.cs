using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullStackSaas.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class Mıg3Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b370dab7-0f57-423e-8632-0c2ad97f6299", "AQAAAAIAAYagAAAAEAPm0wGD7ZfhPEJpbO96iyj0i44tkwuOcoAp7H7bfY8PWWmxNz13vzu6cBdMDK8Awg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6201b9c9-d7bb-4a0b-9372-3be7a3125f41", "AQAAAAIAAYagAAAAEKh1axtQwWaZc22h3XuCgLm0ThtdXEdRxJoswdehUWag/DTs06ZYMeOcWhiedRZ+2w==" });
        }
    }
}
