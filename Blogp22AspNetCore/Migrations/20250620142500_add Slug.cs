﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogp22AspNetCore.Migrations
{
    /// <inheritdoc />
    public partial class addSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Articles");
        }
    }
}
