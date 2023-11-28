create database EcommerceDB
USE EcommerceDB

create table Customer
(
  	CustomerID int,
	Name varchar(50),
	password varchar(50),
	Email varchar(50), 
	Address varchar(50),
	Phone varchar(50),
    primary key (CustomerID)
);
insert into Customer values 
  (1, 'ammar ahmed','5050', 'ammar@email.com', 'cairo', '01111111111'),
 (2, 'Bob Johnson','5050', 'bob@email.com', '456 Oak Ave', '987-654-3210'),
 (3, 'Charlie Brown','5050', 'charlie@email.com', '789 Elm St', '111-222-3333'),
 (4, 'David Lee','5050', 'david@email.com', '321 Maple Dr', '444-555-6666'),
 (5, 'Eva Garcia','5050', 'eva@email.com', '555 Pine Ave', '777-888-9999'),
 (6, 'Frank White','5050', 'frank@email.com', '678 Walnut Ln', '333-222-1111'),
 (7, 'Grace Turner','5050', 'grace@email.com', '901 Cedar St', '555-444-3333'),
 (8, 'Hannah Baker', '5050','hannah@email.com', '234 Birch Ave', '999-888-7777'),
 (9, 'Ian Foster','5050', 'ian@email.com', '765 Spruce Dr', '222-333-4444'),
 (10, 'Jennifer Hall','5050', 'jennifer@email.com', '543 Cherry Rd', '888-999-0000'), 
 (11, 'Kevin Young','5050', 'kevin@email.com', '876 Oakwood Blvd', '777-666-5555'),
 (12, 'Lily Adams','5050', 'lily@email.com', '432 Elmwood Ave', '666-777-8888'),
 (13, 'Mike Clark','5050', 'mike@email.com', '789 Pinecone Ln', '444-333-2222'),
 (14, 'Nancy Green','5050', 'nancy@email.com', '210 Maplewood Dr', '333-444-5555'),
 (15, 'Olivia King', '5050','olivia@email.com', '987 Cedarwood Dr', '222-111-0000'),
 (16, 'Paul Miller','5050', 'paul@email.com', '654 Oakhurst Rd', '111-222-3333'),
 (17, 'Quinn Harris', '5050','quinn@email.com', '345 Pine Ridge', '999-888-7777'),
 (18, 'Rachel Scott','5050', 'rachel@email.com', '543 Birchwood Ave', '888-777-6666'),
 (19, 'Sam Taylor', '5050','sam@email.com', '876 Elmwood Blvd', '777-666-5555'),
(20, 'Tina Wright', '5050','tina@email.com', '234 Spruceland Dr', '666-555-4444');

create table Sellers(
	sellerID INT PRIMARY KEY,
	sellerName varchar(50),
	sellerPassword varchar(50)
)
insert into Sellers values
(1, 'reda', '5050');
select * from Sellers

create table Product 

( 
  	ProductID int,
	Name varchar(50),
	Description varchar(50),
	Price int,
	StockQuantity int,
	primary key (ProductID)
);
insert into Product values 

 (101, 'T-Shirt', 'Cotton t-shirt, black', 19.99, 50        ),
 (102, 'Jeans', 'Blue denim jeans, slim fit', 39.99, 30     ),
 (103, 'Sneakers', 'White canvas sneakers', 29.99, 25       ),
 (104, 'Backpack', 'Nylon backpack, black', 49.99, 20       ),
 (105, 'Watch', 'Stainless steel watch, analog', 99.99, 15  ),
 (106, 'Dress', 'Floral print dress, knee-length', 59.99, 20),
 (107, 'Jacket', 'Leather jacket, brown', 79.99, 10         ),
 (108, 'Running Shoes', 'Mesh running shoes, red', 49.99, 25),
 (109, 'Hoodie', 'Cotton hoodie, gray', 34.99, 30           ),
 (110, 'Skirt', 'Pleated skirt, navy blue', 39.99, 25       ),
 (111, 'Sweater', 'Knit sweater, striped', 44.99, 20        ),
 (112, 'Blouse', 'Silk blouse, white', 29.99, 25            ),
 (113, 'Boots', 'Leather boots, black', 69.99, 15           ),
 (114, 'Scarf', 'Cashmere scarf, plaid', 24.99, 40          ),
 (115, 'Shorts', 'Cargo shorts, khaki', 19.99, 35           ),
 (116, 'Polo Shirt', 'Collared polo shirt, blue', 24.99, 30 ),
 (117, 'Sunglasses', 'Polarized sunglasses, aviator', 59.99, 20),
 (118, 'Handbag', 'Leather handbag, tan', 89.99, 15         ),
 (119, 'Earrings', 'Diamond stud earrings', 149.99, 10      ),
 (120, 'Necklace', 'Gold-plated necklace, pendant', 199.99, 5);
 create table Cart 
( 
  	CartID int,
	CustomerID int,
	CreationDate date,
	primary key (CartID),
	foreign key (CustomerID) REFERENCES Customer (CustomerID)

);
insert into Cart values 
(501, 1, '2023-11-23'),
(502, 2, '2023-11-22'),
(503, 3, '2023-11-21'),
(504, 4, '2023-11-20'),
(505, 5, '2023-11-19'),
(506, 6, '2023-11-18'),
(507, 7, '2023-11-17'),
(508, 8, '2023-11-16'),
(509, 9, '2023-11-15'),
(510, 10, '2023-11-14'),
(511, 11, '2023-11-13'),
(512, 12, '2023-11-12'),
(513, 13, '2023-11-11'),
(514, 14, '2023-11-10'),
(515, 15, '2023-11-09'),
(516, 16, '2023-11-08'),
(517, 17, '2023-11-07'),
(518, 18, '2023-11-06'),
(519, 19, '2023-11-05'),
(520, 20, '2023-11-04');
create table Order_table
(
OrderID int,
CustomerID int,
OrderDate date,
TotalAmount int,
primary key (OrderID),
foreign key (CustomerID) references Customer (CustomerID)
);
insert into Order_table values 
(701, 1, '2023-11-15', 39.98),
(702, 2, '2023-11-16', 109.97),
(703, 3, '2023-11-17', 59.97),
(704, 4, '2023-11-18', 99.99),
(705, 5, '2023-11-19', 149.97),
(706, 6, '2023-11-20', 119.98),
(707, 7, '2023-11-21', 179.97),
(708, 8, '2023-11-22', 89.99),
(709, 9, '2023-11-23', 169.97),
(710, 10, '2023-11-24', 259.95),
(711, 11, '2023-11-25', 219.96),
(712, 12, '2023-11-26', 129.98),
(713, 13, '2023-11-27', 299.94),
(714, 14, '2023-11-28', 69.97),
(715, 15, '2023-11-29', 249.95),
(716, 16, '2023-11-30', 159.96),
(717, 17, '2023-12-01', 119.97),
(718, 18, '2023-12-02', 199.95),
(719, 19, '2023-12-03', 189.96),
(720, 20, '2023-12-04', 279.94); 
create table Order_Details
(
	OrderDetailID int ,
	OrderID int,
	ProductID int,
	Quantity int,
	UnitPrice int,
	primary key (OrderDetailID),
	foreign key (OrderID) references Order_table (OrderID),
	foreign key (ProductID) references Product (ProductID)
);
insert into Order_Details values 
(901, 701, 101, 2, 19.99),
(902, 702, 103, 1, 29.99),
(903, 702, 102, 3, 39.99),
(904, 703, 105, 1, 99.99),
(905, 704, 104, 1, 49.99),
(906, 706, 106, 2, 59.99),
(907, 706, 107, 1, 79.99),
(908, 707, 108, 3, 49.99),
(909, 708, 109, 2, 34.99),
(910, 709, 110, 3, 119.97),
(911, 710, 111, 2, 89.98),
(912, 711, 112, 1, 29.99),
(913, 711, 113, 1, 69.99),
(914, 712, 114, 4, 99.96),
(915, 713, 115, 3, 59.97),
(916, 714, 116, 1, 24.99),
(917, 715, 117, 2, 119.98),
(918, 716, 118, 1, 89.99),
(919, 717, 119, 2, 299.98),
(920, 718, 120, 1, 199.99);

--1--
select distinct name from Product
--2--
SELECT Address, COUNT(DISTINCT CustomerID) as CustomerCount from Customer group by Address;
--3--
select sum(TotalAmount) as TotalRevenue from Order_table where OrderDate >= DATEADD(MONTH, -1, GETDATE());
--4--
select p.Name from Product p where StockQuantity = 0;
--5--
select avg(Price) as averagePrice from Product group by Name;
--6--
SELECT CustomerID, COUNT(OrderID) AS OrderCount FROM Order_table GROUP BY CustomerID;
--7--
select ot.CustomerID from Order_table ot group by ot.CustomerID having SUM(ot.TotalAmount) > 1000;
--8--
select min(Price) minimumPrice, max(Price) maximumPrice from Product
--9--
select TOP 5 od.ProductID, count(od.ProductID)Most_Ordered_Products
from Order_Details od group by ProductID order by Most_Ordered_Products DESC 
--10--
select CustomerID, Name from Customer where Name like 'A%';
--11--
select o.OrderID from Order_table o where OrderDate between '2023-11-04' and '2023-11-20';
--12--
select p.Name, SUM(p.StockQuantity)Total_Quantity  from Product p group by Name;
--13--
select c.Name CustomerName, p.Name ProductName
from Customer c
inner join Order_table ot 
	on c.CustomerID = ot.CustomerID
inner join Order_Details od
	on od.ProductID in (101, 103, 105) and od.OrderID = ot.OrderID
inner join Product p
	on p.ProductID = od.ProductID
--14--
SELECT OrderID, COUNT(OrderDetailID) AS ProductCount
FROM Order_Details
GROUP BY OrderID
HAVING COUNT(OrderDetailID) > 3;
--15--
select AVG(p.StockQuantity) ProductAvrageQuantity from Product p
--16--
select Name from Product where Price between 50 and 100;
--17--
select YEAR(OrderDate) AS OrderYear, sum(ot.TotalAmount) TotalRevenue from Order_table ot group by YEAR(ot.OrderDate)
--18--
select c.Address, COUNT(c.Address) customers_placed_orders 
from Customer c 
inner join Order_table ot
on c.CustomerID = ot.CustomerID
group by c.Address 
--19--
select top 5 ProductID ,MAX(Quantity) MaxQuantity 
from Order_Details
group by ProductID order by MaxQuantity desc
--20-- 
select ProductID, count(OrderDetailID)OrdersCount from Order_Details group by ProductID having count(OrderDetailID) > 10;

select Name, CustomerID from Customer where CustomerID IN (1, 2, 3, 4)
UNION
select Name, CustomerID from Customer where CustomerID = 3;

select Name, CustomerID from Customer where CustomerID IN (1, 2, 3, 4)
EXCEPT
select Name, CustomerID from Customer where CustomerID = 3;

select Name, CustomerID from Customer where CustomerID IN (1, 2, 3, 4)
INTERSECT
select Name, CustomerID from Customer where CustomerID = 3;

select c.*, ot.* from Customer c
FULL OUTER join Order_table ot
on ot.CustomerID IN (1, 2, 3, 4) and ot.CustomerID = c.CustomerID order by ot.OrderDate;

--Stored Procedure Creation = create+'proc'+ProcName+'AS'+'BEGIN'+SELECT+'END' => EXEC
CREATE PROC spYear
@GetYear NCHAR(4)
AS
BEGIN
	select YEAR(OrderDate) AS OrderYear, sum(ot.TotalAmount) TotalRevenue 
	from Order_table ot 
	group by YEAR(ot.OrderDate) having YEAR(ot.OrderDate) = @GetYear
END
exec spYear'2023'; 
sp_helpText 'spYear'

/*The TRIGGER
CREATE TRIGGER tr_Cust_fordelete
ON Customer
FOR DELETE
AS
BEGIN
DECLEARE @ID INT
SELECT @ID = CustomerID FROM DELETED
INSERT INTO Customer Values ()
END
*/

--Viewers
CREATE VIEW vw_PriviosYears
as
select sum(TotalAmount) as TotalRevenue
from Order_table 
where OrderDate >= DATEADD(MONTH, -1, GETDATE());
--excute viewr
select * from [dbo].[vw_PriviosYears]

CREATE PROC spYearWithEncripiton
@GetYear NCHAR(4)
WITH ENCRYPTION
AS
BEGIN
	select YEAR(OrderDate) AS OrderYear, sum(ot.TotalAmount) TotalRevenue 
	from Order_table ot 
	group by YEAR(ot.OrderDate) having YEAR(ot.OrderDate) = @GetYear
END
exec spYearWithEncripiton '2023'
sp_helpText 'spYearWithEncripiton'