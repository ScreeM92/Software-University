USE Ads
GO

----------------------------------
-- Problem 1
----------------------------------
SELECT
    a.Title
FROM Ads AS a
ORDER BY a.Title ASC

----------------------------------
-- Problem 2
----------------------------------
SELECT
    a.Title,
    a.Date
FROM Ads AS a
WHERE a.Date BETWEEN '26-Dec-2014' AND '02-Jan-2015'
ORDER BY a.Date ASC

----------------------------------
-- Problem 3
----------------------------------
SELECT
    a.Title,
    a.Date,
    CASE
        WHEN a.ImageDataURL IS NOT NULL THEN 'yes' ELSE 'no'
    END AS [Has Image]
FROM Ads AS a
ORDER BY a.Id

----------------------------------
-- Problem 4
----------------------------------
SELECT 
    * 
FROM Ads AS a
WHERE 
    a.CategoryId IS NULL OR 
    a.TownId IS NULL OR 
    a.ImageDataURL IS NULL

----------------------------------
-- Problem 5
----------------------------------
SELECT
    a.Title,
    t.Name AS [Town]
FROM Ads AS a
LEFT JOIN Towns AS t
    ON a.TownId = t.Id
ORDER BY a.Id ASC

----------------------------------
-- Problem 6
----------------------------------
SELECT
    a.Title,
    c.Name AS [CategoryName],
    t.Name AS [TownName],
    s.Status AS [Status]
FROM Ads AS a
LEFT JOIN Categories AS c
    ON a.CategoryId = c.Id
LEFT JOIN Towns AS t
    ON a.TownId = t.Id
LEFT JOIN AdStatuses AS s
    On a.StatusId = s.Id
ORDER BY a.Id ASC

----------------------------------
-- Problem 7
----------------------------------
SELECT
    a.Title,
    c.Name AS [CategoryName],
    t.Name AS [TownName],
    s.Status
FROM Ads AS a
JOIN Towns AS t
    ON a.TownId = t.Id AND t.Name IN ('Sofia', 'Stara Zagora', 'Blagoevgrad')
JOIN AdStatuses AS s
    ON a.StatusId = s.Id AND s.Status = 'Published'
JOIN Categories AS c
    ON a.CategoryId = c.Id
ORDER BY a.Title ASC

----------------------------------
-- Problem 8
----------------------------------
SELECT
    MIN(a.Date) AS [MinDate],
    MAX(a.Date) AS [MaxDate]
FROM Ads AS a

----------------------------------
-- Problem 9
----------------------------------
SELECT TOP 10
    a.Title,
    a.Date,
    s.Status
FROM Ads AS a
JOIN AdStatuses AS s
    ON a.StatusId = s.Id
ORDER BY a.Date DESC

----------------------------------
-- Problem 10
----------------------------------
DECLARE @minYear INT = YEAR((SELECT MIN(Date) FROM Ads))
    
DECLARE @minMonth INT = MONTH((SELECT MIN(Date) FROM Ads))

SELECT 
    a.Id,
    a.Title,
    a.Date,
    s.Status
FROM Ads AS a
JOIN AdStatuses AS s
    ON a.StatusId = s.Id AND s.Status != 'Published'
WHERE YEAR(a.Date) = @minYear AND MONTH(a.Date) = @minMonth
ORDER BY a.Id ASC

GO

----------------------------------
-- Problem 11
----------------------------------
SELECT 
    s.Status,
    COUNT(s.Id) AS [Count]
FROM AdStatuses AS s
LEFT JOIN Ads AS a
    ON s.Id = a.StatusId
GROUP BY s.Status
ORDER BY s.Status

----------------------------------
-- Problem 12
----------------------------------
SELECT 
	t.Name AS [Town Name],
	s.Status,
	COUNT(a.Id) AS Count
FROM Ads AS a
JOIN AdStatuses AS s
	ON a.StatusId = s.Id
JOIN Towns AS t
	ON a.TownId = t.Id
GROUP BY t.Name, s.Status
ORDER BY t.Name ASC, s.Status ASC

----------------------------------
-- Problem 13
----------------------------------
DECLARE @admins TABLE (
	id NVARCHAR(128))

INSERT INTO @admins
	SELECT ur.UserId 
	FROM AspNetUserRoles AS ur 
	WHERE ur.RoleId = 
		(SELECT r.Id FROM AspNetRoles AS r WHERE r.Name = 'Administrator')

SELECT 
	u.UserName,
	COUNT(DISTINCT a.Id) AS [AdsCount],
	CASE
		WHEN u.Id IN (SELECT * FROM @admins) THEN 'yes' ELSE 'no'
	END AS [IsAdministrator]
FROM AspNetUsers AS u
LEFT JOIN AspNetUserRoles AS ur
	ON u.Id = ur.UserId
LEFT JOIN AspNetRoles AS r
	On ur.RoleId = r.Id
LEFT JOIN Ads AS a
	ON u.Id = a.OwnerId
GROUP BY u.Id, u.UserName
ORDER BY u.UserName ASC

GO

----------------------------------
-- Problem 14
----------------------------------
SELECT 
	COUNT(a.Id) AS [AdsCount],
	ISNULL(t.Name, '(no town)') AS [Town]	
FROM Ads AS a
LEFT JOIN Towns AS t
	ON a.TownId = t.Id
GROUP BY t.Id, t.Name
HAVING COUNT(a.Id) IN (2, 3)
ORDER BY t.Name

----------------------------------
-- Problem 15
----------------------------------
SELECT 
	a1.Date AS [FirstDate],
	a2.Date AS [SecondDate]
FROM Ads AS a1, Ads AS a2
WHERE a1.Date < a2.Date AND DATEDIFF(HH, a1.Date, a2.Date) < 12
ORDER BY [FirstDate] ASC, [SecondDate] ASC

----------------------------------
-- Problem 16
----------------------------------
USE Ads
GO

BEGIN TRAN

-- Task 1
CREATE TABLE Countries(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50))
GO

ALTER TABLE Towns ADD CountryId INT FOREIGN KEY REFERENCES Countries(Id)
GO

-- Task 2
INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')
UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')
INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))
GO

-- Task 3
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Paris')
WHERE DATENAME(DW, Date) = 'Friday'

-- Task 4
UPDATE Ads
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Hamburg')
WHERE DATENAME(DW, Date) = 'Thursday'
GO

-- Task 5
DELETE FROM Ads
WHERE OwnerId IN 
	(SELECT 
		u.Id 
	FROM AspNetUsers AS u
	JOIN AspNetUserRoles AS ur
		ON u.Id = ur.UserId
	JOIN AspNetRoles AS r
		ON ur.RoleId = r.Id
	WHERE r.Name = 'Partner')
GO

-- Task 6
INSERT INTO Ads(Title, Text, OwnerId, Date, StatusId) VALUES
	('Free Book',
	'Free C# Book',
	(SELECT Id FROM AspNetUsers WHERE Name = 'nakov'),
	GETDATE(),
	(SELECT Id FROM AdStatuses WHERE Status = 'Waiting Approval'))
GO

-- Task 7
SELECT
	t.Name AS [Town],
	c.Name AS [Country],
	COUNT(a.Id) AS [AdsCount]
FROM Towns AS t
JOIN Countries AS c
	ON t.CountryId = c.Id
FULL JOIN Ads AS a
	ON a.TownId = t.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name ASC
GO

ROLLBACK
GO

----------------------------------
-- Problem 17
----------------------------------
USE Ads
GO

CREATE VIEW [AllAds]
AS
	SELECT
		a.Id,
		a.Title,
		u.UserName AS [Author],
		a.Date,
		t.Name AS [Town],
		c.Name AS [Category],
		s.Status
	FROM AspNetUsers AS u
	LEFT JOIN Ads AS a
		ON u.Id = a.OwnerId
	LEFT JOIN Towns AS t
			ON a.TownId = t.Id
	LEFT JOIN Categories AS c
		ON a.CategoryId = c.Id
	LEFT JOIN AdStatuses AS s
		ON a.StatusId = s.Id
GO

IF (object_id(N'fn_ListUsersAds') IS NOT NULL)
DROP FUNCTION fn_ListUsersAds
GO

CREATE FUNCTION fn_ListUsersAds() RETURNS @table TABLE(
	Id INT IDENTITY PRIMARY KEY,
	UserName NVARCHAR(256),
	AdDates NVARCHAR(MAX))
AS
BEGIN
	INSERT INTO @Table
		SELECT 
			a.Author AS UserName,
			STUFF(ISNULL(
			(SELECT 
				'; ' + FORMAT(b.Date, 'yyyyMMdd')
			FROM AllAds AS b
			WHERE b.Author = a.Author
			GROUP BY b.Author, b.Date
			ORDER BY b.Date ASC
			FOR XML PATH (''), TYPE).value('.','NVARCHAR(max)'), ''), 1, 2, '') AS Questions
		FROM AllAds AS a
		GROUP BY a.Author
		ORDER BY a.Author DESC
	RETURN 
END
GO

SELECT UserName, AdDates FROM fn_ListUsersAds()
GO

----------------------------------
-- Problem 18
----------------------------------

-- Task 1
DROP DATABASE IF EXISTS `orders`;

CREATE DATABASE `orders` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `orders`;

CREATE TABLE `products` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
    price DECIMAL(10, 2) NOT NULL);
    
CREATE TABLE `customers` (
	id INT AUTO_INCREMENT PRIMARY KEY,
    name NVARCHAR(50) NOT NULL);
    
CREATE TABLE `orders`(
	id INT AUTO_INCREMENT PRIMARY KEY,
    date DATETIME NOT NULL);
    
CREATE TABLE `order_items`(
	id INT AUTO_INCREMENT PRIMARY KEY,
    order_id INT NOT NULL REFERENCES orders(id),
    product_id INT NOT NULL REFERENCES products(id),
    quantity DECIMAL(10, 2) NOT NULL);

-- Task 2    
INSERT INTO `products` VALUES 
	(1,'beer',1.20), 
    (2,'cheese',9.50), 
    (3,'rakiya',12.40), 
    (4,'salami',6.33), 
    (5,'tomatos',2.50), 
    (6,'cucumbers',1.35), 
    (7,'water',0.85), 
    (8,'apples',0.75);
    
INSERT INTO `customers` VALUES 
	(1,'Peter'), 
    (2,'Maria'), 
    (3,'Nakov'), 
    (4,'Vlado');

INSERT INTO `orders` VALUES 
	(1,'2015-02-13 13:47:04'), 
    (2,'2015-02-14 22:03:44'), 
    (3,'2015-02-18 09:22:01'), 
    (4,'2015-02-11 20:17:18');
    
INSERT INTO `order_items` VALUES 
	(12,4,6,2.00), 
    (13,3,2,4.00), 
    (14,3,5,1.50), 
    (15,2,1,6.00), 
    (16,2,3,1.20), 
    (17,1,2,1.00), 
    (18,1,3,1.00), 
    (19,1,4,2.00), 
    (20,1,5,1.00), 
    (21,3,1,4.00),
    (22,1,1,3.00);

-- Task 3
SELECT 
	p.name AS product_name,
    COUNT(oi.id) AS num_orders,
    IFNULL(SUM(oi.quantity), 0) AS quantity,
	p.price AS price,
    IFNULL(SUM(oi.quantity), 0) * p.price AS total_price
FROM products AS p
LEFT JOIN order_items AS oi
	ON p.id = oi.product_id
GROUP BY p.name