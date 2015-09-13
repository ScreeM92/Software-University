--------------------------------------------------------------------------------------------------
-- Problem 1 : Write a SQL query to find the full name of the employee, his manager full name and
--             the JobTitle from Sales department. Use nested select statement
--------------------------------------------------------------------------------------------------
SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	e.JobTitle,
	m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees AS e
INNER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE e.DepartmentID IN 
	(SELECT d.DepartmentID FROM Departments AS d
	 WHERE d.Name = 'Sales')

--------------------------------------------------------------------------------------------------
-- Problem 2 : Write a SQL query to find the FullName, Salary and Department Name for the top 5 
--             employees ordered by salary in descending order, under the average salary for 
--             their department
--------------------------------------------------------------------------------------------------
SELECT TOP 5
	e.FirstName,
	e.LastName,
	e.Salary,
	d.Name
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary < 
	(SELECT AVG(Salary) FROM Employees AS a
	 WHERE e.DepartmentID = a.DepartmentID)
ORDER BY e.Salary DESC

--------------------------------------------------------------------------------------------------
-- Problem 3 : Display all project with the sum of their employee’s salaries
--------------------------------------------------------------------------------------------------
SELECT 
	p.Name,
	SUM(e.Salary) AS [Employee Salaries]
	FROM Projects AS p
JOIN EmployeesProjects AS ep
ON ep.ProjectID = p.ProjectID
JOIN Employees AS e
ON ep.EmployeeID = e.EmployeeID AND ep.ProjectID = p.ProjectID
GROUP BY p.Name
ORDER BY p.Name

--------------------------------------------------------------------------------------------------
-- Problem 4 : Create two tables. Companies and Conferences. Companies have Name, EmployeesCount, 
--             FoundedIn. Conferences have Name, Price (optional), FreeSeats, Venue and 
--             Organizer (Company). Alter table Conferences and add TwitterAccount column
--------------------------------------------------------------------------------------------------

CREATE TABLE Companies (
	CompanyID int IDENTITY,
	Name nvarchar(50) NOT NULL,
	EmployeesCount int NOT NULL,
	FoundedIn DATETIME NOT NULL
	CONSTRAINT PK_Companies PRIMARY KEY(CompanyID))
GO

CREATE TABLE Conferences (
	ConferenceID int IDENTITY,
	Name nvarchar(50) NOT NULL,
	Price int,
	FreeSeats int NOT NULL,
	Venue nvarchar(50) NOT NULL,
	OrganizerID int NOT NULL,
	CONSTRAINT PK_Conferences PRIMARY KEY(ConferenceID),
	CONSTRAINT FK_Conferences_Companies FOREIGN KEY (OrganizerID) REFERENCES Companies(CompanyID))
GO

ALTER TABLE Conferences ADD TwitterAccount nvarchar(50) NOT NULL
GO