--------------------------------------------------------------------------------------------------
-- Problem 1 : Write a SQL query to find the names and salaries of the employees that take the 
--             minimal salary in the company
--------------------------------------------------------------------------------------------------
SELECT e.FirstName, e.LastName, e.Salary 
FROM Employees AS e
WHERE e.Salary =
	(SELECT MIN(Salary) FROM Employees)

--------------------------------------------------------------------------------------------------
-- Problem 2 : Write a SQL query to find the names and salaries of the employees that have a 
--             salary that is up to 10% higher than the minimal salary for the company
--------------------------------------------------------------------------------------------------
SELECT e.FirstName, e.LastName, e.Salary 
FROM Employees AS e
WHERE e.Salary <
	(SELECT MIN(Salary) FROM Employees) * 1.1

--------------------------------------------------------------------------------------------------
-- Problem 3 - Write a SQL query to find the full name, salary and department of the employees 
--             that take the minimal salary in their department.
--------------------------------------------------------------------------------------------------
SELECT 
	e.FirstName + ' ' + e.LastName,
	e.Salary,
	d.Name AS Department
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = 
	(SELECT MIN(Salary) FROM Employees
	WHERE e.DepartmentID = DepartmentID)

--------------------------------------------------------------------------------------------------
-- Problem 4 : Write a SQL query to find the average salary in the department #1
--------------------------------------------------------------------------------------------------
SELECT
	d.Name, 
	AVG(e.Salary) 
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 1
GROUP BY d.Name

--------------------------------------------------------------------------------------------------
-- Problem 5 : Write a SQL query to find the average salary in the "Sales" department
--------------------------------------------------------------------------------------------------
SELECT
	AVG(e.Salary) AS [Average Salary for Sales Department]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
HAVING d.Name = 'Sales'

--------------------------------------------------------------------------------------------------
-- Problem 6 : Write a SQL query to find the number of employees in the "Sales" department
--------------------------------------------------------------------------------------------------
SELECT
	COUNT(*) AS [Sales Employees Count]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
HAVING d.Name = 'Sales'

--------------------------------------------------------------------------------------------------
-- Problem 7 : Write a SQL query to find the number of all employees that have manager
--------------------------------------------------------------------------------------------------
SELECT COUNT(*) FROM Employees AS e
WHERE e.ManagerID IS NOT NULL

--------------------------------------------------------------------------------------------------
-- Problem 8 : Write a SQL query to find the number of all employees that have no manager
--------------------------------------------------------------------------------------------------
SELECT COUNT(*) FROM Employees AS e
WHERE e.ManagerID IS NULL

--------------------------------------------------------------------------------------------------
-- Problem 9 : Write a SQL query to find all departments and the average salary for each of them
--------------------------------------------------------------------------------------------------
SELECT
	d.Name,
	AVG(e.Salary)
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--------------------------------------------------------------------------------------------------
-- Problem 10 : Write a SQL query to find the count of all employees in each department and for
--              each town
--------------------------------------------------------------------------------------------------
SELECT
	t.Name AS Town,
	d.Name AS Department,
	COUNT(*) AS [Employees count]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
GROUP BY t.Name, d.Name

--------------------------------------------------------------------------------------------------
-- Problem 11 : Write a SQL query to find all managers that have exactly 5 employees
--------------------------------------------------------------------------------------------------
SELECT 
	m.FirstName,
	m.LastName,
	COUNT(*) AS [Employees count]
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--------------------------------------------------------------------------------------------------
-- Problem 12 : Write a SQL query to find all employees along with their managers
--------------------------------------------------------------------------------------------------
SELECT
	e.FirstName + ' ' + e.LastName AS [FullName],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No manager')
FROM Employees AS e
LEFT JOIN Employees AS m
ON e.ManagerID = m.EmployeeID

--------------------------------------------------------------------------------------------------
-- Problem 13 : Write a SQL query to find the names of all employees whose last name is exactly 5 
--              characters long
--------------------------------------------------------------------------------------------------
SELECT
	e.FirstName,
	e.LastName 
FROM Employees AS e
WHERE LEN(e.LastName) = 5

--------------------------------------------------------------------------------------------------
-- Problem 14 : Write a SQL query to display the current date and time in the following format
--              "day.month.year hour:minutes:seconds:milliseconds"
--------------------------------------------------------------------------------------------------
SELECT FORMAT ( GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff') AS DateTime

--------------------------------------------------------------------------------------------------
-- Problem 15 : Write a SQL statement to create a table Users
--------------------------------------------------------------------------------------------------
CREATE TABLE Users (
	UserId int IDENTITY,
	Username nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	FullName nvarchar(50) NOT NULL,
	LastLoginTime datetime NOT NULL
	CONSTRAINT PK_Users PRIMARY KEY(UserId),
	CONSTRAINT UK_Users_Username UNIQUE(Username),
	CONSTRAINT CK_Users_Password CHECK (LEN(Password)>= 5))
GO

--------------------------------------------------------------------------------------------------
-- Problem 16 : Write a SQL statement to create a view that displays the users from the Users 
--              table that have been in the system today
--------------------------------------------------------------------------------------------------
CREATE VIEW [Active Users Today] AS
SELECT * FROM Users AS u
WHERE CAST(u.LastLoginTime AS DATE) = Cast(GetDate() AS DATE)

--------------------------------------------------------------------------------------------------
-- Problem 17 : Write a SQL statement to create a table Groups
--------------------------------------------------------------------------------------------------
CREATE TABLE Groups (
	GroupId int IDENTITY,
	Name nvarchar(100) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(GroupId),
	CONSTRAINT UK_Groups_Name UNIQUE(Name)
)
GO

--------------------------------------------------------------------------------------------------
-- Problem 18 : Write a SQL statement to add a column GroupID to the table Users
--------------------------------------------------------------------------------------------------
ALTER TABLE Users ADD 
	GroupId int NOT NULL
GO

ALTER TABLE Users WITH NOCHECK ADD
	CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId) REFERENCES Groups(GroupId)

--------------------------------------------------------------------------------------------------
-- Problem 19 : Write SQL statements to insert several records in the Users and Groups tables
--------------------------------------------------------------------------------------------------
INSERT INTO Groups(Name) VALUES
	('Database'),
	('FrontEnd')

DECLARE @Group1 int
SET @Group1 = (SELECT GroupId FROM Groups WHERE Name = 'Database')
DECLARE @Group2 int
SET @Group2 = (SELECT GroupId FROM Groups WHERE Name = 'FrontEnd')

INSERT INTO Users(Username, Password, FullName, LastLoginTime, GroupId) VALUES
	('radka', '12345', 'Radka Ivanova', GETDATE(), @Group1),
	('stefan', 'asd123g', 'Stefan Petrov', '30-Jun-2015' ,@Group2),
	('todor', '1fh23', 'Todor Nikolov', GETDATE(), @Group1),
	('stevlin', '23aszcx', 'Stetlin Nakov', '02-May-2015', @Group2)

--------------------------------------------------------------------------------------------------
-- Problem 20 : Write SQL statements to update some of the records in the Users and Groups tables
--------------------------------------------------------------------------------------------------
UPDATE Users
SET FullName = 'Petar Petrov'
WHERE UserId = (SELECT TOP 1 UserId FROM Users)

UPDATE Groups
SET Name = 'Updated Group Name'
WHERE GroupId = (SELECT TOP 1 GroupId FROM Groups)

--------------------------------------------------------------------------------------------------
-- Problem 21 : Write SQL statements to delete some of the records from the Users and Groups tables
--------------------------------------------------------------------------------------------------
DELETE FROM Users
WHERE UserId = (SELECT TOP 1 UserId FROM Users)

DELETE FROM Groups
WHERE GroupId = (SELECT TOP 1 GroupId FROM Groups)

--------------------------------------------------------------------------------------------------
-- Problem 22 : Write SQL statements to insert in the Users table the names of all employees 
--              from the Employees table
--------------------------------------------------------------------------------------------------
TRUNCATE TABLE Users
GO

ALTER TABLE Users
ALTER COLUMN LastLoginTime datetime
GO

IF (OBJECT_ID('CK_Users_Password') IS NOT NULL)
BEGIN
	ALTER TABLE Users DROP CONSTRAINT CK_Users_Password;
END
GO

DECLARE @RowCount INT
	SET @RowCount = (SELECT COUNT(EmployeeID) FROM Employees) 

DECLARE @I int
	SET @I = 1

DECLARE @GroupId int
	SET @GroupId = (SELECT TOP 1 GroupId FROM Groups)
	
WHILE (@I <= @RowCount)
	BEGIN
		DECLARE 
			@iUsername nvarchar(50), 
			@iPassword nvarchar(50), 
			@iFullName nvarchar(50), 
			@iLastLoginTime datetime

		SELECT 
			@iUsername = LOWER(LEFT(FirstName, 1) + LastName), 
			@iPassword = @iUsername, 
			@iFullName = FirstName + ' ' + LastName, 
			@iLastLoginTime = NULL 
		FROM Employees 
		WHERE EmployeeID = @I

		INSERT INTO Users(Username, Password, FullName, LastLoginTime, GroupId) VALUES
			(@iUsername, @iPassword, @iFullName, @iLastLoginTime, @GroupId)

		SET @I = @I + 1
	END
GO

ALTER TABLE Users WITH NOCHECK ADD
CONSTRAINT CK_Users_Password CHECK (LEN(Password)>= 5)
GO

--------------------------------------------------------------------------------------------------
-- Problem 23 : Write a SQL statement that changes the password to NULL for all users that have 
--              not been in the system since 10.03.2010
--------------------------------------------------------------------------------------------------
ALTER TABLE Users
ALTER COLUMN Password nvarchar(50)

UPDATE Users
SET Password = NULL
WHERE CAST(LastLoginTime AS DATE) < CAST('10-Mar-2010' AS DATE) OR LastLoginTime IS NULL

--------------------------------------------------------------------------------------------------
-- Problem 24 : Write a SQL statement that deletes all users without passwords (NULL password)
--------------------------------------------------------------------------------------------------
DELETE FROM Users
WHERE Password IS NULL

--------------------------------------------------------------------------------------------------
-- Problem 25 : Write a SQL query to display the average employee salary by department and job title
--------------------------------------------------------------------------------------------------
SELECT
	d.Name AS Department,
	e.JobTitle,
	AVG(e.Salary) AS [Average Salary]
FROM Departments AS d
JOIN Employees AS e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name ASC, e.JobTitle ASC

--------------------------------------------------------------------------------------------------
-- Problem 26 : Write a SQL query to display the minimal employee salary by department and job 
--              title along with the name of some of the employees that take it
--------------------------------------------------------------------------------------------------
SELECT
	d.Name AS Department,
	e.JobTitle AS [Job Title],
	MIN(e.Salary) AS [Min Salary],
	MIN(e.FirstName) AS [First Name]
FROM Departments AS d
JOIN Employees AS e
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name, e.JobTitle

--------------------------------------------------------------------------------------------------
-- Problem 27 : Write a SQL query to display the town where maximal number of employees work
--------------------------------------------------------------------------------------------------
SELECT TOP 1
	t.Name,
	COUNT(t.Name) AS [Number of employees]
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

--------------------------------------------------------------------------------------------------
-- Problem 28 : Write a SQL query to display the number of managers from each town	
--------------------------------------------------------------------------------------------------
SELECT
	t.Name AS Town,
	COUNT(*) AS [Number of managers]
FROM Employees AS m
JOIN Addresses AS a
ON m.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
WHERE m.EmployeeID IN 
	(SELECT DISTINCT e.ManagerID
	FROM Employees AS e
	WHERE e.ManagerID IS NOT NULL)
GROUP BY t.Name

--------------------------------------------------------------------------------------------------
-- Problem 29 : Write a SQL to create table WorkHours to store work reports for each employee
--------------------------------------------------------------------------------------------------
USE SoftUni

CREATE TABLE WorkHours(
	WorkHoursId int IDENTITY,
	EmployeeId int NOT NULL,
	Date datetime NOT NULL,
	Task nvarchar(200) NOT NULL,
	Hours int NOT NULL,
	Comments text,
	CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursId),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeId))

--------------------------------------------------------------------------------------------------
-- Problem 30 : Issue few SQL statements to insert, update and delete of some data in the table
--------------------------------------------------------------------------------------------------
USE SoftUni

-- INSERT
DECLARE @EmployeeId int
SET @EmployeeId = (SELECT TOP 1 e.EmployeeID FROM Employees AS e)

INSERT INTO WorkHours(EmployeeId, Date, Task, Hours, Comments) VALUES
	(@EmployeeId, '15-Jun-15', 'Download reports', 2, 'Download monthly reports'),
	(@EmployeeId, '21-Jun-15', 'Calculate month salaries', 8, NULL),
	(@EmployeeId, '25-Jun-15', 'Add new employee', 1, 'Add Stefan Stefanov to Sales Department')

-- UPDATE FIRST ROW
DECLARE @WorkHoursId1 int
SET @WorkHoursId1 = (SELECT TOP 1 WorkHoursId FROM WorkHours ORDER BY WorkHoursId ASC)

UPDATE WorkHours
SET Hours = 10, Date = GETDATE()
WHERE WorkHoursId = @WorkHoursId1

-- DELETE LAST ROW
DECLARE @WorkHoursId2 int
SET @WorkHoursId2 = (SELECT TOP 1 WorkHoursId FROM WorkHours ORDER BY WorkHoursId DESC)

DELETE FROM WorkHours
WHERE WorkHoursId = @WorkHoursId2

--------------------------------------------------------------------------------------------------
-- Problem 31 : Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers
--------------------------------------------------------------------------------------------------
USE SoftUni

CREATE TABLE WorkHoursLogs(
	Message nvarchar(200) NOT NULL,
	DateOfChange datetime NOT NULL)
GO

CREATE TRIGGER tr_WorhHoursInsert
ON WorkHours 
FOR INSERT
AS 
	INSERT INTO WorkHoursLogs(Message, DateOfChange) VALUES
		('Added row', GETDATE())
GO

CREATE TRIGGER tr_WorhHoursUpdate
ON WorkHours 
FOR UPDATE
AS 
	INSERT INTO WorkHoursLogs(Message, DateOfChange) VALUES
		('Updated row', GETDATE())
GO

CREATE TRIGGER tr_WorhHoursDelete
ON WorkHours 
FOR DELETE
AS 
	INSERT INTO WorkHoursLogs(Message, DateOfChange) VALUES
		('Deleted row', GETDATE())
GO

-- Test INSERT
DECLARE @EmployeeId int
SET @EmployeeId = (SELECT TOP 1 e.EmployeeID FROM Employees AS e)

INSERT INTO WorkHours(EmployeeId, Date, Task, Hours, Comments) VALUES
	(@EmployeeId, '15-Jun-15', 'Download reports', 2, 'Download monthly reports'),
	(@EmployeeId, '21-Jun-15', 'Calculate month salaries', 8, NULL),
	(@EmployeeId, '25-Jun-15', 'Add new employee', 1, 'Add Stefan Stefanov to Sales Department')

-- TEST UPDATE
DECLARE @WorkHoursId1 int
SET @WorkHoursId1 = (SELECT TOP 1 WorkHoursId FROM WorkHours ORDER BY WorkHoursId ASC)

UPDATE WorkHours
SET Hours = 10, Date = GETDATE()
WHERE WorkHoursId = @WorkHoursId1

-- TEST DELETE
DECLARE @WorkHoursId2 int
SET @WorkHoursId2 = (SELECT TOP 1 WorkHoursId FROM WorkHours ORDER BY WorkHoursId DESC)

DELETE FROM WorkHours
WHERE WorkHoursId = @WorkHoursId2

--------------------------------------------------------------------------------------------------
-- Problem 32 : Start a database transaction, delete all employees from the 'Sales' department 
--              along with all dependent records from the pother tables. At the end rollback the
--              transaction
--------------------------------------------------------------------------------------------------
BEGIN TRAN
DELETE Employees
WHERE DepartmentID = 
	(SELECT d.DepartmentID FROM Departments AS d
	WHERE d.Name = 'Sales')
ROLLBACK

--------------------------------------------------------------------------------------------------
-- Problem 33 : Start a database transaction and drop the table EmployeesProjects
--------------------------------------------------------------------------------------------------
USE SoftUni

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK

--------------------------------------------------------------------------------------------------
-- Problem 34 : Find how to use temporary tables in SQL Server
--------------------------------------------------------------------------------------------------
USE SoftUni

BEGIN TRAN

DECLARE @EmployeesProjects TABLE(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

INSERT INTO @EmployeesProjects 
	SELECT * FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

SELECT * FROM EmployeesProjects

INSERT INTO EmployeesProjects
	SELECT * FROM @EmployeesProjects

SELECT * FROM EmployeesProjects

ROLLBACK
