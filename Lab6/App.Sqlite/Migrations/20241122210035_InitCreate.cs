using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeBands",
                columns: table => new
                {
                    AgeBandCode = table.Column<string>(type: "TEXT", nullable: false),
                    AgeBandDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeBands", x => x.AgeBandCode);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DocumentName = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentDescription = table.Column<string>(type: "TEXT", nullable: true),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderCode = table.Column<string>(type: "TEXT", nullable: false),
                    GenderDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderCode);
                });

            migrationBuilder.CreateTable(
                name: "HairStyles",
                columns: table => new
                {
                    HairStyleCode = table.Column<string>(type: "TEXT", nullable: false),
                    HairStyleDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairStyles", x => x.HairStyleCode);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "SalonTreatments",
                columns: table => new
                {
                    SalonTreatmentCode = table.Column<string>(type: "TEXT", nullable: false),
                    TreatmentDescription = table.Column<string>(type: "TEXT", nullable: true),
                    StandardPrice = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonTreatments", x => x.SalonTreatmentCode);
                });

            migrationBuilder.CreateTable(
                name: "StaffJobTitles",
                columns: table => new
                {
                    JobCode = table.Column<string>(type: "TEXT", nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffJobTitles", x => x.JobCode);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserType = table.Column<string>(type: "TEXT", nullable: true),
                    DocumentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_DocumentUsers_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AgeBandCode = table.Column<string>(type: "TEXT", nullable: true),
                    GenderCode = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    CellPhone = table.Column<string>(type: "TEXT", nullable: true),
                    HomePhone = table.Column<string>(type: "TEXT", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    Comments = table.Column<string>(type: "TEXT", nullable: true),
                    NaturalHairColor = table.Column<string>(type: "TEXT", nullable: true),
                    OtherDetails = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_AgeBands_AgeBandCode",
                        column: x => x.AgeBandCode,
                        principalTable: "AgeBands",
                        principalColumn: "AgeBandCode");
                    table.ForeignKey(
                        name: "FK_Clients_Genders_GenderCode",
                        column: x => x.GenderCode,
                        principalTable: "Genders",
                        principalColumn: "GenderCode");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobCode = table.Column<string>(type: "TEXT", nullable: true),
                    StaffName = table.Column<string>(type: "TEXT", nullable: true),
                    StaffDetails = table.Column<string>(type: "TEXT", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateLeft = table.Column<DateTime>(type: "TEXT", nullable: true),
                    JobTitleJobCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_StaffJobTitles_JobTitleJobCode",
                        column: x => x.JobTitleJobCode,
                        principalTable: "StaffJobTitles",
                        principalColumn: "JobCode");
                });

            migrationBuilder.CreateTable(
                name: "StaffCharges",
                columns: table => new
                {
                    JobCode = table.Column<string>(type: "TEXT", nullable: false),
                    SalonTreatmentCode = table.Column<string>(type: "TEXT", nullable: true),
                    ChargeAmount = table.Column<decimal>(type: "TEXT", nullable: true),
                    JobTitleJobCode = table.Column<string>(type: "TEXT", nullable: true),
                    SalonTreatmentCode1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffCharges", x => x.JobCode);
                    table.ForeignKey(
                        name: "FK_StaffCharges_SalonTreatments_SalonTreatmentCode1",
                        column: x => x.SalonTreatmentCode1,
                        principalTable: "SalonTreatments",
                        principalColumn: "SalonTreatmentCode");
                    table.ForeignKey(
                        name: "FK_StaffCharges_StaffJobTitles_JobTitleJobCode",
                        column: x => x.JobTitleJobCode,
                        principalTable: "StaffJobTitles",
                        principalColumn: "JobCode");
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfPayment = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AmountDue = table.Column<decimal>(type: "TEXT", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "TEXT", nullable: true),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AppointmentTime = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    ColourUsed = table.Column<string>(type: "TEXT", nullable: true),
                    HairStyleCode = table.Column<string>(type: "TEXT", nullable: true),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: true),
                    ProductCode1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Appointments_HairStyles_HairStyleCode",
                        column: x => x.HairStyleCode,
                        principalTable: "HairStyles",
                        principalColumn: "HairStyleCode");
                    table.ForeignKey(
                        name: "FK_Appointments_Products_ProductCode1",
                        column: x => x.ProductCode1,
                        principalTable: "Products",
                        principalColumn: "ProductCode");
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HairStyleCode",
                table: "Appointments",
                column: "HairStyleCode");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProductCode1",
                table: "Appointments",
                column: "ProductCode1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StaffId",
                table: "Appointments",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AgeBandCode",
                table: "Clients",
                column: "AgeBandCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GenderCode",
                table: "Clients",
                column: "GenderCode");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentUsers_DocumentId",
                table: "DocumentUsers",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_ClientId",
                table: "PaymentDetails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobTitleJobCode",
                table: "Staff",
                column: "JobTitleJobCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCharges_JobTitleJobCode",
                table: "StaffCharges",
                column: "JobTitleJobCode");

            migrationBuilder.CreateIndex(
                name: "IX_StaffCharges_SalonTreatmentCode1",
                table: "StaffCharges",
                column: "SalonTreatmentCode1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DocumentUsers");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "StaffCharges");

            migrationBuilder.DropTable(
                name: "HairStyles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "SalonTreatments");

            migrationBuilder.DropTable(
                name: "StaffJobTitles");

            migrationBuilder.DropTable(
                name: "AgeBands");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
