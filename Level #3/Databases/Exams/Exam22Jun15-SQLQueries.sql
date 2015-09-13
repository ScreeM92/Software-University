USE Football
GO

----------------------------------
-- Problem 1
----------------------------------
SELECT t.TeamName FROM Teams AS t

----------------------------------
-- Problem 2
----------------------------------
SELECT TOP 50
	c.CountryName,
	c.Population
FROM Countries AS c
ORDER BY c.Population DESC, c.CountryName ASC

----------------------------------
-- Problem 3
----------------------------------
SELECT
	c.CountryName,
	c.CountryCode,
	(CASE WHEN c.CurrencyCode = 'EUR' THEN 'Inside' ELSE 'Outside' END) AS Eurozone
FROM Countries AS c
ORDER BY c.CountryName ASC 

----------------------------------
-- Problem 4
----------------------------------
SELECT
	t.TeamName AS [Team Name],
	t.CountryCode AS [Country Code]
FROM Teams AS t
WHERE t.TeamName LIKE '%[0-9]%'
ORDER BY t.CountryCode

----------------------------------
-- Problem 5
----------------------------------
SELECT 
	h.CountryName AS [Home Team],
	a.CountryName AS [Away Team],
	it.MatchDate AS [Match Date]
FROM InternationalMatches AS it
JOIN Countries AS h
ON it.HomeCountryCode = h.CountryCode
JOIN Countries AS a
ON it.AwayCountryCode = a.CountryCode
ORDER BY it.MatchDate DESC

----------------------------------
-- Problem 6
----------------------------------
SELECT 
	t.TeamName AS [Team Name],
	l.LeagueName AS [League],
	ISNULL(c.CountryName, 'International') AS [League Country]
FROM Teams AS t
LEFT JOIN Leagues_Teams as lt
ON t.Id = lt.TeamId
LEFT JOIN Leagues AS l
ON lt.LeagueId = l.Id
LEFT JOIN Countries AS c
ON l.CountryCode = c.CountryCode
ORDER BY t.TeamName ASC, l.LeagueName ASC

----------------------------------
-- Problem 7
----------------------------------
SELECT 
	m.TeamName AS Team,
	COUNT(*) AS [Matches Count]
FROM (
    	SELECT 
			h.TeamName
		FROM TeamMatches AS th
		JOIN Teams AS h
		ON th.HomeTeamId = h.Id
    	UNION All
    	SELECT 
			a.TeamName
		FROM TeamMatches AS ta
		JOIN Teams AS a
		ON ta.AwayTeamId = a.Id
    	) As m
GROUP BY m.TeamName
HAVING COUNT(*) > 1
ORDER BY m.TeamName ASC

----------------------------------
-- Problem 8
----------------------------------
SELECT 
	b.LeagueName AS [League Name],
	a.Teams,
	b.Matches,
	b.[Average Goals]
FROM 
	(SELECT
	l.LeagueName,
	COUNT(lt.TeamId) AS Teams
	FROM Leagues AS l
	LEFT JOIN Leagues_Teams AS lt
	ON l.Id = lt.LeagueId
	GROUP BY l.LeagueName
	) AS a
JOIN 
	(SELECT
	l.LeagueName,
	COUNT(tm.Id) AS Matches,
	ISNULL(SUM(tm.AwayGoals + tm.HomeGoals) / COUNT(*), 0) AS [Average Goals]
	FROM Leagues AS l
	LEFT JOIN TeamMatches AS tm
	ON l.Id = tm.LeagueId
	GROUP BY l.LeagueName) AS b
ON a.LeagueName = b.LeagueName
GROUP BY b.LeagueName, a.Teams, Matches, b.[Average Goals]
ORDER BY a.Teams DESC, b.Matches DESC

----------------------------------
-- Problem 9
----------------------------------
SELECT
    t.TeamName,
    (SELECT ISNULL(SUM(tm.HomeGoals), 0) 
     FROM TeamMatches AS tm 
     WHERE tm.HomeTeamId = t.Id) +
    (SELECT ISNULL(SUM(tm.AwayGoals), 0) 
     FROM TeamMatches AS tm 
     WHERE tm.AwayTeamId = t.Id) AS [Total Goals]
FROM Teams AS t
GROUP BY t.Id, t.TeamName
ORDER BY [Total Goals] DESC, t.TeamName ASC

----------------------------------
-- Problem 10
----------------------------------
SELECT DISTINCT a.fd AS [First Date], a.sd AS [Second Date]
FROM
    (
        SELECT tm1.MatchDate AS fd, tm2.MatchDate AS sd
        FROM TeamMatches AS tm1, TeamMatches AS tm2
		WHERE CAST(tm1.MatchDate AS DATE) = CAST(tm2.MatchDate AS DATE) AND tm1.Id != tm2.Id
        UNION ALL
        SELECT tm2.MatchDate AS fd, tm1.MatchDate AS sd
        FROM TeamMatches AS tm1, TeamMatches AS tm2
		WHERE CAST(tm1.MatchDate AS DATE) = CAST(tm2.MatchDate AS DATE) AND tm1.Id != tm2.Id
    ) AS a
WHERE a.fd < a.sd
ORDER BY [First Date] DESC, [Second Date] DESC

----------------------------------
-- Problem 11
----------------------------------
SELECT 
	LOWER(t1.TeamName + SUBSTRING(REVERSE(t2.TeamName), 2, LEN(t2.TeamName))) AS Mix
FROM Teams AS t1, Teams AS t2
WHERE RIGHT(t1.TeamName, 1) = LEFT(REVERSE(t2.TeamName), 1)
ORDER BY Mix

----------------------------------
-- Problem 12
----------------------------------
SELECT
    c.CountryName AS [Country Name],
    COUNT(DISTINCT im.id) AS [International Matches],
    COUNT(DISTINCT tm.Id) AS [Team Matches]
FROM Countries AS c
LEFT JOIN Leagues AS l
    ON l.CountryCode = c.CountryCode
LEFT JOIN TeamMatches AS tm
    ON tm.LeagueId = l.Id
LEFT JOIN InternationalMatches AS im
    ON im.AwayCountryCode = c.CountryCode OR im.HomeCountryCode = c.CountryCode
GROUP BY c.CountryName
HAVING  COUNT(DISTINCT im.id) > 0 OR COUNT(DISTINCT tm.Id) > 0
ORDER BY [International Matches] DESC, [Team Matches] DESC, [Country Name] ASC

----------------------------------
-- Problem 13
----------------------------------
USE Football 
GO

CREATE TABLE FriendlyMatches(
    Id INT IDENTITY PRIMARY KEY,
    HomeTeamID INT NOT NULL FOREIGN KEY REFERENCES Teams(Id),
    AwayTeamID INT NOT NULL FOREIGN KEY REFERENCES Teams(Id),
    MatchDate DATETIME NOT NULL)

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')
GO

SELECT
	ht.TeamName AS [Home Team],
	at.TeamName AS [Away Team],
	m.MatchDate AS [Match Date]
FROM 
	(SELECT fm.HomeTeamID, fm.AwayTeamId, fm.MatchDate FROM FriendlyMatches AS fm
	UNION
	SELECT tm.HomeTeamId, tm.AwayTeamId, tm.MatchDate FROM TeamMatches AS tm) AS m
JOIN Teams AS ht
ON m.HomeTeamID = ht.Id
JOIN Teams AS at
ON m.AwayTeamId = at.Id
ORDER BY [Match Date] DESC
GO

------------------------------------
-- Problem 14
------------------------------------
USE Football
GO

ALTER TABLE Leagues ADD IsSeasonal BIT NOT NULL DEFAULT 0
GO

DECLARE @league INT = (SELECT l.Id FROM Leagues AS l WHERE l.LeagueName = 'Italian Serie A')

INSERT INTO TeamMatches(HomeTeamId, AwayTeamId, HomeGoals, AwayGoals, MatchDate, LeagueId) VALUES
    ((SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Empoli'),
    (SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Parma'),
    2,
    2,
    '19-Apr-2015 16:00',
    @league),
    ((SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'Internazionale'),
    (SELECT t.Id FROM Teams AS t WHERE t.TeamName = 'AC Milan'),
    0,
    0,
    '19-Apr-2015 21:45',
    @league)
GO

UPDATE Leagues
SET IsSeasonal = 1
WHERE Id IN (SELECT DISTINCT 
    tm.LeagueId 
FROM TeamMatches AS tm 
WHERE tm.LeagueId IS NOT NULL)
GO

SELECT 
    ht.TeamName AS [Home Team],
    tm.HomeGoals AS [Home Goals],
    at.TeamName  AS [Away Team],
    tm.AwayGoals  AS [Away Goals],
    l.LeagueName  AS [League Name]
FROM Leagues AS l
JOIN TeamMatches AS tm
    ON l.Id = tm.LeagueId
JOIN Teams AS ht
    ON tm.HomeTeamId = ht.Id
JOIN Teams AS at
    ON tm.AwayTeamId = at.Id
WHERE l.IsSeasonal = 1 AND tm.MatchDate > '10-APR-2015'
ORDER BY [League Name] ASC, [Home Goals] DESC, [Away Goals] DESC
GO

------------------------------------
-- Problem 15
------------------------------------
USE Football
GO

CREATE VIEW [Bulgarian Teams]
AS    
    SELECT
        t.TeamName AS Name,
        tm1.TeamName AS HomeTeam,
        tm.HomeGoals AS HomeGoals,
        tm2.TeamName AS AwayTeam,
        tm.AwayGoals AS AwayGoals,
        tm.MatchDate
    FROM Teams AS t 
    LEFT JOIN TeamMatches AS tm
        ON t.Id = tm.HomeTeamId OR t.Id = tm.AwayTeamId
    LEFT JOIN Teams AS tm1
        ON tm.HomeTeamId = tm1.Id
    LEFT JOIN Teams AS tm2
        ON tm.AwayTeamId = tm2.Id
    WHERE t.CountryCode = 'BG'
GO

CREATE FUNCTION fn_TeamsJSON() RETURNS NVARCHAR(MAX)
AS
    BEGIN
        DECLARE @json NVARCHAR(MAX)

        SET @json = '{"teams":[' + 
		STUFF((
			SELECT 
				',{"name":"' + t1.Name
				+ '","matches":' + ISNULL(t1.Matches, '[]') + '}'
			FROM 		
				(SELECT
					t.Name AS name,
					'[{' + 
					STUFF(ISNULL(
						(SELECT 
							',{"'+ x.HomeTeam +'":' + CAST(x.HomeGoals AS NVARCHAR(MAX)) +
							',"' + x.AwayTeam + '":' + CAST(x.AwayGoals AS NVARCHAR(MAX)) + 
							',"date":' + CONVERT(NVARCHAR(10), x.MatchDate, 103) + '}'
						FROM [Bulgarian Teams] x
						WHERE x.Name = t.Name
						GROUP BY x.Name, x.HomeTeam, x.HomeGoals, x.AwayTeam, x.AwayGoals, x.MatchDate
                        ORDER BY x.MatchDate DESC
						FOR XML PATH (''), TYPE).value('.','NVARCHAR(max)'), ''), 1, 2, '') + 
					']' AS [Matches]
				FROM [Bulgarian Teams] t
				GROUP BY t.Name) AS t1
			FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(max)'), 1, 1, '')
	 + ']}'

        RETURN @json
    END
GO

SELECT dbo.fn_TeamsJSON()
GO