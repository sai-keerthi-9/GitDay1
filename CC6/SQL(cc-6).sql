use assessments
create table Course_Details
(
CID varchar(10),
CName varchar(20),
StartDate datetime,
EndDate datetime,
Fee int
)

insert into Course_Details values('DN003','DotNet','2018-02-01','2018-02-28',15000),
('DV004','Data Visualization','2018-03-01','2018-04-15',15000),
('JA002','Advanced Java','2018-01-02','2018-01-20',10000),
('JC001','Core Java','2018-01-02','2018-01-12',3000)

select * from Course_Details

--1.Create a Function to calculate the course duration for the above relation by receiving start date and end date as input.

create or alter function Course_Duration (@startdate datetime,@enddate datetime)
returns int
as
begin
declare @duration int 
select @duration=DATEDIFF(DAY,@startdate,@enddate) from Course_Details
return @duration
end

select CID,CName,assessments.dbo.Course_Duration(StartDate,EndDate) as Duration,Fee from Course_Details


--2.Create a trigger to display the Course Name and Start date of the course

create or alter trigger tgrDisplay
on Course_Details
for insert
as
begin
 insert into Course_Details(CName,StartDate)
 select CName,StartDate from inserted
 select * from Course_Details
end

insert into Course_Details values('AB009','Devops','2018-07-09','2018-08-09',5000)

--3.Write a stored Procedure that inserts records in the ProductsDetails table
create table Products
(
PID int,
PName varchar(20),
Price int,
DiscountPrice float
)
select * from Products

--Procedure
create or alter proc Product_Details(@pname varchar(20),@price int,@pid int out,@discount float out)
as
begin
  set @discount=@price*0.10
  declare @maxpid int 
   select @maxpid=ISNULL(MAX(PID),0)+1 from Products
   insert into Products values(@maxpid,@pname,@price,@discount)

end

declare @id int,@discount varchar(20),@pname varchar(20),@price int
Exec Product_Details 'Keerthi', 10000, @id output ,@discount output
select @pname=PName,@price=Price from Products
print 'PID : '+cast(@id as varchar(10))+'Product Name : ' +cast(@pname as varchar(10))
        +'Price : '+cast(@price as varchar(10))+'Discount : '+cast(@id as varchar(10))

		select * from Products
		
		

