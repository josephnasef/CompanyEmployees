namespace CompanyEmployees.DAL.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "EmployeeBirthDate");
            DropColumn("dbo.Employees", "EmployeeHiringDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "EmployeeHiringDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "EmployeeBirthDate", c => c.DateTime(nullable: false));
        }
    }
}
