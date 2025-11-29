-- require northwind sample database,sql server 2016+
CREATE OR ALTER PROCEDURE proc_get_top_countries_sales
(
@top int =10
)
as
DECLARE @result table(Country nvarchar(300),Amount decimal);

INSERT INTO @result
SELECT DISTINCT  c.Country,
SUM((od.UnitPrice*od.Quantity)*(1-od.Discount)) OVER(PARTITION BY c.Country) as Total
FROM Customers as c 
INNER JOIN  Orders as o ON c.CustomerID=o.CustomerID
JOIN [Order Details] as od ON o.OrderID=od.OrderID



SELECT TOP(@top) * FROM @result AS r
ORDER BY r.Amount desc 


--EXECUTE proc_get_top_countries_sales