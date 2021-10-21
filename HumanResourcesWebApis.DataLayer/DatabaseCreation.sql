DROP TABLE [dbo].[Employees];
DROP TABLE [dbo].[Status];
DROP TABLE [dbo].[Departments];
DROP VIEW [dbo].[vwEmployees];
go

CREATE TABLE [dbo].[Status] (
    [StatusId]     INT           IDENTITY (1, 1) NOT NULL,
    [StatusName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([StatusId] ASC)
);
go

CREATE TABLE [dbo].[Departments] (
    [DepartmentId]         INT           NOT NULL IDENTITY,
    [DepartmentName] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);
go

CREATE TABLE [dbo].[Employees] (
    [EmployeeId]             INT            NOT NULL IDENTITY,
    [FirstName]      NVARCHAR (30)  NOT NULL,
    [SurName]        NVARCHAR (30)  NOT NULL,
    [Email]          NVARCHAR (150) NOT NULL,
    [DateOfBirth]    DATE           NULL,
    [DepartmentID]   INT            NOT NULL,
    [StatusID]       INT            NOT NULL,
    [EmployeeNumber] NVARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_EmployeeStatus] FOREIGN KEY ([StatusID]) REFERENCES [dbo].[Status] ([StatusId]),
    CONSTRAINT [FK_EmployeeDepartment] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Departments] ([DepartmentId])
);
go

SET IDENTITY_INSERT [dbo].[Status] ON
INSERT INTO [dbo].[Status] ([StatusId], [StatusName]) VALUES (1, N'Approved')
INSERT INTO [dbo].[Status] ([StatusId], [StatusName]) VALUES (2, N'Pending')
INSERT INTO [dbo].[Status] ([StatusId], [StatusName]) VALUES (3, N'Disabled')
SET IDENTITY_INSERT [dbo].[Status] OFF
go

SET IDENTITY_INSERT [dbo].[Departments] ON
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (1, N'Marketing')
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (2, N'Sales')
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (3, N'Software Development')
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (4, N'Administration')
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (5, N'Accounts')
INSERT INTO [dbo].[Departments] ([DepartmentId], [DepartmentName]) VALUES (6, N'Customer Support')
SET IDENTITY_INSERT [dbo].[Departments] OFF
go

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (1, N'John',N'Smith','jsmith@madeupcompany.co.uk','01/06/1995',1,1,'A00001');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (2, N'Bill',N'Jones','bjones@madeupcompany.co.uk','04/22/1981',2,2,'A00002');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (3, N'Katie',N'Brown','kbrown@madeupcompany.co.uk','11/23/1991',2,2,'A00003');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (4, N'Mary',N'Tyler','mtyler@madeupcompany.co.uk','08/14/1989',3,2,'A00004');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (5, N'Mike',N'Myers','mmyers@madeupcompany.co.uk','03/17/1978',3,1,'A00005');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (6, N'George',N'Strait','gstrait@madeupcompany.co.uk','09/12/1995',3,2,'A00006');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (7, N'Alan',N'Jackson','ajackson@madeupcompany.co.uk','07/28/1988',3,2,'A00007');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (8, N'Luke',N'Bryan','lbryan@madeupcompany.co.uk','05/06/1997',4,1,'A00008');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (9, N'Luke',N'Coombs','lcoombs@madeupcompany.co.uk','02/15/1996',4,2,'A00009');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (10, N'Kenny',N'Chesney','kchesney@madeupcompany.co.uk','03/23/1995',5,1,'A00010');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (11, N'Randy',N'Travis','rtravis@madeupcompany.co.uk','11/14/1987',5,2,'A00011');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (12, N'Shania',N'Twain','stwain@madeupcompany.co.uk','10/01/1985',6,2,'A00012');
INSERT INTO [dbo].Employees ([EmployeeId], [FirstName], [Surname],Email,DateOfBirth,DepartmentID,StatusID,EmployeeNumber)
VALUES (13, N'Dolly',N'Parton','dparton@madeupcompany.co.uk','04/01/1975',6,1,'A00013');
SET IDENTITY_INSERT [dbo].[Employees] OFF
go

CREATE VIEW [dbo].[vwEmployees]
	AS SELECT emp.EmployeeId,
    emp.FirstName,
    emp.SurName,
    emp.Email,
    emp.DateOfBirth,
	emp.DepartmentID,
    dep.DepartmentName,
	emp.StatusID,
    sta.StatusName,
    emp.EmployeeNumber 
	FROM employees emp
	Inner join Departments dep on dep.DepartmentID=emp.DepartmentID
	inner join [Status] sta on sta.StatusID=emp.StatusID;
go
