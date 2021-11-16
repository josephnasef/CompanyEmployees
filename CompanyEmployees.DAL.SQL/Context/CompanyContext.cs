using CompanyEmployees.DAL.SQL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CompanyEmployees.DAL.SQL.Context
{
    public class CompanyContext : DbContext
    {
        // Your context has been configured to use a 'CompanyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CompanyEmployees.DAL.SQL.Context.CompanyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CompanyContext' 
        // connection string in the application configuration file.
        public CompanyContext()
            : base("CompanyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}