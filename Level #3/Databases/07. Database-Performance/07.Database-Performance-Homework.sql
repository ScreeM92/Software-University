--------------------------------------------------------------------------------------------------
-- Problem 1 : Create a table in SQL Server with 10 000 000 entries (date + text). Search in the 
--             table by date range. Check the speed (without caching)
--------------------------------------------------------------------------------------------------
USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'DB_Performance'
)
BEGIN
    DROP DATABASE DB_Performance
END
GO

-- Create database
CREATE DATABASE DB_Performance
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

-- Edit log size
ALTER DATABASE DB_Performance
modify FILE(name=DB_Performance_log, size=5000mb, filegrowth=1000mb)
GO

-- Edit Data siz
ALTER DATABASE DB_Performance
modify FILE(name=DB_Performance, size=5000mb, filegrowth=1000mb)
GO

USE DB_Performance
GO

-- Create table
CREATE TABLE Performance (
    Id INT IDENTITY PRIMARY KEY,
    Date DATETIME NOT NULL,
    Text TEXT NOT NULL)
GO

-- Fill table with data
BEGIN TRAN
    DECLARE @i INT = 10000000, @date DATETIME = GETDATE()

    WHILE (@i > 0)
    BEGIN
    INSERT INTO Performance (Date, Text) VALUES
        (@date, 'Some text ' + convert(nvarchar,@i))

    SET @date = DATEADD(MINUTE, 1, @date)

    SET @i = @i - 1
    END
COMMIT
GO

-- Clear cache
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

-- Select from table by Date range
SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)

-- Check cache
SELECT usecounts, cacheobjtype, objtype, text 
FROM sys.dm_exec_cached_plans 
CROSS APPLY sys.dm_exec_sql_text(plan_handle) 
WHERE usecounts > 0 AND 
			text like '%SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)%'
ORDER BY usecounts DESC;
GO

-- Check log
DBCC loginfo('DB_Performance')
GO

--------------------------------------------------------------------------------------------------
-- Problem 2 : Add an index to speed-up the search by date. Test the search speed (after cleaning 
--             the cache)
--------------------------------------------------------------------------------------------------
USE DB_Performance
GO

-- Create index for Date column
CREATE INDEX IX_Performance_Date on Performance(Date)
GO

-- Clear cache
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

-- Select from table by Date range
SELECT Id, Date FROM Performance
WHERE Date BETWEEN CAST(DATEADD(DAY, 300, GETDATE()) AS DATE) AND CAST(DATEADD(DAY, 1365, GETDATE()) AS DATE)
GO

--------------------------------------------------------------------------------------------------
-- Problem 3 : Create the same table in MySQL and partition it by date (1990, 2000 and 2010). 
--             Fill 1 000 000 log entries. Compare the searching speed in all partitions (random 
--             dates) to certain partition (e.g. year 1995)
--------------------------------------------------------------------------------------------------
-- Drop the database if it already exists
DROP DATABASE IF EXISTS `DB_Performance`;

-- Create database
CREATE DATABASE `DB_Performance`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `DB_Performance`;

DROP TABLE IF EXISTS `Performance`;

CREATE TABLE `Performance` (
	`id` int(11) NOT NULL AUTO_INCREMENT,
    `dated` datetime NOT NULL,
    `info` text NOT NULL,
    PRIMARY KEY(`id`)
);

-- Fill Database
DELIMITER $$

CREATE PROCEDURE fill_database()
BEGIN
START TRANSACTION;
  SET @i = 10000;
  SET @date = NOW();
  SET @count = 1;

  WHILE @i > 0 DO
	
    INSERT INTO `Performance` VALUES (
    @count,
    @date,
    CONCAT('Some text ', @count)
    );
    
	SET @date = @date + INTERVAL 2 MINUTE;
	SET @i = @i - 1;
    SET @count = @count + 1;
  END WHILE;
COMMIT;
END;

DELIMITER ;

-- Calling finction
CALL fill_database();

SELECT  * FROM `Performance`