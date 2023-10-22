using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_JobConnect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAddedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserAuthModels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "UserAuthModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "UserAuthModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "UserAuthModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "UserAuthModels",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "UserAuthModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "UserAuthModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserAuthModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthModels",
                table: "UserAuthModels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthModels",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "UserAuthModels");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserAuthModels");
        }
    }
}
