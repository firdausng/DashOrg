using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Personnel.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    WorkEmail = table.Column<string>(type: "text", nullable: false),
                    WorkAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    GivenName = table.Column<string>(type: "text", nullable: false),
                    FamilyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
                    MaritalStatusDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Ethnic = table.Column<string>(type: "text", nullable: false),
                    Religion = table.Column<string>(type: "text", nullable: false),
                    CitizenshipStatus = table.Column<string>(type: "text", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmergencyContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonalInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LegalNameId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_ContactInformation_ContactInformationId",
                        column: x => x.ContactInformationId,
                        principalTable: "ContactInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_EmergencyContact_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_LegalName_LegalNameId",
                        column: x => x.LegalNameId,
                        principalTable: "LegalName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_PersonalInformation_PersonalInformationId",
                        column: x => x.PersonalInformationId,
                        principalTable: "PersonalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ContactInformationId",
                table: "Members",
                column: "ContactInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_EmergencyContactId",
                table: "Members",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_LegalNameId",
                table: "Members",
                column: "LegalNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PersonalInformationId",
                table: "Members",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_PhotoId",
                table: "Members",
                column: "PhotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "LegalName");

            migrationBuilder.DropTable(
                name: "PersonalInformation");

            migrationBuilder.DropTable(
                name: "Photo");
        }
    }
}
