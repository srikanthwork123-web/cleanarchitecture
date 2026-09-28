IF DB_ID('EmployeeDb') IS NULL
    CREATE DATABASE EmployeeDb;
GO

USE EmployeeDb;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Employees
    (
        Id INT IDENTITY(1, 1) CONSTRAINT PK_Employees PRIMARY KEY,
        FirstName NVARCHAR(100) NOT NULL,
        LastName NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NOT NULL CONSTRAINT UQ_Employees_Email UNIQUE,
        PhoneNumber NVARCHAR(30) NULL,
        Department NVARCHAR(100) NOT NULL,
        Salary DECIMAL(18, 2) NOT NULL CONSTRAINT CK_Employees_Salary CHECK (Salary >= 0),
        HireDate DATE NOT NULL
    );
END;
GO
