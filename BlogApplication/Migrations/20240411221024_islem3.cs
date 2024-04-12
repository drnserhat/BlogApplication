﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class islem3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Hizmetlers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Hizmetlers");
        }
    }
}
