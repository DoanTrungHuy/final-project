CREATE DATABASE AttendanceSystem;
GO

USE AttendanceSystem;
GO

CREATE TABLE Employee (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Sex INT NOT NULL,  -- 0: Male, 1: Female, 2: Other
    Department NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    IsIntern BIT NOT NULL,
    EmployeeType INT NOT NULL,  -- 0: Developer, 1: QA, 2: Manager
    Extension NVARCHAR(50) NULL
);

CREATE TABLE AttendanceRecord (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    EmployeeId NVARCHAR(50) NOT NULL,
    [Date] BIGINT NOT NULL,
    ArrivalTime BIGINT NOT NULL,
    LeaveTime BIGINT NOT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employee(Id) ON DELETE CASCADE
);

CREATE TYPE EmployeeTableType AS TABLE (
    Id NVARCHAR(50) NOT NULL PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Sex INT NOT NULL,  -- 0: Male, 1: Female, 2: Other
    Department NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    IsIntern BIT NOT NULL,
    EmployeeType INT NOT NULL,  -- 0: Developer, 1: QA, 2: Manager
    Extension NVARCHAR(50) NULL
);
GO;

CREATE PROCEDURE BatchAddEmployees
    @employees EmployeeTableType READONLY
AS
BEGIN
    INSERT INTO Employee (
        Id,
        FirstName,
        LastName,
        Username,
        PasswordHash,
        Sex,
        Department,
        PhoneNumber,
        IsIntern,
        EmployeeType,
        Extension
    )
    SELECT
        Id,
        FirstName,
        LastName,
        Username,
        PasswordHash,
        Sex,
        Department,
        PhoneNumber,
        IsIntern,
        EmployeeType,
        Extension
    FROM @employees;
END;
