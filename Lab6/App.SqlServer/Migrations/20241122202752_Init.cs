using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeBands",
                columns: table => new
                {
                    AgeBandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgeBandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeBands", x => x.AgeBandCode);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderCode);
                });

            migrationBuilder.CreateTable(
                name: "HairStyles",
                columns: table => new
                {
                    HairStyleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HairStyleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairStyles", x => x.HairStyleCode);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "SalonTreatments",
                columns: table => new
                {
                    SalonTreatmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TreatmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonTreatments", x => x.SalonTreatmentCode);
                });

            migrationBuilder.CreateTable(
                name: "StaffJobTitles",
                columns: table => new
                {
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffJobTitles", x => x.JobCode);
                });

            migrationBuilder.CreateTable(
                name: "DocumentUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_DocumentUsers_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgeBandCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalHairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_AgeBands_AgeBandCode",
                        column: x => x.AgeBandCode,
                        principalTable: "AgeBands",
                        principalColumn: "AgeBandCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Genders_GenderCode",
                        column: x => x.GenderCode,
                        principalTable: "Genders",
                        principalColumn: "GenderCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLeft = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobTitleJobCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_StaffJobTitles_JobTitleJobCode",
                        column: x => x.JobTitleJobCode,
                        principalTable: "StaffJobTitles",
                        principalColumn: "JobCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffCharges",
                columns: table => new
                {
                    JobCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalonTreatmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JobTitleJobCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SalonTreatmentCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        principalColumn: "JobCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ColourUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairStyleCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_HairStyles_HairStyleCode",
                        column: x => x.HairStyleCode,
                        principalTable: "HairStyles",
                        principalColumn: "HairStyleCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Products_ProductCode1",
                        column: x => x.ProductCode1,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
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
