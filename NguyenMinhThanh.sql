
Select c.Name as CustomerName, p.Name as ProductName, Sum(Quantity) as Total
From Customer c
join SalesOrder o on c.Id = o.CustomerId
join SalesOrderDetail od on o.Id = od.SalesOrderId
join Product p on p.Id = od.ProductId
Where p.Name = 'Pegasus'
Group By c.Name, p.Name
Having Sum(Quantity) = (
		Select Max(Total)
		From (
				Select c.Name as CustomerName, p.Name as ProductName, Sum(Quantity) as Total
				From Customer c
				join SalesOrder o on c.Id = o.CustomerId
				join SalesOrderDetail od on o.Id = od.SalesOrderId
				join Product p on p.Id = od.ProductId
				Where p.Name = 'Pegasus'
				Group By c.Name, p.Name
		) AS A
)