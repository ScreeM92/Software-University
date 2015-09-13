namespace _06.StoredProcedure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DbContext;

    public class StoredProcedure
    {
        public static void Main()
        {
            GetProjectsByEmployee("Ruth", "Ellerbrock");
        }

        public static void GetProjectsByEmployee(string firstName, string lastName)
        {
            var context = new SoftUniEntities();
            var projects = context.usp_GetProjectsByEmployee(firstName, lastName)
                .Select(p => new Project
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                }).ToList();

            PrintProjects(projects);
        }

        public static void PrintProjects(ICollection<Project> projects)
        {
            foreach (var project in projects)
            {
                Console.WriteLine("{0} - {1}, {2}", project.Name, project.Description, project.StartDate);
            }
        }
    }
}

/* Create Stored procedure in SQL Server using MSSql Management Studio: * 

USE SoftUni
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'usp_GetProjectsByEmployee')
   DROP PROC usp_GetProjectsByEmployee
GO

CREATE PROC usp_GetProjectsByEmployee(@firstName NVARCHAR(50), @lastName NVARCHAR(50))
AS
    SELECT
        p.Name,
        p.Description,
        p.StartDate
    FROM Employees AS e
    JOIN EmployeesProjects AS ep
        ON e.EmployeeID = ep.EmployeeID
    JOIN Projects AS p
        ON ep.ProjectID = p.ProjectID
    WHERE e.FirstName = @firstName AND e.LastName = @lastName
GO

*/

/*
    Open DbContext.edmx then rigth click -> click "Update Model from Database...".
*/