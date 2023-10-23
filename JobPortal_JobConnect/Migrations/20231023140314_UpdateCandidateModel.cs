using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortal_JobConnect.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCandidateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Candidates",
                newName: "ResumeFile");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "ResumeFile",
                table: "Candidates",
                newName: "ContactInfo");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Candidates",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
