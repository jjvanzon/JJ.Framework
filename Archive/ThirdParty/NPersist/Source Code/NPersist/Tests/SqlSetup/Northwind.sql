if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Categories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories] (
        [CategoryID] [int] IDENTITY (1, 1) NOT NULL ,
        [CategoryName] [nvarchar] (15) NOT NULL ,
        [Description] [ntext] NULL ,
        [Picture] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Categories] WITH NOCHECK ADD
        CONSTRAINT [PK_Categories] PRIMARY KEY  CLUSTERED 
        (
                [CategoryID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerCustomerDemo_CustomerID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT FK_CustomerCustomerDemo_CustomerID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CustomerCustomerDemo_CustomerTypeID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT FK_CustomerCustomerDemo_CustomerTypeID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerCustomerDemo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CustomerCustomerDemo]
GO

CREATE TABLE [dbo].[CustomerCustomerDemo] (
        [CustomerID] [nchar] (5) NOT NULL ,
        [CustomerTypeID] [nchar] (10) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] WITH NOCHECK ADD
        CONSTRAINT [PK_CustomerCustomerDemo] PRIMARY KEY  CLUSTERED 
        (
                [CustomerID] ,
                [CustomerTypeID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CustomerDemographics]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CustomerDemographics]
GO

CREATE TABLE [dbo].[CustomerDemographics] (
        [CustomerTypeID] [nchar] (10) NOT NULL ,
        [CustomerDesc] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerDemographics] WITH NOCHECK ADD
        CONSTRAINT [PK_CustomerDemographics] PRIMARY KEY  CLUSTERED 
        (
                [CustomerTypeID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Customers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Customers]
GO

CREATE TABLE [dbo].[Customers] (
        [CustomerID] [nchar] (5) NOT NULL ,
        [Address] [nvarchar] (60) NULL ,
        [City] [nvarchar] (15) NULL ,
        [CompanyName] [nvarchar] (40) NOT NULL ,
        [ContactName] [nvarchar] (30) NULL ,
        [ContactTitle] [nvarchar] (30) NULL ,
        [Country] [nvarchar] (15) NULL ,
        [Fax] [nvarchar] (24) NULL ,
        [Phone] [nvarchar] (24) NULL ,
        [PostalCode] [nvarchar] (10) NULL ,
        [Region] [nvarchar] (15) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] WITH NOCHECK ADD
        CONSTRAINT [PK_Customers] PRIMARY KEY  CLUSTERED 
        (
                [CustomerID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Employees_ReportsTo]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Employees] DROP CONSTRAINT FK_Employees_ReportsTo
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Employees]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Employees]
GO

CREATE TABLE [dbo].[Employees] (
        [EmployeeID] [int] IDENTITY (1, 1) NOT NULL ,
        [Address] [nvarchar] (60) NULL ,
        [BirthDate] [datetime] NULL ,
        [City] [nvarchar] (15) NULL ,
        [Country] [nvarchar] (15) NULL ,
        [Extension] [nvarchar] (4) NULL ,
        [FirstName] [nvarchar] (10) NOT NULL ,
        [HireDate] [datetime] NULL ,
        [HomePhone] [nvarchar] (24) NULL ,
        [LastName] [nvarchar] (20) NOT NULL ,
        [Notes] [ntext] NULL ,
        [Photo] [image] NULL ,
        [PhotoPath] [nvarchar] (255) NULL ,
        [PostalCode] [nvarchar] (10) NULL ,
        [Region] [nvarchar] (15) NULL ,
        [ReportsTo] [int] NULL ,
        [Title] [nvarchar] (30) NULL ,
        [TitleOfCourtesy] [nvarchar] (25) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employees] WITH NOCHECK ADD
        CONSTRAINT [PK_Employees] PRIMARY KEY  CLUSTERED 
        (
                [EmployeeID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_EmployeeTerritories_EmployeeID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT FK_EmployeeTerritories_EmployeeID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_EmployeeTerritories_TerritoryID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT FK_EmployeeTerritories_TerritoryID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EmployeeTerritories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EmployeeTerritories]
GO

CREATE TABLE [dbo].[EmployeeTerritories] (
        [EmployeeID] [int] NOT NULL ,
        [TerritoryID] [nvarchar] (20) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeeTerritories] WITH NOCHECK ADD
        CONSTRAINT [PK_EmployeeTerritories] PRIMARY KEY  CLUSTERED 
        (
                [EmployeeID] ,
                [TerritoryID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Order Details_OrderID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT FK_Order Details_OrderID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Order Details_ProductID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT FK_Order Details_ProductID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Order Details]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Order Details]
GO

CREATE TABLE [dbo].[Order Details] (
        [OrderID] [int] NOT NULL ,
        [ProductID] [int] NOT NULL ,
        [Discount] [real] NOT NULL ,
        [Quantity] [smallint] NOT NULL ,
        [UnitPrice] [money] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order Details] WITH NOCHECK ADD
        CONSTRAINT [PK_Order Details] PRIMARY KEY  CLUSTERED 
        (
                [OrderID] ,
                [ProductID]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order Details] WITH NOCHECK ADD
        CONSTRAINT [DF_Order Details_Discount] DEFAULT (0) FOR [Discount], 
        CONSTRAINT [DF_Order Details_Quantity] DEFAULT (1) FOR [Quantity], 
        CONSTRAINT [DF_Order Details_UnitPrice] DEFAULT (0) FOR [UnitPrice]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Orders_CustomerID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT FK_Orders_CustomerID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Orders_ShipVia]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT FK_Orders_ShipVia
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Orders_EmployeeID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT FK_Orders_EmployeeID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Orders]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Orders]
GO

CREATE TABLE [dbo].[Orders] (
        [OrderID] [int] IDENTITY (1, 1) NOT NULL ,
        [CustomerID] [nchar] (5) NULL ,
        [EmployeeID] [int] NULL ,
        [Freight] [money] NULL ,
        [OrderDate] [datetime] NULL ,
        [RequiredDate] [datetime] NULL ,
        [ShipAddress] [nvarchar] (60) NULL ,
        [ShipCity] [nvarchar] (15) NULL ,
        [ShipCountry] [nvarchar] (15) NULL ,
        [ShipName] [nvarchar] (40) NULL ,
        [ShippedDate] [datetime] NULL ,
        [ShipPostalCode] [nvarchar] (10) NULL ,
        [ShipRegion] [nvarchar] (15) NULL ,
        [ShipVia] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders] WITH NOCHECK ADD
        CONSTRAINT [PK_Orders] PRIMARY KEY  CLUSTERED 
        (
                [OrderID]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders] WITH NOCHECK ADD
        CONSTRAINT [DF_Orders_Freight] DEFAULT (0) FOR [Freight]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Products_SupplierID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Products] DROP CONSTRAINT FK_Products_SupplierID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Products_CategoryID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Products] DROP CONSTRAINT FK_Products_CategoryID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Products]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Products]
GO

CREATE TABLE [dbo].[Products] (
        [ProductID] [int] IDENTITY (1, 1) NOT NULL ,
        [CategoryID] [int] NULL ,
        [Discontinued] [bit] NOT NULL ,
        [ProductName] [nvarchar] (40) NOT NULL ,
        [QuantityPerUnit] [nvarchar] (20) NULL ,
        [ReorderLevel] [smallint] NULL ,
        [SupplierID] [int] NULL ,
        [UnitPrice] [money] NULL ,
        [UnitsInStock] [smallint] NULL ,
        [UnitsOnOrder] [smallint] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products] WITH NOCHECK ADD
        CONSTRAINT [PK_Products] PRIMARY KEY  CLUSTERED 
        (
                [ProductID]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Products] WITH NOCHECK ADD
        CONSTRAINT [DF_Products_Discontinued] DEFAULT (0) FOR [Discontinued], 
        CONSTRAINT [DF_Products_ReorderLevel] DEFAULT (0) FOR [ReorderLevel], 
        CONSTRAINT [DF_Products_UnitPrice] DEFAULT (0) FOR [UnitPrice], 
        CONSTRAINT [DF_Products_UnitsInStock] DEFAULT (0) FOR [UnitsInStock], 
        CONSTRAINT [DF_Products_UnitsOnOrder] DEFAULT (0) FOR [UnitsOnOrder]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Region]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Region]
GO

CREATE TABLE [dbo].[Region] (
        [RegionID] [int] NOT NULL ,
        [RegionDescription] [nchar] (50) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Region] WITH NOCHECK ADD
        CONSTRAINT [PK_Region] PRIMARY KEY  CLUSTERED 
        (
                [RegionID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Shippers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Shippers]
GO

CREATE TABLE [dbo].[Shippers] (
        [ShipperID] [int] IDENTITY (1, 1) NOT NULL ,
        [CompanyName] [nvarchar] (40) NOT NULL ,
        [Phone] [nvarchar] (24) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Shippers] WITH NOCHECK ADD
        CONSTRAINT [PK_Shippers] PRIMARY KEY  CLUSTERED 
        (
                [ShipperID]
        ) ON [PRIMARY]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Suppliers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Suppliers]
GO

CREATE TABLE [dbo].[Suppliers] (
        [SupplierID] [int] IDENTITY (1, 1) NOT NULL ,
        [Address] [nvarchar] (60) NULL ,
        [City] [nvarchar] (15) NULL ,
        [CompanyName] [nvarchar] (40) NOT NULL ,
        [ContactName] [nvarchar] (30) NULL ,
        [ContactTitle] [nvarchar] (30) NULL ,
        [Country] [nvarchar] (15) NULL ,
        [Fax] [nvarchar] (24) NULL ,
        [HomePage] [ntext] NULL ,
        [Phone] [nvarchar] (24) NULL ,
        [PostalCode] [nvarchar] (10) NULL ,
        [Region] [nvarchar] (15) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Suppliers] WITH NOCHECK ADD
        CONSTRAINT [PK_Suppliers] PRIMARY KEY  CLUSTERED 
        (
                [SupplierID]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblTut] DROP COLUMN [Apa] 
GO

ALTER TABLE [dbo].[tblTut] ADD [Apa] [char] (10) NULL
GO

ALTER TABLE [dbo].[tblTut] DROP COLUMN [Gnu] 
GO

ALTER TABLE [dbo].[tblTut] ADD [Gnu] [char] (10) NULL
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Territories_RegionID]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Territories] DROP CONSTRAINT FK_Territories_RegionID
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Territories]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Territories]
GO

CREATE TABLE [dbo].[Territories] (
        [TerritoryID] [nvarchar] (20) NOT NULL ,
        [RegionID] [int] NOT NULL ,
        [TerritoryDescription] [nchar] (50) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Territories] WITH NOCHECK ADD
        CONSTRAINT [PK_Territories] PRIMARY KEY  CLUSTERED 
        (
                [TerritoryID]
        ) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] WITH NOCHECK ADD
        CONSTRAINT [FK_CustomerCustomerDemo] FOREIGN KEY 
        (
                [CustomerTypeID]
        ) REFERENCES [dbo].[CustomerDemographics] (
                [CustomerTypeID]
        ), 
        CONSTRAINT [FK_CustomerCustomerDemo_Customers] FOREIGN KEY 
        (
                [CustomerID]
        ) REFERENCES [dbo].[Customers] (
                [CustomerID]
        )
GO

ALTER TABLE [dbo].[Employees] WITH NOCHECK ADD
        CONSTRAINT [FK_Employees_Employees] FOREIGN KEY 
        (
                [ReportsTo]
        ) REFERENCES [dbo].[Employees] (
                [EmployeeID]
        )
GO

ALTER TABLE [dbo].[EmployeeTerritories] WITH NOCHECK ADD
        CONSTRAINT [FK_EmployeeTerritories_Territories] FOREIGN KEY 
        (
                [TerritoryID]
        ) REFERENCES [dbo].[Territories] (
                [TerritoryID]
        ), 
        CONSTRAINT [FK_EmployeeTerritories_Employees] FOREIGN KEY 
        (
                [EmployeeID]
        ) REFERENCES [dbo].[Employees] (
                [EmployeeID]
        )
GO

ALTER TABLE [dbo].[Order Details] WITH NOCHECK ADD
        CONSTRAINT [FK_Order_Details_Products] FOREIGN KEY 
        (
                [ProductID]
        ) REFERENCES [dbo].[Products] (
                [ProductID]
        ), 
        CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY 
        (
                [OrderID]
        ) REFERENCES [dbo].[Orders] (
                [OrderID]
        )
GO

ALTER TABLE [dbo].[Orders] WITH NOCHECK ADD
        CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY 
        (
                [ShipVia]
        ) REFERENCES [dbo].[Shippers] (
                [ShipperID]
        ), 
        CONSTRAINT [FK_Orders_Employees] FOREIGN KEY 
        (
                [EmployeeID]
        ) REFERENCES [dbo].[Employees] (
                [EmployeeID]
        ), 
        CONSTRAINT [FK_Orders_Customers] FOREIGN KEY 
        (
                [CustomerID]
        ) REFERENCES [dbo].[Customers] (
                [CustomerID]
        )
GO

ALTER TABLE [dbo].[Products] WITH NOCHECK ADD
        CONSTRAINT [FK_Products_Categories] FOREIGN KEY 
        (
                [CategoryID]
        ) REFERENCES [dbo].[Categories] (
                [CategoryID]
        ), 
        CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY 
        (
                [SupplierID]
        ) REFERENCES [dbo].[Suppliers] (
                [SupplierID]
        )
GO

ALTER TABLE [dbo].[Territories] WITH NOCHECK ADD
        CONSTRAINT [FK_Territories_Region] FOREIGN KEY 
        (
                [RegionID]
        ) REFERENCES [dbo].[Region] (
                [RegionID]
        )
GO

