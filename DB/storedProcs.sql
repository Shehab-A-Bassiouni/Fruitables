create VIEW SalesView AS

	select isnull(I.subTotalPrice, 0.0)as subtotal, O.date  as ODate, P.sellerID as sellerID, P.name, I.quantity from  Items I inner join Orders O 
	on I.orderID = O.orderID inner join Products P on P.productID = I.productID and O.state = 3



create proc GetSellerStatistics  @sellerId int
as


	declare @dataATble table(subtotal decimal, ODate datetime, sellerID int, Pname varchar(50), quantity decimal )
	
	if @sellerId = 0
		begin
			insert into @dataATble 
			select * from SalesView  
		end
		else
			begin 
				insert into @dataATble 
				select * from SalesView where sellerID = @sellerId
			end
	
	declare @todaySalles decimal
	declare @yesterdaySalles decimal

	declare @MonthSalles decimal	
	declare @LastMonthSalles decimal	

	declare @mostSold varchar(50) 
	declare @qntitySold decimal

	
	DECLARE @startDate DATETIME = concat(Year(GETDATE()), '-', MONTH(GETDATE()), '-', DAY(GETDATe()),   ' 00:00:00');
	DECLARE @endDate DATETIME=  concat(Year(GETDATE()), '-', MONTH(GETDATE()), '-', DAY(GETDATe()),   ' 23:59:59');

	declare @t table( todaySales decimal, yesterDaySales decimal, monthSales decimal, lastmonthSales decimal)
	
	
	select @todaySalles =  isnull(sum(subtotal),0)  from @dataATble
	where ODate between  @startDate and @endDate 

		
	select @yesterdaySalles =  isnull(sum(subtotal),0) from @dataATble
	where ODate between DATEADD(day, -1, @startDate)  and DATEADD(day, -1, @endDate) 

	select @MonthSalles =  isnull(sum(subtotal),0)  from  @dataATble
	where Month(ODate) = Month(GETDATE()) and YEAR(ODate) = YEAR(GETDATE()) 
	
	select @LastMonthSalles =  isnull(sum(subtotal),0)  from  @dataATble
	where Month(ODate) = (Month(GETDATE()) - 1) and YEAR(ODate) = YEAR(GETDATE()) 

	insert into @t values(@todaySalles, @yesterdaySalles, @MonthSalles, @LastMonthSalles)

	select * from @t


create proc GetMonthRevenue @sellerID int, @year int
as
	if @sellerID = 0
	begin
		SELECT 
		MONTH(O.date) AS Month,
   
		SUM(I.subTotalPrice) AS TotalSales
		FROM 
			Orders O
		INNER JOIN 
			Items I ON O.orderID = I.orderID

			INNER JOIN 
			Products P ON p.productID = I.productID
		WHERE 
			O.state = 3 
			AND YEAR(O.date) = @year
		GROUP BY 
			MONTH(O.date)
		ORDER BY 
			MONTH(O.date);
		end
	else
		begin
		SELECT 
		MONTH(O.date) AS Month,
   
		SUM(I.subTotalPrice) AS TotalSales
		FROM 
			Orders O
		INNER JOIN 
			Items I ON O.orderID = I.orderID

			INNER JOIN 
			Products P ON p.productID = I.productID
		WHERE 
			O.state = 3 and P.sellerID = @sellerID
			AND YEAR(O.date) = @year
		GROUP BY 
			MONTH(O.date)
		ORDER BY 
			MONTH(O.date);
		end



create proc GetBestSellProduct @sellerID int, @year int
as
	if @sellerID = 0
		begin
			SELECT top(10)S.name as pname, sum(quantity) as quantity from SalesView S 
			where YEAR(ODate) = @year
			group by S.name order by quantity desc
		end
	else
		begin
			SELECT top(10)S.name as pname, sum(quantity) as quantity from SalesView S 
			where YEAR(ODate) = @year and s.sellerID = @sellerID
			group by S.name order by quantity desc
		end
	

	
create proc getBestSelelrs @year int
as
 select top(10) s.commercialName as Commercialname, sum(isnull(I.subTotalPrice, 0.0)) as totalSales from Items I inner join Orders O 
	on I.orderID = O.orderID inner join Products P on P.productID = I.productID  inner join Sellers S
	on p.sellerID = S.sellerID 
	where O.state = 3 and YEAR(O.date) = @year
	group by S.commercialName order by totalSales desc

