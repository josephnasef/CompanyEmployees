namespace CompanyEmployees.DAL.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeBirthDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Employees", "EmployeeHiringDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeHiringDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "EmployeeBirthDate", c => c.DateTime());
        }
    }
}
