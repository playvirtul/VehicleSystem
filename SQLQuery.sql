CREATE TABLE Customers 
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100)
);

CREATE TABLE Orders 
(
    Id INT PRIMARY KEY IDENTITY,
    CustomerId INT REFERENCES Customers (Id)
);

INSERT Customers
VALUES 
('Max'),
('Pavel'),
('Ivan'),
('Leonid');

INSERT Orders
VALUES 
(2),
(4);

SELECT Name AS "Customers"
FROM Customers LEFT JOIN Orders
ON Orders.CustomerId = Customers.Id
WHERE Orders.CustomerId IS NULL;