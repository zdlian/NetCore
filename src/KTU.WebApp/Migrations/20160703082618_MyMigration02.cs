using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KTU.WebApp.Migrations
{
    public partial class MyMigration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UserId1",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserDetail_UserDetailId1",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_UserImage_User_UserId1",
                table: "UserImage");

            migrationBuilder.DropIndex(
                name: "IX_UserImage_UserId1",
                table: "UserImage");

            migrationBuilder.DropIndex(
                name: "IX_User_UserDetailId1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserImage");

            migrationBuilder.DropColumn(
                name: "UserDetailId1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "UserImage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDetailId1",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserImage_UserId1",
                table: "UserImage",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserDetailId1",
                table: "User",
                column: "UserDetailId1");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId1",
                table: "Address",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UserId1",
                table: "Address",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserDetail_UserDetailId1",
                table: "User",
                column: "UserDetailId1",
                principalTable: "UserDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserImage_User_UserId1",
                table: "UserImage",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
