USE master
GO

-- Drop the database if it already exists
IF  EXISTS (
	SELECT name 
		FROM sys.databases 
		WHERE name = N'ATM'
)
BEGIN
	ALTER DATABASE ATM SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE ATM
END
GO

-- Create database
CREATE DATABASE ATM
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

USE ATM
GO

CREATE TABLE CardAccounts (
	CardNumber char(10) PRIMARY KEY NOT NULL,
	CardPIN char(4) NOT NULL,
	CardCash money NOT NULL CHECK(CardCash >= 0))
GO

INSERT INTO CardAccounts(CardNumber, CardPIN, CardCash) VALUES
	(1234567890, 7799, 1500),
	(9876543210, 1133, 3210),
	(1478523690, 4466, 8943),
	(9632587410, 9977, 40),
	(9764318250, 6644, 200),
	(3216549870, 3311, 700)
GO

CREATE TABLE TransactionHistory (
	Id int IDENTITY PRIMARY KEY,
	CardNumber char(10) NOT NULL,
	TransactionDate DateTime NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT FK_TransactionHistory_CardAccounts FOREIGN KEY (CardNumber) REFERENCES CardAccounts(CardNumber))
GO

SELECT * FROM CardAccounts
SELECT * FROM TransactionHistory