using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingRegistrationAPI_DL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingHasGuard = table.Column<bool>(type: "bit", nullable: true),
                    BuildingHasCleaningService = table.Column<bool>(type: "bit", nullable: true),
                    BuildingHasJanitor = table.Column<bool>(type: "bit", nullable: true),
                    BuildingHasWifi = table.Column<bool>(type: "bit", nullable: true),
                    BuildingAllowPet = table.Column<bool>(type: "bit", nullable: true),
                    BuildingElevatorQty = table.Column<short>(type: "smallint", nullable: false),
                    BuildingNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeCheckIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeCheckOut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    GarageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.GarageId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorId);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GaragesSections",
                columns: table => new
                {
                    GarageSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageSectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaragesSections", x => x.GarageSectionId);
                    table.ForeignKey(
                        name: "FK_GaragesSections_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_Floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupants",
                columns: table => new
                {
                    OccupantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccupantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccupantSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccupantCellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccupantEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupants", x => x.OccupantId);
                    table.ForeignKey(
                        name: "FK_Occupants_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOccupant",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    OccupantsOccupantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOccupant", x => new { x.EmployeesEmployeeId, x.OccupantsOccupantId });
                    table.ForeignKey(
                        name: "FK_EmployeeOccupant_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeOccupant_Occupants_OccupantsOccupantId",
                        column: x => x.OccupantsOccupantId,
                        principalTable: "Occupants",
                        principalColumn: "OccupantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GarageSectionOccupant",
                columns: table => new
                {
                    GarageSectionsGarageSectionId = table.Column<int>(type: "int", nullable: false),
                    OccupantsOccupantId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarageSectionOccupant", x => new { x.GarageSectionsGarageSectionId, x.OccupantsOccupantId });
                    table.ForeignKey(
                        name: "FK_GarageSectionOccupant_GaragesSections_GarageSectionsGarageSectionId",
                        column: x => x.GarageSectionsGarageSectionId,
                        principalTable: "GaragesSections",
                        principalColumn: "GarageSectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GarageSectionOccupant_Occupants_OccupantsOccupantId",
                        column: x => x.OccupantsOccupantId,
                        principalTable: "Occupants",
                        principalColumn: "OccupantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OccupantVehicle",
                columns: table => new
                {
                    OccupantsOccupantId = table.Column<long>(type: "bigint", nullable: false),
                    VehiclesVehicleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupantVehicle", x => new { x.OccupantsOccupantId, x.VehiclesVehicleId });
                    table.ForeignKey(
                        name: "FK_OccupantVehicle_Occupants_OccupantsOccupantId",
                        column: x => x.OccupantsOccupantId,
                        principalTable: "Occupants",
                        principalColumn: "OccupantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccupantVehicle_Vehicles_VehiclesVehicleId",
                        column: x => x.VehiclesVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FloorId",
                table: "Departments",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOccupant_OccupantsOccupantId",
                table: "EmployeeOccupant",
                column: "OccupantsOccupantId");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingId",
                table: "Floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_GarageSectionOccupant_OccupantsOccupantId",
                table: "GarageSectionOccupant",
                column: "OccupantsOccupantId");

            migrationBuilder.CreateIndex(
                name: "IX_GaragesSections_GarageId",
                table: "GaragesSections",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupantVehicle_VehiclesVehicleId",
                table: "OccupantVehicle",
                column: "VehiclesVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Occupants_DepartmentId",
                table: "Occupants",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOccupant");

            migrationBuilder.DropTable(
                name: "GarageSectionOccupant");

            migrationBuilder.DropTable(
                name: "OccupantVehicle");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "GaragesSections");

            migrationBuilder.DropTable(
                name: "Occupants");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
