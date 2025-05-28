
CREATE TABLE dbo.Books(
	BookId INT PRIMARY KEY IDENTITY (1, 1),
	Title VARCHAR(100) NOT NULL,
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL,
	TotalCopies INT NOT NULL DEFAULT 0,
	CopiesInUse INT NOT NULL DEFAULT 0,
	GenderType VARCHAR(50),
	Isbn VARCHAR (80),
	Category VARCHAR(50),
	MarkAs SMALLINT NOT NULL DEFAULT(0), -- 0 = None | 1 = own | 2 = love | 3 = want to read
	CreatedDate DATETIME NOT NULL DEFAULT(GETDATE()),
	ModifiedDate DATETIME,
	RowId UNIQUEIDENTIFIER NOT NULL DEFAULT(NEWID())
);
GO


INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('Pride and Prejudice', 'Jane', 'Austen', 100, 80, 'Hardcover', '1234567891', 'Fiction', 0);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('To Kill a Mockingbird', 'Harper', 'Lee', 75, 65, 'Paperback', '1234567892', 'Fiction', 1);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Catcher in the Rye', 'J.D.', 'Salinger', 50, 45, 'Hardcover', '1234567893', 'Fiction', 2);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Great Gatsby', 'F. Scott', 'Fitzgerald', 50, 22, 'Hardcover', '1234567894', 'Non-Fiction', 3);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Alchemist', 'Paulo', 'Coelho', 50, 35, 'Hardcover', '1234567895', 'Biography', 3);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Book Thief', 'Markus', 'Zusak', 75, 11, 'Hardcover', '1234567896', 'Mystery', 2);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Chronicles of Narnia', 'C.S.', 'Lewis', 100, 14, 'Paperback', '1234567897', 'Sci-Fi', 1);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Da Vinci Code', 'Dan', 'Brown', 50, 40, 'Paperback', '1234567898', 'Sci-Fi', 0);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Grapes of Wrath', 'John', 'Steinbeck', 50, 35, 'Hardcover', '1234567899', 'Fiction', 1);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Hitchhiker''s Guide to the Galaxy', 'Douglas', 'Adams', 50, 35, 'Paperback', '1234567900', 'Non-Fiction', 2);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('Moby-Dick', 'Herman', 'Melville', 30, 8, 'Hardcover', '8901234567', 'Fiction', 3);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('To Kill a Mockingbird', 'Harper', 'Lee', 20, 0, 'Paperback', '9012345678', 'Non-Fiction', 2);
INSERT INTO BOOKS(Title, FirstName, LastName, TotalCopies, CopiesInUse, GenderType, Isbn, Category, MarkAs) VALUES ('The Catcher in the Rye', 'J.D.', 'Salinger', 10, 1, 'Hardcover', '0123456789', 'Non-Fiction', 1);

