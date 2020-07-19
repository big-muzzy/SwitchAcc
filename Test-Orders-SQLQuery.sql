declare @productCount int
set @productCount = 3

declare @total money
set @total = 50000

declare @personCount int
set @personCount = 3

declare @GroupOrders Table 
(
	RegionID int, 
	ProductId int, 
	ProductCount int, 
	PersonCount int, 
	Total money
);

insert into @GroupOrders
select Person.RegionId RegionID, Product.Id ProductId, count(Product.Id) ProductCount, count(Person.Id) PersonCount, sum(Price.Price*OrderItem.ProductCount) Total
from dbo.OrderItem OrderItem
left join dbo.Person Person on Person.Id = OrderItem.PersonId
left join dbo.Price Price on Price.Id = OrderItem.PriceId
left join dbo.Product Product on Product.Id = Price.ProductId
group by Person.RegionId, Product.Id
having 
	count(Product.Id) >= @productCount and 
	sum(Price.Price*OrderItem.ProductCount) >= @total and
	count(Person.Id) >= @personCount; --Группировка по регионам и товарам


declare @MaxOrders Table 
(
	RegionID int, 
	ProductCount int
);

insert into @MaxOrders 
select RegionID, max(ProductCount) ProductCount
from @GroupOrders 
group by RegionID; --Выбор максимальных продаж по регионам

declare @MaxTotal Table 
(
	RegionID int, 
	ProductCount int,
	MaxTotal money
);

insert into @MaxTotal
select top 10 MaxOrders.RegionID, MaxOrders.ProductCount,
	(select max(GroupOrders.Total) 
	from @GroupOrders GroupOrders
	where MaxOrders.RegionId = GroupOrders.RegionID and MaxOrders.ProductCount = GroupOrders.ProductCount) MaxTotal
from @MaxOrders MaxOrders
order by ProductCount desc, MaxTotal desc; --Выбор регионов, продавших максимальное количество какого-либо товара и максимальная сумма продаж

select Region.RegionName, Product.ProductName, GroupOrders.ProductCount, GroupOrders.PersonCount, GroupOrders.Total
from @MaxTotal MaxTotal
inner join @GroupOrders GroupOrders on
	GroupOrders.RegionID = MaxTotal.RegionID and
	GroupOrders.ProductCount = MaxTotal.ProductCount and
	GroupOrders.Total = MaxTotal.MaxTotal 
inner join dbo.Region Region on Region.Id = MaxTotal.RegionID
inner join dbo.Product Product on Product.Id = GroupOrders.ProductId
order by Region.RegionName; --Вывод результатов по форме

