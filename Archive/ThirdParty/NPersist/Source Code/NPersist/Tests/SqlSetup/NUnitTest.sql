if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblBook_Cover_CoverId]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblBook] DROP CONSTRAINT FK_tblBook_Cover_CoverId
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblBook]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblBook]
GO

CREATE TABLE [dbo].[tblBook] (
        [BookId] [int] IDENTITY (1, 1) NOT NULL ,
        [Cover_CoverId] [int] NOT NULL ,
        [Name] [varchar] (255) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblBook] WITH NOCHECK ADD
        CONSTRAINT [PK_tblBook] PRIMARY KEY  CLUSTERED 
        (
                [BookId]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblBookInfo_Book_BookId]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblBookInfo] DROP CONSTRAINT FK_tblBookInfo_Book_BookId
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblBookInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblBookInfo]
GO

CREATE TABLE [dbo].[tblBookInfo] (
        [BookInfoId] [int] IDENTITY (1, 1) NOT NULL ,
        [Book_BookId] [int] NOT NULL ,
        [ISBN] [varchar] (255) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblBookInfo] WITH NOCHECK ADD
        CONSTRAINT [PK_tblBookInfo] PRIMARY KEY  CLUSTERED 
        (
                [BookInfoId]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblClsTblEmployee_ClsTblPersonId_ClsTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblClsTblEmployee] DROP CONSTRAINT FK_tblClsTblEmployee_ClsTblPersonId_ClsTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblClsTblEmployee]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblClsTblEmployee]
GO

CREATE TABLE [dbo].[tblClsTblEmployee] (
        [ClsTblPersonId] [int] NOT NULL ,
        [ClsTblPersonType] [char] (1) NOT NULL ,
        [EmploymentDate] [datetime] NOT NULL ,
        [Salary] [decimal](18,0) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblClsTblEmployee] WITH NOCHECK ADD
        CONSTRAINT [PK_tblClsTblEmployee] PRIMARY KEY  CLUSTERED 
        (
                [ClsTblPersonId] ,
                [ClsTblPersonType]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblClsTblFolder_Person_ClsTblPersonId_Person_ClsTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblClsTblFolder] DROP CONSTRAINT FK_tblClsTblFolder_Person_ClsTblPersonId_Person_ClsTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblClsTblFolder]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblClsTblFolder]
GO

CREATE TABLE [dbo].[tblClsTblFolder] (
        [ClsTblFolderId] [int] IDENTITY (1, 1) NOT NULL ,
        [ClsTblFolderType] [char] (1) NOT NULL ,
        [Name] [varchar] (255) NOT NULL ,
        [Person_ClsTblPersonId] [int] NOT NULL ,
        [Person_ClsTblPersonType] [char] (1) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblClsTblFolder] WITH NOCHECK ADD
        CONSTRAINT [PK_tblClsTblFolder] PRIMARY KEY  CLUSTERED 
        (
                [ClsTblFolderId] ,
                [ClsTblFolderType]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblClsTblWorkFolder_Employee_ClsTblPersonId_Employee_ClsTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblClsTblWorkFolder] DROP CONSTRAINT FK_tblClsTblWorkFolder_Employee_ClsTblPersonId_Employee_ClsTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblClsTblWorkFolder_ClsTblFolderId_ClsTblFolderType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblClsTblWorkFolder] DROP CONSTRAINT FK_tblClsTblWorkFolder_ClsTblFolderId_ClsTblFolderType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblClsTblWorkFolder]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblClsTblWorkFolder]
GO

CREATE TABLE [dbo].[tblClsTblWorkFolder] (
        [ClsTblFolderId] [int] NOT NULL ,
        [ClsTblFolderType] [char] (1) NOT NULL ,
        [Employee_ClsTblPersonId] [int] NOT NULL ,
        [Employee_ClsTblPersonType] [char] (1) NOT NULL ,
        [WorkType] [varchar] (255) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblClsTblWorkFolder] WITH NOCHECK ADD
        CONSTRAINT [PK_tblClsTblWorkFolder] PRIMARY KEY  CLUSTERED 
        (
                [ClsTblFolderId] ,
                [ClsTblFolderType]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCncTblEmployee_CncTblPersonId_CncTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCncTblEmployee] DROP CONSTRAINT FK_tblCncTblEmployee_CncTblPersonId_CncTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCncTblEmployee]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCncTblEmployee]
GO

CREATE TABLE [dbo].[tblCncTblEmployee] (
        [CncTblPersonId] [int] NOT NULL ,
        [CncTblPersonType] [char] (1) NOT NULL ,
        [EmploymentDate] [datetime] NOT NULL ,
        [FirstName] [varchar] (255) NOT NULL ,
        [LastName] [varchar] (255) NOT NULL ,
        [Salary] [decimal](18,0) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCncTblEmployee] WITH NOCHECK ADD
        CONSTRAINT [PK_tblCncTblEmployee] PRIMARY KEY  CLUSTERED 
        (
                [CncTblPersonId] ,
                [CncTblPersonType]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCncTblWorkFolder_Employee_CncTblPersonId_Employee_CncTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCncTblWorkFolder] DROP CONSTRAINT FK_tblCncTblWorkFolder_Employee_CncTblPersonId_Employee_CncTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCncTblWorkFolder_Person_CncTblPersonType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCncTblWorkFolder] DROP CONSTRAINT FK_tblCncTblWorkFolder_Person_CncTblPersonType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tblCncTblWorkFolder_CncTblFolderId_CncTblFolderType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tblCncTblWorkFolder] DROP CONSTRAINT FK_tblCncTblWorkFolder_CncTblFolderId_CncTblFolderType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCncTblWorkFolder]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCncTblWorkFolder]
GO

CREATE TABLE [dbo].[tblCncTblWorkFolder] (
        [CncTblFolderId] [int] NOT NULL ,
        [CncTblFolderType] [char] (1) NOT NULL ,
        [Employee_CncTblPersonId] [int] NOT NULL ,
        [Employee_CncTblPersonType] [char] (1) NOT NULL ,
        [Name] [varchar] (255) NOT NULL ,
        [Person_CncTblPersonId] [int] NOT NULL ,
        [Person_CncTblPersonType] [char] (1) NOT NULL ,
        [WorkType] [varchar] (255) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblCncTblWorkFolder] WITH NOCHECK ADD
        CONSTRAINT [PK_tblCncTblWorkFolder] PRIMARY KEY  CLUSTERED 
        (
                [CncTblFolderId] ,
                [CncTblFolderType]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblBook] WITH NOCHECK ADD
        CONSTRAINT [FK_tblBook_Cover_CoverId] FOREIGN KEY 
        (
                [Cover_CoverId]
        ) REFERENCES [dbo].[tblCover] (
                [CoverId]
        )
GO

ALTER TABLE [dbo].[tblBookInfo] WITH NOCHECK ADD
        CONSTRAINT [FK_tblBookInfo_Book_BookId] FOREIGN KEY 
        (
                [Book_BookId]
        ) REFERENCES [dbo].[tblBook] (
                [BookId]
        )
GO

ALTER TABLE [dbo].[tblClsTblEmployee] WITH NOCHECK ADD
        CONSTRAINT [FK_tblClsTblEmployee_ClsTblPersonId_ClsTblPersonType] FOREIGN KEY 
        (
                [ClsTblPersonId], 
                [ClsTblPersonType]
        ) REFERENCES [dbo].[tblClsTblPerson] (
                [ClsTblPersonId], 
                [ClsTblPersonType]
        )
GO

ALTER TABLE [dbo].[tblClsTblFolder] WITH NOCHECK ADD
        CONSTRAINT [FK_tblClsTblFolder_Person_ClsTblPersonId_Person_ClsTblPersonType] FOREIGN KEY 
        (
                [Person_ClsTblPersonId], 
                [Person_ClsTblPersonType]
        ) REFERENCES [dbo].[tblClsTblPerson] (
                [ClsTblPersonId], 
                [ClsTblPersonType]
        )
GO

ALTER TABLE [dbo].[tblClsTblWorkFolder] WITH NOCHECK ADD
        CONSTRAINT [FK_tblClsTblWorkFolder_Employee_ClsTblPersonId_Employee_ClsTblPersonType] FOREIGN KEY 
        (
                [Employee_ClsTblPersonId], 
                [Employee_ClsTblPersonType]
        ) REFERENCES [dbo].[tblClsTblPerson] (
                [ClsTblPersonId], 
                [ClsTblPersonType]
        ), 
        CONSTRAINT [FK_tblClsTblWorkFolder_ClsTblFolderId_ClsTblFolderType] FOREIGN KEY 
        (
                [ClsTblFolderId], 
                [ClsTblFolderType]
        ) REFERENCES [dbo].[tblClsTblFolder] (
                [ClsTblFolderId], 
                [ClsTblFolderType]
        )
GO

ALTER TABLE [dbo].[tblCncTblEmployee] WITH NOCHECK ADD
        CONSTRAINT [FK_tblCncTblEmployee_CncTblPersonId_CncTblPersonType] FOREIGN KEY 
        (
                [CncTblPersonId], 
                [CncTblPersonType]
        ) REFERENCES [dbo].[tblCncTblPerson] (
                [CncTblPersonId], 
                [CncTblPersonType]
        )
GO

ALTER TABLE [dbo].[tblCncTblWorkFolder] WITH NOCHECK ADD
        CONSTRAINT [FK_WF_Person] FOREIGN KEY 
        (
                [Person_CncTblPersonId], 
                [Person_CncTblPersonType]
        ) REFERENCES [dbo].[tblCncTblPerson] (
                [CncTblPersonId], 
                [CncTblPersonType]
        ), 
        CONSTRAINT [FK_tblCncTblWorkFolder_CncTblFolderId_CncTblFolderType] FOREIGN KEY 
        (
                [CncTblFolderId], 
                [CncTblFolderType]
        ) REFERENCES [dbo].[tblCncTblFolder] (
                [CncTblFolderId], 
                [CncTblFolderType]
        ), 
        CONSTRAINT [FK_Employee] FOREIGN KEY 
        (
                [Employee_CncTblPersonId], 
                [Employee_CncTblPersonType]
        ) REFERENCES [dbo].[tblCncTblPerson] (
                [CncTblPersonId], 
                [CncTblPersonType]
        )
GO

