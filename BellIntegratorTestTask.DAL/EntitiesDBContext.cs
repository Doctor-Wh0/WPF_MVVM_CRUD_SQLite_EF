using BellIntegratorTestTask.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BellIntegratorTestTask.DAL
{
    public class EntitiesDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        private string pathToDb = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "nourDb.db");
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={pathToDb}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                new Product { Id=1, Name="One",   Articul="11111", Description="Description about One", Manufacturer="Pepsico", Price=300, Quantity=3, Unity="kg"},
                new Product { Id=2, Name="Two",   Articul="11112",   Description="Description about Two", Manufacturer="Valkure", Price=100, Quantity=1, Unity="kg"},
                new Product { Id=3, Name="Three", Articul="11113", Description="Description about Three", Manufacturer="GG", Price=200, Quantity=3, Unity="kg"}
                });
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer[]
            //    {
            //        new Customer{ CustomerId=1, CompanyName="Pepsico", Address="Moskva, Moskovskaya 4", Discount=10, Phone="333333", Representative="Simonov AE"}
            //    });

            modelBuilder.Entity<Employee>().HasData(
                new Employee[]
                {
                    new Employee{ EmployeeId=1, Name="Semen", SecondName="Semenich", SurName="Simonov", Age=30, Phone="223322", Post="Director", Salary=100_000, Seniority=10 },
                    new Employee{ EmployeeId=2, Name="Neo", SecondName="Andersen", SurName="Andersen", Age=30, Phone="223322", Post="Director", Salary=100_000, Seniority=10 },
                    new Employee{ EmployeeId=3, Name="Ivan", SecondName="Ivanovic", SurName="Ivanov", Age=30, Phone="223322", Post="Director", Salary=100_000, Seniority=10 },
                    new Employee{ EmployeeId=4, Name="Semen", SecondName="Semenich", SurName="Simonov", Age=30, Phone="223322", Post="Director", Salary=100_000, Seniority=10 }
                });
        }
    }
}
