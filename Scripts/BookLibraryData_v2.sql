
CREATE TABLE dbo.Authors(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL,
	CreatedDate DATETIME NOT NULL DEFAULT(GETDATE()),
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
);
GO

CREATE TABLE dbo.Publishers(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Name VARCHAR (100) NOT NULL,	
	CreatedDate DATETIME NOT NULL DEFAULT(GETDATE()),
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
);
GO

CREATE TABLE dbo.Books(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Title VARCHAR(100) NOT NULL,
	AuthorId INT NOT NULL,
	PublisherId INT NOT NULL,	
	GenderType VARCHAR(50),
	Isbn VARCHAR (80),
	Category VARCHAR(50),	
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
	CONSTRAINT FK_Author_Book FOREIGN KEY (AuthorId)REFERENCES dbo.Authors(Id),
	CONSTRAINT FK_Publisher_Book FOREIGN KEY (PublisherId)REFERENCES dbo.Publishers(Id)
);
GO

CREATE TABLE dbo.Libraries(
	IdLibrary INT PRIMARY KEY IDENTITY (1, 1),
	Name VARCHAR (100) NOT NULL,	
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
);
GO

CREATE TABLE dbo.LibraryBooks(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	LibraryId INT NOT NULL,
	BookId INT NOT NULL,
	TotalCopies INT NOT NULL DEFAULT 0,
	CopiesInUse INT NOT NULL DEFAULT 0,
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
	CONSTRAINT FK_Library_Book FOREIGN KEY (BookId)REFERENCES dbo.Books(Id),
	CONSTRAINT FK_Library FOREIGN KEY (LibraryId)REFERENCES dbo.Libraries(Id)
);
GO

CREATE TABLE dbo.PersonalLibraryBooks(
	Id INT PRIMARY KEY IDENTITY (1, 1),
	LibraryBookId INT NOT NULL,
	MarkAs SMALLINT NOT NULL DEFAULT(0), -- 0 = None | 1 = own | 2 = love | 3 = want to read
	CreatedBy VARCHAR(100) NOT NULL,
	ModifiedDate DATETIME,
	ModifiedBy VARCHAR(100),
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID()),
	IsDeleted BIT NOT NULL DEFAULT(0)
	CONSTRAINT FK_Personal_Library_Book FOREIGN KEY (LibraryBookId) REFERENCES dbo.LibraryBooks(Id)
);
GO

CREATE VIEW dbo.PersonalLibraryView
AS
	SELECT b.Title, pu.Name AS Publisher, CONCAT(a.FirstName, ' ', a.LastName) AS Authors, b.GenderType, b.Isbn, b.Category, CONCAT(lb.CopiesInUse, '/', lb.TotalCopies) AvailableCopies
	FROM dbo.PersonalLibraryBooks p
	JOIN dbo.LibraryBooks lb ON p.LibraryBookId = lb.Id
	JOIN dbo.Libraries l ON lb.LibraryId = l.Id
	JOIN dbo.Books b ON lb.BookId = b.Id
	JOIN dbo.Publishers pu ON b.PublisherId = pu.Id
	JOIN dbo.Authors a ON b.AuthorId = a.Id
GO



