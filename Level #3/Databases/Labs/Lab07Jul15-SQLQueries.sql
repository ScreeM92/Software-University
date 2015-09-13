USE Forum
GO

--------------------------------------------------------------------------------------------------
-- Problem 1 
--------------------------------------------------------------------------------------------------
SELECT 
	q.Title 
FROM Questions AS q
ORDER BY q.Title ASC

--------------------------------------------------------------------------------------------------
-- Problem 2
--------------------------------------------------------------------------------------------------
SELECT
	a.Content,
	a.CreatedOn
FROM Answers AS a
WHERE a.CreatedOn BETWEEN '15-Jun-2012' AND '21-MAR-2013'
ORDER BY a.CreatedOn ASC

--------------------------------------------------------------------------------------------------
-- Problem 3
--------------------------------------------------------------------------------------------------
SELECT
	u.Username,
	u.LastName,
	CASE WHEN u.PhoneNumber IS NOT NULL THEN 1 ELSE 0 END AS [Has Phone]
FROM Users AS u
ORDER BY u.LastName ASC, u.Id ASC

--------------------------------------------------------------------------------------------------
-- Problem 4
--------------------------------------------------------------------------------------------------
SELECT
	q.Title AS [Question Title],
	u.Username AS [Author]
FROM Questions AS q
JOIN Users AS u
	ON q.UserId = u.Id
ORDER BY q.Title ASC

--------------------------------------------------------------------------------------------------
-- Problem 5
--------------------------------------------------------------------------------------------------
SELECT TOP 50
	a.Content [Answer Content],
	a.CreatedOn,
	u.Username AS [Answer Author],
	q.Title [Question Title],
	c.Name AS [Category Name]
FROM Answers AS a
JOIN Questions AS q
	ON a.QuestionId = q.Id
JOIN Users AS u
	ON a.UserId = u.Id
JOIN Categories AS c
	ON q.CategoryId = c.Id
ORDER BY c.Name ASC, [Answer Author] ASC, a.CreatedOn ASC

--------------------------------------------------------------------------------------------------
-- Problem 6
--------------------------------------------------------------------------------------------------
SELECT 
	c.Name AS Category,
	q.Title AS Question,
	q.CreatedOn
FROM Questions AS q
RIGHT JOIN Categories AS c
	ON q.CategoryId = c.Id
ORDER BY c.Name ASC, q.Title ASC

--------------------------------------------------------------------------------------------------
-- Problem 7
--------------------------------------------------------------------------------------------------
SELECT
	u.Id,
	u.Username,
	u.FirstName,
	u.PhoneNumber,
	u.RegistrationDate,
	u.Email
FROM Users AS u
LEFT JOIN Questions AS q
ON u.Id = q.UserId 
WHERE q.Title IS NULL AND u.PhoneNumber IS NULL
ORDER BY u.RegistrationDate ASC

--------------------------------------------------------------------------------------------------
-- Problem 8
--------------------------------------------------------------------------------------------------
SELECT
	MIN(a.CreatedOn) AS [MinDate],
	MAX(a.CreatedOn) AS [MaxDate]
FROM Answers AS a
WHERE a.CreatedOn BETWEEN '1-Jan-2012' AND '31-Dec-2014'

--------------------------------------------------------------------------------------------------
-- Problem 9
--------------------------------------------------------------------------------------------------
SELECT TOP 10
	a.Content AS [Answer],
	a.CreatedOn,
	u.Username
FROM Answers AS a
JOIN Users AS u
	ON a.UserId = u.Id
ORDER BY a.CreatedOn DESC

--------------------------------------------------------------------------------------------------
-- Problem 10
--------------------------------------------------------------------------------------------------
DECLARE @maxYear INT = YEAR((SELECT MAX(CreatedOn) FROM Answers))
    
DECLARE @minMonth INT = MONTH((SELECT MIN(CreatedOn)
                               FROM Answers
                               WHERE YEAR(CreatedOn) = @maxYear))

DECLARE @maxMonth INT = MONTH((SELECT MAX(CreatedOn) FROM Answers))

SELECT
	a.Content AS [Answer Content],
	q.Title AS [Question],
	c.Name AS [Category]
FROM Answers AS a
JOIN Questions AS q
	ON a.QuestionId = q.Id
JOIN Categories AS c
	ON q.CategoryId = c.Id
WHERE 
	a.IsHidden = 1 AND 
	YEAR(a.CreatedOn) = @maxYear AND 
    MONTH(a.CreatedOn) IN (@minMonth, @maxMonth)
ORDER BY c.Name ASC
GO

--------------------------------------------------------------------------------------------------
-- Problem 11
--------------------------------------------------------------------------------------------------
SELECT
	c.Name AS [Category],
	COUNT(a.Id) AS [Answers Count]
FROM Categories AS c
LEFT JOIN Questions AS q
	ON c.Id = q.CategoryId
LEFT JOIN Answers AS a
	ON a.QuestionId = q.Id
GROUP BY c.Name
ORDER BY [Answers Count] DESC

--------------------------------------------------------------------------------------------------
-- Problem 12
--------------------------------------------------------------------------------------------------
SELECT 
	c.Name AS [Category],
	u.Username,
	u.PhoneNumber,
	COUNT(a.Id) AS [Answers Count]
FROM Categories AS c
JOIN Questions AS q
	ON c.Id = q.CategoryId
JOIN Answers AS a
	ON a.QuestionId = q.Id
JOIN Users AS u
	ON u.Id = a.UserId AND u.PhoneNumber IS NOT NULL
GROUP BY c.Name, u.Username, u.PhoneNumber
ORDER BY [Answers Count] DESC, u.Username ASC

--------------------------------------------------------------------------------------------------
-- Problem 13
--------------------------------------------------------------------------------------------------
USE Forum
GO

BEGIN TRAN

CREATE TABLE Towns(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL)
GO

ALTER TABLE Users ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)
GO

INSERT INTO Towns(Name) VALUES ('Sofia'), ('Berlin'), ('Lyon')
UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')
INSERT INTO Towns VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')
GO

UPDATE Users
SET TownId = (SELECT t.Id FROM Towns AS t WHERE t.Name = 'Paris')
WHERE DATENAME(DW, RegistrationDate) = 'Friday'
GO

UPDATE Questions
SET Title = 'Java += operator'
WHERE Id IN (
SELECT DISTINCT QuestionId FROM Answers AS a
WHERE DATENAME(DW, CreatedOn) IN ('Monday', 'Sunday') AND MONTH(a.CreatedOn) = 2)
GO

DECLARE @temp TABLE(
	Id INT)

INSERT INTO @temp
SELECT 
		a.Id
	FROM Answers AS a
	JOIN Votes AS v
		ON a.Id = v.AnswerId
	GROUP BY a.Id
	HAVING SUM(v.Value) < 0

DELETE Votes
WHERE AnswerId IN (SELECT * FROM @temp)

DELETE Answers
WHERE Id IN (SELECT * FROM @temp)
GO

INSERT INTO Questions(Title, Content, CreatedOn, UserId, CategoryId) VALUES
	('Fetch NULL values in PDO query',
	'When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?',
	GETDATE(),
	(SELECT u.Id FROM Users AS u WHERE u.Username = 'darkcat'),
	(SELECT c.Id FROM Categories AS c WHERE c.Name = 'Databases'))
GO

SELECT 
	t.Name AS Town,
	u.Username,
	COUNT(a.Id) AS AnswersCount
FROM Towns AS t
LEFT JOIN Users AS u
	ON t.Id = u.TownId
LEFT JOIN Answers AS a
	ON a.UserId = u.Id
GROUP BY t.Name, u.Username
ORDER BY AnswersCount DESC, u.Username ASC
GO

ROLLBACK

--------------------------------------------------------------------------------------------------
-- Problem 14
--------------------------------------------------------------------------------------------------
USE FORUM
GO

CREATE VIEW [AllQuestions]
AS
	SELECT 
		u.Id AS Uid,
		u.Username,
		u.FirstName,
		u.LastName,
		u.PhoneNumber,
		u.RegistrationDate,
		q.Id AS QId,
		q.Title,
		q.Content,
		q.CategoryId,
		q.UserId,
		q.CreatedOn
	FROM Questions AS q
	RIGHT OUTER JOIN Users AS u
		ON q.UserId = u.Id
GO

CREATE FUNCTION fn_ListUsersQuestions() RETURNS @Table TABLE(
	UserName NVARCHAR(50),
	Questions NVARCHAR(MAX))
AS
	BEGIN
		INSERT INTO @Table
			SELECT 
				a.Username AS UserName,
				STUFF(ISNULL(
				(SELECT 
					', ' + b.Title
				FROM AllQuestions AS b
				WHERE b.Username = a.Username
				GROUP BY b.Username, b.Title
				ORDER BY b.Title DESC
				FOR XML PATH (''), TYPE).value('.','NVARCHAR(max)'), ''), 1, 2, '') AS Questions
			FROM AllQuestions AS a
			GROUP BY a.Username
			ORDER BY a.Username ASC

			RETURN
	END
GO

SELECT * FROM fn_ListUsersQuestions()
GO