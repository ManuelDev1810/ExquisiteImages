using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExquisiteImagesApi.Migrations
{
    public partial class AddingDateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "CommentContent");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Images",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Images",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Comments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Comments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Comments",
                nullable: false,
                defaultValue: "");
        }
    }
}
