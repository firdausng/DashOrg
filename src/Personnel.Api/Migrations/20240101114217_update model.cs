using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personnel.Api.Migrations
{
    /// <inheritdoc />
    public partial class updatemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_EmergencyContact_EmergencyContactId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_PersonalInformation_PersonalInformationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Photo_PhotoId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoId",
                table: "Members",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonalInformationId",
                table: "Members",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmergencyContactId",
                table: "Members",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_EmergencyContact_EmergencyContactId",
                table: "Members",
                column: "EmergencyContactId",
                principalTable: "EmergencyContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_PersonalInformation_PersonalInformationId",
                table: "Members",
                column: "PersonalInformationId",
                principalTable: "PersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Photo_PhotoId",
                table: "Members",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_EmergencyContact_EmergencyContactId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_PersonalInformation_PersonalInformationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Photo_PhotoId",
                table: "Members");

            migrationBuilder.AlterColumn<Guid>(
                name: "PhotoId",
                table: "Members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonalInformationId",
                table: "Members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmergencyContactId",
                table: "Members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_EmergencyContact_EmergencyContactId",
                table: "Members",
                column: "EmergencyContactId",
                principalTable: "EmergencyContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_PersonalInformation_PersonalInformationId",
                table: "Members",
                column: "PersonalInformationId",
                principalTable: "PersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Photo_PhotoId",
                table: "Members",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
