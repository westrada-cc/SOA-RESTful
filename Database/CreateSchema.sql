use CrazyMelvinsShoppingEmporiumDb;

IF OBJECT_ID('Cart', 'U') IS NOT NULL
  DROP TABLE Cart; 
IF OBJECT_ID('[Order]', 'U') IS NOT NULL
  DROP TABLE [Order]; 
IF OBJECT_ID('Product', 'U') IS NOT NULL
  DROP TABLE Product; 
IF OBJECT_ID('Customer', 'U') IS NOT NULL
  DROP TABLE Customer; 

create table Customer
(
	custID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	firstName NVARCHAR(50),
	lastName NVARCHAR(50) NOT NULL,
	phoneNumber NVARCHAR(15) NOT NULL
);

create table Product
(
	prodID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	prodName NVARCHAR(100) NOT NULL,
	price FLOAT NOT NULL,
	prodWeight FLOAT NOT NULL,
	inStock BIT NOT NULL
);

create table [Order]
(
	orderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	custID INT NOT NULL FOREIGN KEY (custID) REFERENCES Customer (custID) ON DELETE CASCADE ON UPDATE CASCADE,
	poNumber NVARCHAR(30),
	orderDate DATETIME NOT NULL
);

create table Cart
(
	orderID INT NOT NULL FOREIGN KEY (orderID) REFERENCES [Order] (orderID) ON DELETE CASCADE ON UPDATE CASCADE,
	prodID INT NOT NULL FOREIGN KEY (prodID) REFERENCES Product (prodID) ON DELETE CASCADE ON UPDATE CASCADE,
	quantity INT NOT NULL,
	PRIMARY KEY (orderID, prodID)
);

insert into Customer (firstName, lastName, phoneNumber) VALUES 
('Joe', 'Bzolay', '555-555-1212'),
('Nancy', 'Finklbaum', '555-235-4578'),
('Henry', 'Svitzinski', '555-326-8456');

insert into Product (prodName, price, prodWeight, inStock) VALUES
('Grapple Grommet','0.02','0.005','1'),
('Wandoozals','2.35','0.532','1'),
('Kardoofals','8.75','5.650','0');

INSERT INTO [Order] (custID, orderDate, poNumber) VALUES
(1,'2011-09-15', 'GRAP-09-2011-001'),
(1,'2011-09-30', 'GRAP-09-2011-056'),
(3,'2011-10-05', null);

INSERT INTO Cart (orderID, prodID, quantity) VALUES
(1,1,500),
(1,2,1000),
(2,3,10),
(3,1,75),
(3,2,15),
(3,3,5);