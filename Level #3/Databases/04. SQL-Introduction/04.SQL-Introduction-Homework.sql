--------------------------------------------------------------------------------------------------
-- Problem 4 : Write a SQL query to find all information about all departments
--------------------------------------------------------------------------------------------------
SELECT * FROM Departments

--------------------------------------------------------------------------------------------------
-- Problem 5 : Write a SQL query to find all department names
--------------------------------------------------------------------------------------------------
SELECT Name FROM Departments

--------------------------------------------------------------------------------------------------
-- Problem 6 : Write a SQL query to find the salary of each employee
--------------------------------------------------------------------------------------------------
SELECT Salary FROM Employees

--------------------------------------------------------------------------------------------------
-- Problem 7 : Write a SQL to find the full name of each employee
--------------------------------------------------------------------------------------------------
SELECT FirstName + ISNULL(' ' + MiddleName, '') + ' ' + LastName
FROM Employees

--------------------------------------------------------------------------------------------------
-- Problem 8 : Write a SQL query to find the email addresses of each employee
--------------------------------------------------------------------------------------------------
SELECT FirstName + '.' + LastName + '@softuni.bg'
FROM Employees

--------------------------------------------------------------------------------------------------
-- Problem 9 : Write a SQL query to find all different employee salaries
--------------------------------------------------------------------------------------------------
SELECT DISTINCT Salary FROM Employees

--------------------------------------------------------------------------------------------------
-- Problem 10 : Write a SQL query to find all information about the employees whose job title is 
--              "Sales Representative"
--------------------------------------------------------------------------------------------------
SELECT * FROM Employees AS e
WHERE e.JobTitle = 'Sales Representative'

--------------------------------------------------------------------------------------------------
-- Problem 11 : Write a SQL query to find the names of all employees whose first name starts with "SA"
--------------------------------------------------------------------------------------------------
SELECT 
	e.FirstName,
	e.MiddleName,
	e.LastName
FROM Employees as e
WHERE e.FirstName LIKE('SA%')

--------------------------------------------------------------------------------------------------
-- Problem 12 : Write a SQL query to find the names of all employees whose last name contains "ei"
--------------------------------------------------------------------------------------------------
SELECT 
	e.FirstName,
	e.MiddleName,
	e.LastName
FROM Employees AS e
WHERE e.LastName Like('%ei%')

--------------------------------------------------------------------------------------------------
-- Problem 13 : Write a SQL query to find the salary of all employees whose salary is in the range
--              [20000...30000]
--------------------------------------------------------------------------------------------------
SELECT e.Salary FROM Employees AS e
WHERE e.Salary BETWEEN 20000 AND 30000
ORDER BY e.Salary

--------------------------------------------------------------------------------------------------
-- Problem 14 : Write a SQL query to find the names of all employees whose salary is 
--              25000, 14000, 12500 or 23600
--------------------------------------------------------------------------------------------------
SELECT * FROM Employees AS e
WHERE e.Salary IN (25000, 14000, 12500, 23600)
ORDER BY e.Salary

--------------------------------------------------------------------------------------------------
-- Problem 15 : Write a SQL query to find all employees that do not have manager
--------------------------------------------------------------------------------------------------
SELECT * FROM Employees AS e
WHERE e.ManagerID IS NULL

--------------------------------------------------------------------------------------------------
-- Problem 16 : Write a SQL query to find all employees that have salary more than 50000. 
--              Order them in decreasing order by salary
--------------------------------------------------------------------------------------------------
SELECT * FROM Employees AS e
WHERE e.Salary >= 50000
ORDER BY e.Salary DESC

--------------------------------------------------------------------------------------------------
-- Problem 17 : Write a SQL query to find the top 5 best paid employees
--------------------------------------------------------------------------------------------------
SELECT TOP 5 * FROM Employees AS e
ORDER BY e.Salary DESC

--------------------------------------------------------------------------------------------------
-- Problem 18 : Write a SQL query to find all employees along with their address
--------------------------------------------------------------------------------------------------
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	e.MiddleName,
	e.JobTitle,
	e.DepartmentID,
	e.ManagerID,
	e.HireDate,
	e.Salary,
	a.AddressText AS [Address],
	t.Name AS [Town]
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
INNER JOIN Towns AS t
ON a.TownID = t.TownID

--------------------------------------------------------------------------------------------------
-- Problem 19 : Write a SQL query to find all employees and their address
--------------------------------------------------------------------------------------------------
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	e.MiddleName,
	e.JobTitle,
	e.DepartmentID,
	e.ManagerID,
	e.HireDate,
	e.Salary,
	a.AddressText AS [Address],
	t.Name AS [Town]
FROM 
	Employees AS e,
	Addresses AS a,
	Towns AS t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

--------------------------------------------------------------------------------------------------
-- Problem 20 : Write a SQL query to find all employees along with their manager
--------------------------------------------------------------------------------------------------
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	e.MiddleName,
	e.JobTitle,
	e.DepartmentID,
	m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName AS [Manager],
	e.HireDate,
	e.Salary,
	e.AddressID
FROM Employees AS e
INNER JOIN Employees as m
ON e.ManagerID = m.EmployeeID 

--------------------------------------------------------------------------------------------------
-- Problem 21 : Write a SQL query to find all employees, along with their manager and their address
--------------------------------------------------------------------------------------------------
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	e.MiddleName,
	e.JobTitle,
	e.DepartmentID,
	m.FirstName + ISNULL(' ' + m.MiddleName, '') + ' ' + m.LastName AS [Manager],
	e.HireDate,
	e.Salary,
	a.AddressText AS [Address],
	a.TownID
FROM Employees AS e
INNER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID 
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID

--------------------------------------------------------------------------------------------------
-- Problem 22 : Write a SQL query to find all departments and all town names as a single list
--------------------------------------------------------------------------------------------------
SELECT d.Name FROM Departments AS d
UNION
SELECT t.Name FROM Towns AS t

--------------------------------------------------------------------------------------------------
-- Problem 23 : Write a SQL query to find all the employees and the manager for each of them 
--              along with the employees that do not have manager
--------------------------------------------------------------------------------------------------
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	e.MiddleName,
	e.JobTitle,
	e.DepartmentID,
	m.FirstName + ISNULL(' ' + e.MiddleName, '') + ' ' + m.LastName AS [Manager],
	e.HireDate,
	e.Salary,
	e.AddressID
FROM Employees AS e
LEFT OUTER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID ASC

--------------------------------------------------------------------------------------------------
-- Problem 24 : Write a SQL query to find the names of all employees from the departments "Sales"
--              and "Finance" whose hire year is between 1995 and 2005
--------------------------------------------------------------------------------------------------
SELECT
	e.FirstName,
	e.LastName,
	e.MiddleName 
FROM Employees AS e
WHERE 
	e.DepartmentID IN (
		SELECT d.DepartmentID FROM Departments AS d
		WHERE d.Name IN ('Sales', 'Finance')) AND
	(e.HireDate BETWEEN '1-JAN-1995' AND '31-DEC-2005')
ORDER BY e.HireDate
