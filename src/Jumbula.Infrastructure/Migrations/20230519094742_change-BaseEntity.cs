using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jumbula.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Families");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Parents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Students_FamilyId",
                table: "Students",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_FamilyId",
                table: "Parents",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Families_FamilyId",
                table: "Parents",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Families_FamilyId",
                table: "Students",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Families_FamilyId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Families_FamilyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FamilyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Parents_FamilyId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Parents");

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Families",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
