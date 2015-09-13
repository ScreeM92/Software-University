--------------------------------------------------------------------------------------------------
-- Problem 1 : Create a database with two tables - Persons (id (PK), first name, last name, SSN) 
--             and Accounts (id (PK), person id (FK), balance). Insert few records for testing.
--             Write a stored procedure that selects the full names of all persons
--------------------------------------------------------------------------------------------------
CREATE DATABASE Bank
GO

USE Bank
GO

CREATE TABLE Persons(
    PersonId INT IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    SSN NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_Persons PRIMARY KEY(PersonId))
GO

CREATE TABLE Accounts(
    AccountId INT IDENTITY,
    PersonId INT NOT NULL,
    Balance MONEY NOT NULL DEFAULT 0,
    CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
    CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonId) REFERENCES Persons(PersonId),
    CONSTRAINT CK_Accounts_Balance CHECK (Balance >= 0))
GO

INSERT INTO Persons(FirstName, LastName, SSN) VALUES
    ('Gichka', 'Ivanova', '44T55AS56C49D'),
    ('Ivan', 'Stefanov', '21D6SA3XASDD5'),
    ('Kaloyan', 'Popov', '211AASD0AS5XAASD'),
    ('Svetlin', 'Nakov', 'ASD4ASD4ASD44ASD'),
    ('Dobromir', 'Todorov', '25ASD5ASD252')
GO

INSERT INTO Accounts(PersonId, Balance) VALUES
    ((SELECT TOP 1 PersonId FROM Persons WHERE FirstName = 'Gichka'), 100),
    ((SELECT TOP 1 PersonId FROM Persons WHERE FirstName = 'Ivan'), 23100),
    ((SELECT TOP 1 PersonId FROM Persons WHERE FirstName = 'Kaloyan'), 13500),
    ((SELECT TOP 1 PersonId FROM Persons WHERE FirstName = 'Svetlin'), 0),
    ((SELECT TOP 1 PersonId FROM Persons WHERE FirstName = 'Dobromir'), 22330)
GO

CREATE PROC usp_SelectPersonsFullName
AS
    SELECT FirstName + ' ' + LastName AS [Full name] FROM Persons
GO

EXEC usp_SelectPersonsFullName
GO

--------------------------------------------------------------------------------------------------
-- Problem 2 : Create a stored procedure that accepts a number as a parameter and returns all 
--             persons who have more money in their accounts than the supplied number
--------------------------------------------------------------------------------------------------

CREATE PROC usp_SelectPersonsByBalance (@balance money = 0)
AS
    SELECT 
        p.PersonId,
        p.FirstName,
        p.LastName,
        p.SSN,
        a.Balance
    FROM Persons AS p
    JOIN Accounts AS a
    ON p.PersonId = a.PersonId
    WHERE a.Balance > @balance
GO

EXEC usp_SelectPersonsByBalance 13500
GO

--------------------------------------------------------------------------------------------------
-- Problem 3 : Create a function that accepts as parameters – sum, yearly interest rate and number
--             of months. It should calculate and return the new sum
--------------------------------------------------------------------------------------------------
CREATE FUNCTION ufn_CalculateInterest (@Sum MONEY, @YearlyInterestRatePercent DECIMAL, @Months INT) RETURNS MONEY
AS 
    BEGIN
        DECLARE @YearlyInterestRate MONEY
        SET @YearlyInterestRate = @YearlyInterestRatePercent / 100
        RETURN (SELECT @Sum * (1 + @YearlyInterestRate * @Months / 12))
    END
GO

SELECT 
    p.PersonId,
    p.FirstName,
    P.LastName, 
    p.SSN,
    a.Balance,
    dbo.ufn_CalculateInterest(a.Balance, 5, 12) AS [AmmountWithInterest]
FROM Persons AS p
JOIN Accounts AS a
ON p.PersonId = a.PersonId
GO

--------------------------------------------------------------------------------------------------
-- Problem 4 : create a stored procedure that uses the function from the previous example to give 
--             an interest to a person's account for one month. It should take the AccountId and 
--             the interest rate as parameters.
--------------------------------------------------------------------------------------------------
CREATE PROC usp_MonthlyInterest (@AccountId INT, @InterestRate DECIMAl)
AS
    SELECT 
        b.*,
        (SELECT dbo.ufn_CalculateInterest(b.Balance, @InterestRate, 1) - b.Balance) AS [Interest per mounth]
    FROM 
        (SELECT 
            p.PersonId,
            p.FirstName,
            p.LastName,
            p.SSN,
            a.Balance 
        FROM Accounts AS a
        JOIN Persons AS p
        ON a.PersonId = p.PersonId AND a.AccountId = @AccountId) AS b
GO

DECLARE @AccountId INT
SET @AccountId = (SELECT TOP 1 AccountId FROM Accounts)
EXEC usp_MonthlyInterest 
    @AccountId,
    @InterestRate = 5
GO

--------------------------------------------------------------------------------------------------
-- Problem 5 : Add two more stored procedures WithdrawMoney (AccountId, money) and DepositMoney 
--             (AccountId, money) that operate in transactions
--------------------------------------------------------------------------------------------------
CREATE PROC usp_WithdrawMoney (@AccountId INT, @Ammount MONEY)
AS
	DECLARE @OldAmmount MONEY, @NewAmmount MONEY
	SET @OldAmmount = (SELECT Balance FROM Accounts WHERE AccountId = @AccountId)
	SELECT @NewAmmount = (@OldAmmount - @Ammount)

	IF(@NewAmmount < 0)
		BEGIN
			RAISERROR ('Not enough money.', 16, 1)
			RETURN
		END    
    
	IF(@Ammount < 0)
		BEGIN 
			RAISERROR ('The ammount should be possitive.', 16, 1)
			RETURN
		END
	UPDATE Accounts
	SET Balance = @NewAmmount
	WHERE AccountId = @AccountId    
GO

CREATE PROC usp_DepositMoney (@AccountId INT, @Ammount MONEY)
AS
	DECLARE @OldAmmount MONEY, @NewAmmount MONEY
	SET @OldAmmount = (SELECT Balance FROM Accounts WHERE AccountId = @AccountId)
	SELECT @NewAmmount = (@OldAmmount + @Ammount) 
    
	IF(@Ammount < 0)
		BEGIN 
			RAISERROR ('The ammount should be possitive.', 16, 1)
			RETURN
		END
	UPDATE Accounts
	SET Balance = @NewAmmount
	WHERE AccountId = @AccountId    
GO

BEGIN TRAN
	SELECT * FROM Accounts
    EXEC usp_WithdrawMoney 1, 50
	SELECT * FROM Accounts
ROLLBACK
GO

BEGIN TRAN
	SELECT * FROM Accounts
    EXEC usp_DepositMoney 1, 50
	SELECT * FROM Accounts
ROLLBACK
GO

--------------------------------------------------------------------------------------------------
-- Problem 6 : Create another table - Logs (LogID, AccountID, OldSum, NewSum). Add a trigger to 
--             the Accounts table that enters a new entry into the Logs table every time the sum 
--             on an account changes
--------------------------------------------------------------------------------------------------
USE Bank
GO

CREATE TABLE Logs(
    LogID INT IDENTITY PRIMARY KEY,
    AccountID INT REFERENCES Accounts(AccountId),
    OldSum MONEY NOT NULL,
    NewSum MONEY NOT NULL)
GO

CREATE TRIGGER tr_LogBalanceChange ON Accounts FOR UPDATE
AS
    DECLARE @OldSum MONEY, @NewSum MONEY
    SET @OldSum = (SELECT Balance FROM DELETED)
    SET @NewSum = (SELECT Balance FROM INSERTED)

    INSERT INTO Logs (AccountID, OldSum, NewSum) VALUES
        ((SELECT AccountId FROM DELETED), @OldSum, @NewSum)
GO

BEGIN TRAN
    DECLARE @AccountId INT
    SET @AccountId = (SELECT TOP 1 AccountId FROM Accounts)
    
    EXEC usp_DepositMoney @AccountId, 100
    EXEC usp_WithdrawMoney @AccountId, 50
COMMIT
GO

SELECT * FROM Logs
GO

--------------------------------------------------------------------------------------------------
-- Problem 7 : Define a function in the database SoftUni that returns all Employee's names 
--             (first or middle or last name) and all town's names that are comprised of given 
--             set of letters.
--------------------------------------------------------------------------------------------------
USE SoftUni
GO

CREATE FUNCTION ufn_CheckIFWordExistsInString(@word NVARCHAR(Max), @SetOfLetters NVARCHAR(Max)) RETURNS BIT
AS
BEGIN
    DECLARE @index INT = 1
    DECLARE @char CHAR(1)
    DECLARE @charPosition INT

    WHILE(@index <= LEN(@word))
    BEGIN
        SET @char = SUBSTRING(@word, @index, 1)
        SET @charPosition = CHARINDEX(@char, @SetOfLetters)
        IF(@charPosition = 0)
        BEGIN
            RETURN 0
        END

        SET @SetOfLetters = SUBSTRING(@SetOfLetters, 1, @charPosition - 1) + SUBSTRING(@SetOfLetters, @charPosition + 1, LEN(@SetOfLetters))
        SET @index = @index + 1 
    END

    RETURN 1
END
GO

CREATE FUNCTION ufn_EmployeesAndTownsComprisedBySetOfLetters(@SetOfLetters NVARCHAR(Max)) RETURNS @Result TABLE
   (
    Name NVARCHAR(MAX)
   )
AS
BEGIN 
    INSERT @Result 
        SELECT FirstName
        FROM Employees
        WHERE dbo.ufn_CheckIFWordExistsInString(FirstName, @SetOfLetters) = 1 AND FirstName IS NOT NULL
        UNION
        SELECT MiddleName
        FROM Employees
        WHERE dbo.ufn_CheckIFWordExistsInString(MiddleName, @SetOfLetters) = 1 AND MiddleName IS NOT NULL
        UNION
        SELECT LastName
        FROM Employees
        WHERE dbo.ufn_CheckIFWordExistsInString(LastName, @SetOfLetters) = 1 AND LastName IS NOT NULL
        UNION
        SELECT Name
        FROM Towns
        WHERE dbo.ufn_CheckIFWordExistsInString(Name, @SetOfLetters) = 1 AND Name IS NOT NULL

    RETURN
END
GO

SELECT * FROM dbo.ufn_EmployeesAndTownsComprisedBySetOfLetters('oistmiahf')
GO

--------------------------------------------------------------------------------------------------
-- Problem 8 : Using database cursor write a T-SQL script that scans all employees and their 
--             addresses and prints all pairs of employees that live in the same town
--------------------------------------------------------------------------------------------------
USE SoftUni
GO

DECLARE empCursor CURSOR READ_ONLY FOR SELECT
	e.FirstName + ' ' + e.LastName,
	t.Name
FROM Employees e
INNER JOIN Addresses a
ON a.AddressID = e.AddressID
INNER JOIN Towns t
ON t.TownID = a.TownID
ORDER BY t.Name

OPEN empCursor
DECLARE  @town NVARCHAR(50), @fullName NVARCHAR(50), @currentTown NVARCHAR(50), @currentFullName NVARCHAR(50)
FETCH NEXT FROM empCursor INTO @fullName, @town
WHILE @@FETCH_STATUS = 0
  BEGIN
	SET @currentTown = @town
	SET @currentFullName = @fullName
	FETCH NEXT FROM empCursor INTO @fullName, @town

	IF( @currentTown = @town)
		PRINT @town + ': ' + @fullName + ' - ' + @currentFullName
  END
CLOSE empCursor
DEALLOCATE empCursor
GO