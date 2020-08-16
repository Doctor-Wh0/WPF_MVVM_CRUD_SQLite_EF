using Microsoft.EntityFrameworkCore.Migrations;

namespace BellIntegratorTestTask.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    Age = table.Column<byte>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Post = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Seniority = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Articul = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Unity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "Phone", "Post", "Salary", "SecondName", "Seniority", "SurName" },
                values: new object[] { 1, (byte)30, "Semen", "223322", "Director", 100000.0, "Semenich", 10.0, "Simonov" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "Phone", "Post", "Salary", "SecondName", "Seniority", "SurName" },
                values: new object[] { 2, (byte)30, "Neo", "223322", "Director", 100000.0, "Andersen", 10.0, "Andersen" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "Phone", "Post", "Salary", "SecondName", "Seniority", "SurName" },
                values: new object[] { 3, (byte)30, "Ivan", "223322", "Director", 100000.0, "Ivanovic", 10.0, "Ivanov" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "Name", "Phone", "Post", "Salary", "SecondName", "Seniority", "SurName" },
                values: new object[] { 4, (byte)30, "Semen", "223322", "Director", 100000.0, "Semenich", 10.0, "Simonov" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Articul", "Description", "Manufacturer", "Name", "Price", "Quantity", "Unity" },
                values: new object[] { 1, "11111", "Description about One", "Pepsico", "One", 300.0, 3.0, "kg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Articul", "Description", "Manufacturer", "Name", "Price", "Quantity", "Unity" },
                values: new object[] { 2, "11112", "Description about Two", "Valkure", "Two", 100.0, 1.0, "kg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Articul", "Description", "Manufacturer", "Name", "Price", "Quantity", "Unity" },
                values: new object[] { 3, "11113", "Description about Three", "GG", "Three", 200.0, 3.0, "kg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
