using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGC.CareShare.WebAPI.Migrations
{
    public partial class Introducedinvitationschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseGroupMembers_ExpenseGroups_ExpenseGroupId",
                table: "ExpenseGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseGroupMembers_Profiles_ProfileId",
                table: "ExpenseGroupMembers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "ExpenseGroupMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ExpenseGroupId",
                table: "ExpenseGroupMembers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseGroupInvitations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Acceptance = table.Column<int>(type: "int", nullable: false),
                    ExpenseGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvitationProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastEdited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseGroupInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseGroupInvitations_ExpenseGroups_ExpenseGroupId",
                        column: x => x.ExpenseGroupId,
                        principalTable: "ExpenseGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseGroupInvitations_Profiles_InvitationProfileId",
                        column: x => x.InvitationProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpenseGroupInvitations_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseGroupInvitations_ExpenseGroupId",
                table: "ExpenseGroupInvitations",
                column: "ExpenseGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseGroupInvitations_InvitationProfileId",
                table: "ExpenseGroupInvitations",
                column: "InvitationProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseGroupInvitations_ProfileId",
                table: "ExpenseGroupInvitations",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseGroupMembers_ExpenseGroups_ExpenseGroupId",
                table: "ExpenseGroupMembers",
                column: "ExpenseGroupId",
                principalTable: "ExpenseGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseGroupMembers_Profiles_ProfileId",
                table: "ExpenseGroupMembers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseGroupMembers_ExpenseGroups_ExpenseGroupId",
                table: "ExpenseGroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseGroupMembers_Profiles_ProfileId",
                table: "ExpenseGroupMembers");

            migrationBuilder.DropTable(
                name: "ExpenseGroupInvitations");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "ExpenseGroupMembers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ExpenseGroupId",
                table: "ExpenseGroupMembers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseGroupMembers_ExpenseGroups_ExpenseGroupId",
                table: "ExpenseGroupMembers",
                column: "ExpenseGroupId",
                principalTable: "ExpenseGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseGroupMembers_Profiles_ProfileId",
                table: "ExpenseGroupMembers",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
