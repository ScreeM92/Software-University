--USE Diablo
--GO

--------------------------------------------------------------------------------------------------
-- Problem 1 
--------------------------------------------------------------------------------------------------
SELECT
	c.Name
FROM Characters AS c
ORDER BY c.Name ASC

--------------------------------------------------------------------------------------------------
-- Problem 2
--------------------------------------------------------------------------------------------------
SELECT TOP 50
	g.Name AS Game,
	CONVERT(DATE, g.Start) AS Start
FROM Games AS g
WHERE g.Start >= '01-Jan-2011' AND g.Start <= '31-Dec-2012'
ORDER BY Start ASC, g.Name ASC

--------------------------------------------------------------------------------------------------
-- Problem 3
--------------------------------------------------------------------------------------------------
SELECT
	u.Username,
	RIGHT(u.Email, LEN(u.Email) - CHARINDEX('@', u.email)) AS [Email Provider]
FROM Users AS u
ORDER BY [Email Provider] ASC, u.Username ASC

--------------------------------------------------------------------------------------------------
-- Problem 4
--------------------------------------------------------------------------------------------------
SELECT
	u.Username,
	u.IpAddress AS [IP Address]
FROM Users AS u
WHERE u.IpAddress LIKE ('___.1_%._%.___')
ORDER BY u.Username ASC

--------------------------------------------------------------------------------------------------
-- Problem 5
--------------------------------------------------------------------------------------------------
SELECT 
	g.Name AS [Game],
	CASE 
		WHEN DATEPART(HOUR, g.Start) >= 0 AND DATEPART(HOUR, g.Start) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, g.Start) >= 12 AND DATEPART(HOUR, g.Start) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN g.Duration IS NULL THEN 'Extra Long' 
		WHEN g.Duration <= 3 THEN 'Extra Short'
		WHEN g.Duration > 3 AND g.Duration <= 6 THEN 'Short'
		ELSE 'Long' 
	END AS [Duration]
FROM Games AS g
ORDER BY Game ASC, [Duration] ASC, [Part of the Day] ASC

--------------------------------------------------------------------------------------------------
-- Problem 6
--------------------------------------------------------------------------------------------------
SELECT	
	RIGHT(u.Email, LEN(u.Email) - CHARINDEX('@', u.email)) AS [Email Provider],
	COUNT(*) AS [Number Of Users]
FROM Users AS u
GROUP BY RIGHT(u.Email, LEN(u.Email) - CHARINDEX('@', u.email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC

--------------------------------------------------------------------------------------------------
-- Problem 7
--------------------------------------------------------------------------------------------------
SELECT
	g.Name AS [Game],
	gt.Name AS [Game Type],		
	u.Username AS [Username],
	ug.Level AS [Level],
	ug.Cash,
	c.Name AS [Character]
FROM Games g
JOIN UsersGames AS ug
	ON g.Id = ug.GameId
JOIN Users AS u
	On u.Id = ug.UserId
JOIN GameTypes AS gt
	ON g.GameTypeId = gt.Id
JOIN Characters AS c
	ON ug.CharacterId = c.Id
ORDER BY [Level] DESC, [Username] ASC, [Game] ASC

--------------------------------------------------------------------------------------------------
-- Problem 8
--------------------------------------------------------------------------------------------------
SELECT 
	u.Username AS [Username],
	g.Name AS [Game],
	COUNT(i.Id) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM Games AS g
JOIN UsersGames AS ug
	ON g.Id = ug.GameId
JOIN Users AS u
	ON ug.UserId = u.Id
JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
JOIN Items AS i
	ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, [Username] ASC

--------------------------------------------------------------------------------------------------
-- Problem 9
--------------------------------------------------------------------------------------------------
SELECT
    u.Username,
    g.Name AS Game,
    MAX(c.Name) AS Character,
    SUM(itemStat.Strength) + MAX(gameStat.Strength) + MAX(characterStat.Strength) AS Strength,
    SUM(itemStat.Defence) + MAX(gameStat.Defence) + MAX(characterStat.Defence) AS Defence,
    SUM(itemStat.Speed) + MAX(gameStat.Speed) + MAX(characterStat.Speed) AS Speed,
    SUM(itemStat.Mind) + MAX(gameStat.Mind) + MAX(characterStat.Mind) AS Mind,
    SUM(itemStat.Luck) + MAX(gameStat.Luck) + MAX(characterStat.Luck) AS Luck
FROM UsersGames AS ug
JOIN Games AS g
    ON ug.GameId = g.Id
JOIN Users AS u
    ON ug.UserId = u.Id
JOIN Characters AS c
    ON ug.CharacterId = c.Id
JOIN [Statistics] AS characterStat
    ON characterStat.Id = c.StatisticId 
JOIN GameTypes AS gt
    ON gt.Id = g.GameTypeId
JOIN [Statistics] AS gameStat
    ON gt.BonusStatsId = gameStat.Id   
JOIN UserGameItems AS ugi
    ON ugi.UserGameId = ug.Id
JOIN Items AS i
    ON i.Id = ugi.ItemId
JOIN [Statistics] AS itemStat
    ON itemStat.Id = i.StatisticId
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

--------------------------------------------------------------------------------------------------
-- Problem 10
--------------------------------------------------------------------------------------------------
SELECT 
	i.Name,
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind 
FROM Items AS i
JOIN [Statistics] AS s
	ON i.StatisticId = s.Id
WHERE 
	s.Mind > (SELECT AVG(s.Mind) FROM [Statistics] AS s) AND
	s.Luck > (SELECT AVG(s.Luck) FROM [Statistics] AS s) AND
	s.Speed > (SELECT AVG(s.Speed) FROM [Statistics] AS s)

--------------------------------------------------------------------------------------------------
-- Problem 11
--------------------------------------------------------------------------------------------------
SELECT
	i.Name AS [Item],
	i.Price,
	i.MinLevel,
	gt.Name AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS f
	ON i.Id = f.ItemId
LEFT JOIN GameTypes AS gt
	ON f.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name ASC

--------------------------------------------------------------------------------------------------
-- Problem 12
--------------------------------------------------------------------------------------------------
USE Diablo
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'Items table')
   DROP VIEW [Items table]
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'tr_UserGameItems' AND type = 'TR')
   DROP TRIGGER tr_UserGameItems
GO

CREATE VIEW [Items table]
AS
	SELECT 
		i.Id,
		i.Price,
		i.Name
	FROM Items AS i
	WHERE i.Name IN (
	'Blackguard', 
	'Bottomless Potion of Amplification',
	'Eye of Etlich (Diablo III)',
	'Gem of Efficacious Toxin',
	'Golden Gorget of Leoric',
	'Hellfire Amulet')
GO

BEGIN TRAN
	
    DECLARE @alexId INT =  (SELECT u.Id 
                            FROM Users AS u
                            WHERE u.Username = 'Alex')

    DECLARE @userGameId INT = (SELECT ug.Id 
                               FROM UsersGames AS ug
                               JOIN Games AS g
	                               ON g.Id = ug.GameId AND 
                                      g.Name = 'Edinburgh' AND 
                                      ug.UserId = @alexId)

    UPDATE UsersGames
    SET Cash = Cash - (SELECT SUM(Price) FROM [Items table])
    WHERE Id = @userGameId

    INSERT INTO UserGameItems(ItemId, UserGameId)
        SELECT Id, @userGameId FROM [Items table]
    GO

    SELECT 
	    u.Username,
	    g.Name AS Name,
	    ug.Cash,
	    i.Name AS [Item Name]
    FROM UsersGames AS ug
    JOIN Games AS g
	    ON g.Id = ug.GameId AND g.Name = 'Edinburgh'
    JOIN Users AS u
	    ON u.Id = ug.UserId
    JOIN UserGameItems AS ugi
	    ON ugi.UserGameId = ug.Id
    JOIN Items AS i
	    ON i.Id = ugi.ItemId
    ORDER BY [Item Name] ASC

ROLLBACK

--------------------------------------------------------------------------------------------------
-- Problem 13
--------------------------------------------------------------------------------------------------
USE Diablo
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'FirstGroup')
   DROP VIEW [FirstGroup]
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'SecondGroup')
   DROP VIEW [SecondGroup]
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'tr_UserGameItems' AND type = 'TR')
   DROP TRIGGER tr_UserGameItems
GO

CREATE VIEW [FirstGroup]
AS
SELECT
	i.Id, 
	i.Price
FROM Items AS i
WHERE (i.MinLevel BETWEEN 11 AND 12)
GO

CREATE VIEW [SecondGroup]
AS
SELECT
	i.Id, 
	i.Price
FROM Items AS i
WHERE (i.MinLevel BETWEEN 19 AND 21)
GO

DECLARE @usersGamesId INT = (SELECT 
                                ug.Id
                             FROM UsersGames AS ug
                             JOIN Games AS g
                                ON g.Id = ug.GameId
                             JOIN Users AS u
                                 ON u.Id = ug.UserId
                             WHERE u.Username = 'Stamat' AND g.Name = 'Safflower')

BEGIN TRY
    BEGIN TRAN
        INSERT INTO UserGameItems(ItemId, UserGameId)
        SELECT i.Id , @usersGamesId FROM [FirstGroup] AS i

        UPDATE UsersGames
        SET Cash = Cash - (SELECT SUM(Price) FROM [FirstGroup])
        WHERE Id = @usersGamesId
    COMMIT
    
    BEGIN TRAN
        INSERT INTO UserGameItems(ItemId, UserGameId)
        SELECT i.Id, @usersGamesId FROM [SecondGroup] AS i

        UPDATE UsersGames
        SET Cash = Cash - (SELECT SUM(Price) FROM SecondGroup)
        WHERE Id = @usersGamesId      
    COMMIT   
END TRY
BEGIN CATCH 
    ROLLBACK
END CATCH

SELECT 
	i.Name AS [Item Name]
FROM UsersGames AS ug
JOIN Games AS g
	ON ug.GameId = g.Id AND g.Name = 'Safflower'
JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
JOIN Items AS i
	ON ugi.ItemId = i.Id
ORDER BY i.Name ASC

--------------------------------------------------------------------------------------------------
-- Problem 14
--------------------------------------------------------------------------------------------------
USE Diablo
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'fn_CashInUsersGames')
   DROP FUNCTION [fn_CashInUsersGames]
GO

CREATE FUNCTION fn_CashInUsersGames(@gameName NVARCHAR(100)) RETURNS @table TABLE(
	SumCash MONEY)
AS
BEGIN
    DECLARE @tempTable TABLE(row INT, Cash MONEY)
    
	INSERT INTO @tempTable
	    SELECT		
		    ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS rn,
		    ug.Cash
	    FROM UsersGames AS ug
	    JOIN Games AS g
		    ON ug.GameId = g.Id
	    WHERE g.Name = @gameName
	    GROUP BY ug.Id, g.Name, ug.Cash

    INSERT INTO @table
        SELECT
            SUM(Cash)
        FROM @tempTable
        WHERE (Row % 2) = 1

	RETURN
END
GO

SELECT * FROM dbo.fn_CashInUsersGames('Bali')
UNION
SELECT * FROM dbo.fn_CashInUsersGames('Lily Stargazer') 
UNION
SELECT * FROM dbo.fn_CashInUsersGames('Love in a mist') 
UNION
SELECT * FROM dbo.fn_CashInUsersGames('Mimosa') 
UNION
SELECT * FROM dbo.fn_CashInUsersGames('Ming fern')

--------------------------------------------------------------------------------------------------
-- Problem 15
--------------------------------------------------------------------------------------------------
USE Diablo
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'tr_UserGameItems' AND type = 'TR')
   DROP TRIGGER tr_UserGameItems
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'All Items')
   DROP VIEW [All Items]
GO

IF EXISTS (SELECT name FROM sysobjects
      WHERE name = 'UserGamesIds')
   DROP VIEW [UserGamesIds]
GO

CREATE VIEW [All Items]
AS
    SELECT
	    *
    FROM Items AS i
    WHERE (i.Id BETWEEN 251 AND 299) OR (i.Id BETWEEN 501 AND 539)
GO

CREATE VIEW [UserGamesIds]
AS
    SELECT
        ug.Id AS UserGameId,
        u.Id AS UserId,
        u.Username,
        ug.Cash
    FROM Users AS u
    JOIN UsersGames AS ug
        ON ug.UserId = u.Id
    JOIN Games AS g
        ON g.Id = ug.GameId
    WHERE u.Username IN 
        ('baleremuda', 
        'loosenoise', 
        'inguinalself', 
        'buildingdeltoid', 
        'monoxidecos') AND 
        g.Name = 'Bali'
GO

CREATE TRIGGER tr_UserGameItems
ON UserGameItems
INSTEAD OF INSERT
AS
    BEGIN
        DECLARE @itemMinLevel INT =   (SELECT
                                            itm.MinLevel
                                        FROM inserted AS i
                                        JOIN Items AS itm
                                            ON itm.Id = i.ItemId)     
            
        DECLARE @itemPrice MONEY = (SELECT  
                                        itm.Price
                                    FROM inserted AS i
                                    JOIN Items AS itm
                                        ON itm.Id = i.ItemId)    
         
        DECLARE @userLevel INT = (SELECT  
                                        ug.Level
                                    FROM inserted AS i
                                    JOIN UsersGames AS ug
                                        ON ug.Id = i.UserGameId) 

        IF(@userLevel >= @itemMinLevel)
        BEGIN
            INSERT INTO UserGameItems
                SELECT * FROM inserted i

            UPDATE UsersGames
            SET Cash = Cash - @itemPrice
            WHERE Id = (SELECT i.UserGameId FROM inserted AS i)
        END
    END
GO

BEGIN TRAN
    UPDATE UsersGames
    SET Cash = Cash + 50000
    WHERE Id IN (SELECT UserGameId FROM [UserGamesIds] AS ug)

    DECLARE UsersCursor CURSOR FOR
        SELECT 
            i.Id AS ItemId,
            ug.UserGameId AS UserGameId
        FROM [All Items] AS i, [UserGamesIds] AS ug

    OPEN UsersCursor
	    DECLARE @ItemId INT, @UserGameId INT
	    FETCH NEXT FROM UsersCursor INTO @ItemId, @UserGameId;	

	    WHILE @@FETCH_STATUS = 0
	    BEGIN
		    INSERT INTO UserGameItems(ItemId, UserGameId) VALUES(@ItemId, @UserGameId)

            FETCH NEXT FROM UsersCursor INTO @ItemId, @UserGameId;	
	    END
	 
    CLOSE UsersCursor;
    DEALLOCATE UsersCursor;
    GO

    SELECT
        u.Username,
        g.Name,
        ug.Cash,
        i.Name AS [Item Name]
    FROM UsersGames AS ug
    JOIN Games AS g
        ON g.Id = ug.GameId AND g.Name = 'Bali'
    JOIN Users AS u
        ON u.Id = ug.UserId AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
    JOIN UserGameItems AS ugi
        ON ugi.UserGameId = ug.Id
    JOIN Items AS i
        ON ugi.ItemId = i.Id
    ORDER BY u.Username ASC, i.Name ASC

ROLLBACK

--------------------------------------------------------------------------------------------------
-- Problem 16
--------------------------------------------------------------------------------------------------
DROP DATABASE IF EXISTS `Job Portal`;

-- Task 1
CREATE DATABASE `Job Portal` 
CHARACTER SET utf8 
COLLATE utf8_general_ci;

USE `Job Portal`;

CREATE TABLE `users` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    fullname NVARCHAR(50));
    
CREATE TABLE `salaries` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    from_value DECIMAL(10, 2) NOT NULL,
	to_value DECIMAL(10, 2) NOT NULL);
    
CREATE TABLE `job_ads` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title NVARCHAR(300) NOT NULL,
    description NVARCHAR(300),
    author_id INT NOT NULL REFERENCES users(id),
	salary_id INT NOT NULL REFERENCES salaries(id));
    
CREATE TABLE `job_ad_applications` (
    id INT AUTO_INCREMENT PRIMARY KEY,
	job_ad_id INT NOT NULL REFERENCES job_ads(id),
	user_id INT NOT NULL REFERENCES users(id));

-- Task 2
insert into users (username, fullname) values 
    ('pesho', 'Peter Pan'),
    ('gosho', 'Georgi Manchev'),
    ('minka', 'Minka Dryzdeva'),
    ('jivka', 'Jivka Goranova'),
    ('gago', 'Georgi Georgiev'),
    ('dokata', 'Yordan Malov'),
    ('glavata', 'Galin Glavomanov'),
    ('petrohana', 'Peter Petromanov'),
    ('jubata', 'Jivko Jurandov'),
    ('dodo', 'Donko Drozev'),
    ('bobo', 'Bay Boris');

insert into salaries (from_value, to_value) values 
    (300, 500),
    (400, 600),
    (550, 700),
    (600, 800),
    (1000, 1200),
    (1300, 1500),
    (1500, 2000),
    (2000, 3000);

insert into job_ads (title, description, author_id, salary_id) values 
    ('PHP Developer', NULL, (select id from users where username = 'gosho'), (select id from salaries where from_value = 300)),
    ('Java Developer', 'looking to hire Junior Java Developer to join a team responsible for the development and maintenance of the payment infrastructure systems', (select id from users where username = 'jivka'), (select id from salaries where from_value = 1000)),
    ('.NET Developer', 'net developers who are eager to develop highly innovative web and mobile products with latest versions of Microsoft .NET, ASP.NET, Web services, SQL Server and related applications.', (select id from users where username = 'dokata'), (select id from salaries where from_value = 1300)),
    ('JavaScript Developer', 'Excellent knowledge in JavaScript', (select id from users where username = 'minka'), (select id from salaries where from_value = 1500)),
    ('C++ Developer', NULL, (select id from users where username = 'bobo'), (select id from salaries where from_value = 2000)),
    ('Game Developer', NULL, (select id from users where username = 'jubata'), (select id from salaries where from_value = 600)),
    ('Unity Developer', NULL, (select id from users where username = 'petrohana'), (select id from salaries where from_value = 550));

insert into job_ad_applications(job_ad_id, user_id) values 
	((select id from job_ads where title = 'C++ Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Game Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'gosho')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'JavaScript Developer'), (select id from users where username = 'minka')),
	((select id from job_ads where title = 'Unity Developer'), (select id from users where username = 'petrohana')),
	((select id from job_ads where title = '.NET Developer'), (select id from users where username = 'jivka')),
	((select id from job_ads where title = 'Java Developer'), (select id from users where username = 'jivka'));

-- Task 3    
SELECT
	u.username,
	u.fullname,
	j.title AS Job,
	s.from_value AS `From Value`,
	s.to_value AS `To Value`
FROM job_ad_applications AS ja
LEFT JOIN job_ads AS j
	ON ja.job_ad_id = j.id
LEFT JOIN users AS u
	ON ja.user_id = u.id
LEFT JOIN salaries AS s
	ON s.id = j.salary_id
ORDER BY u.username ASC, j.Title ASC