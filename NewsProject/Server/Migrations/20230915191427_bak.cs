using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsProject.Server.Migrations
{
    public partial class bak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barenches",
                columns: table => new
                {
                    BarenchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarenchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adderess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barenches", x => x.BarenchID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addrees = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarenchID = table.Column<int>(type: "int", nullable: false),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                    table.ForeignKey(
                        name: "FK_Suppliers_Barenches_BarenchID",
                        column: x => x.BarenchID,
                        principalTable: "Barenches",
                        principalColumn: "BarenchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BarenchID = table.Column<int>(type: "int", nullable: false),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Barenches_BarenchID",
                        column: x => x.BarenchID,
                        principalTable: "Barenches",
                        principalColumn: "BarenchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discont = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discontafter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotaEnd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qountte = table.Column<int>(type: "int", nullable: false),
                    SuppId = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    BarenchID = table.Column<int>(type: "int", nullable: false),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Barenches_BarenchID",
                        column: x => x.BarenchID,
                        principalTable: "Barenches",
                        principalColumn: "BarenchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTemps",
                columns: table => new
                {
                    InvoiceTempID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    BarenchID = table.Column<int>(type: "int", nullable: false),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTemps", x => x.InvoiceTempID);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Barenches_BarenchID",
                        column: x => x.BarenchID,
                        principalTable: "Barenches",
                        principalColumn: "BarenchID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_InvoiceTemps_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Invoicelists",
                columns: table => new
                {
                    InvoicelistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    InvID = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: true),
                    BarenchID = table.Column<int>(type: "int", nullable: false),
                    CurrentStata = table.Column<int>(type: "int", nullable: false),
                    CreatUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoicelists", x => x.InvoicelistID);
                    table.ForeignKey(
                        name: "FK_Invoicelists_Barenches_BarenchID",
                        column: x => x.BarenchID,
                        principalTable: "Barenches",
                        principalColumn: "BarenchID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoicelists_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoicelists_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_Invoicelists_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f6bb5b66-6398-47e2-b8ea-c253ccf79a7f", 0, "fb4aef7c-908a-4f87-b648-2df4c40b2f09", "Yemen", "bakel@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAaowgzOkmmNXOX06rTW73waTEU1BPwc4B0fBVNCCw3vbo9dpF2aQ9E5QZBSK4nN1g==", "771966828", false, "25b3f23c-fc9e-4fd5-ac99-62a19bf831e8", false, "bakel" });

            migrationBuilder.InsertData(
                table: "Barenches",
                columns: new[] { "BarenchID", "Adderess", "BarenchName", "CreatDate", "CreatUserID", "CurrentStata", "DeleteDate", "DeleteUserID", "UpdateDate", "UpdateUserID" },
                values: new object[,]
                {
                    { 1, null, "فرع تعز", null, null, 1, null, null, null, null },
                    { 2, null, "فرع صنعاء ", null, null, 1, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "الالمواد الغذائية" },
                    { 2, "المستلزمات" },
                    { 3, "الكمبيوتر" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BarenchID", "CategoryId", "CreatDate", "CreatUserID", "CurrentStata", "DeleteDate", "DeleteUserID", "Img", "Price", "ProductName", "Quntity", "UpdateDate", "UpdateUserID" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6666), null, 1, null, null, null, 200m, " حليب", 20, null, null },
                    { 2, 1, 2, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6695), null, 1, null, null, null, 4300m, " اسسوارات  ", 30, null, null },
                    { 3, 2, 3, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6712), null, 1, null, null, null, 1600m, " كمبيوتر ", 200, null, null },
                    { 4, 1, 1, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6721), null, 1, null, null, null, 20m, " دقيق", 30, null, null }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Addrees", "BarenchID", "CreatDate", "CreatUserID", "CurrentStata", "DeleteDate", "DeleteUserID", "Emil", "Img", "Phon", "SupplierName", "UpdateDate", "UpdateUserID" },
                values: new object[,]
                {
                    { 1, "Taiz", 1, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6740), null, 1, null, null, "bakel@gmail.com", null, "771966828", "Bakel Asharabe", null, null },
                    { 2, "Taiz", 1, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6752), null, 1, null, null, "mog@gmail.com", null, "771966828", "Mohmmed Asharabe", null, null },
                    { 3, "Taiz", 1, new DateTime(2023, 9, 15, 22, 14, 23, 893, DateTimeKind.Local).AddTicks(6761), null, 1, null, null, "bak@eail.com", null, "771966828", " Asharabe", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicelists_BarenchID",
                table: "Invoicelists",
                column: "BarenchID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicelists_CategoryId",
                table: "Invoicelists",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicelists_InvoiceId",
                table: "Invoicelists",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicelists_ProductID",
                table: "Invoicelists",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BarenchID",
                table: "Invoices",
                column: "BarenchID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SupplierID",
                table: "Invoices",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_BarenchID",
                table: "InvoiceTemps",
                column: "BarenchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_CategoryId",
                table: "InvoiceTemps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceTemps_ProductID",
                table: "InvoiceTemps",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BarenchID",
                table: "Products",
                column: "BarenchID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BarenchID",
                table: "Suppliers",
                column: "BarenchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Invoicelists");

            migrationBuilder.DropTable(
                name: "InvoiceTemps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Barenches");
        }
    }
}
