namespace CompanyEmployees.DAL.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EmployeeBirthDate", c => c.DateTime());
            AddColumn("dbo.Employees", "EmployeeHiringDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmployeeHiringDate");
            DropColumn("dbo.Employees", "EmployeeBirthDate");
        }
    }
}
