USE EmployeeDb;
GO

CREATE OR ALTER PROCEDURE dbo.Employee_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, FirstName, LastName, Email, PhoneNumber, Department, Salary, HireDate
    FROM dbo.Employees
    ORDER BY Id;
END;
GO

CREATE OR ALTER PROCEDURE dbo.Employee_GetById @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, FirstName, LastName, Email, PhoneNumber, Department, Salary, HireDate
    FROM dbo.Employees WHERE Id = @Id;
END;
GO

CREATE OR ALTER PROCEDURE dbo.Employee_Create
    @FirstName NVARCHAR(100), @LastName NVARCHAR(100), @Email NVARCHAR(255), @PhoneNumber NVARCHAR(30) = NULL,
    @Department NVARCHAR(100), @Salary DECIMAL(18, 2), @HireDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Employees (FirstName, LastName, Email, PhoneNumber, Department, Salary, HireDate)
    VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Department, @Salary, @HireDate);
    SELECT CONVERT(INT, SCOPE_IDENTITY());
END;
GO

CREATE OR ALTER PROCEDURE dbo.Employee_Update
    @Id INT, @FirstName NVARCHAR(100), @LastName NVARCHAR(100), @Email NVARCHAR(255), @PhoneNumber NVARCHAR(30) = NULL,
    @Department NVARCHAR(100), @Salary DECIMAL(18, 2), @HireDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Employees SET FirstName=@FirstName, LastName=@LastName, Email=@Email, PhoneNumber=@PhoneNumber,
        Department=@Department, Salary=@Salary, HireDate=@HireDate WHERE Id=@Id;
    SELECT CONVERT(INT, @@ROWCOUNT);
END;
GO

CREATE OR ALTER PROCEDURE dbo.Employee_Delete @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Employees WHERE Id = @Id;
    SELECT CONVERT(INT, @@ROWCOUNT);
END;
GO
