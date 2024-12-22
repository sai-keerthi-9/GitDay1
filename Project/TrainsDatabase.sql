create database project

use project
--Train table
create table Trains
(
 Train_No int primary key,
 Train_Name varchar(20),
 TotalBerths int,
 AvailableBerths int,
 Source varchar(20),
 Destination varchar(20),
 IsActive bit,
)

select * from Trains

--Bookings table
create table Bookings
(
train_no int references Trains(Train_NO),
BookingId int primary key,
CustomerId int,
class varchar(20),
NoOfTicketsNeedToBook int,
BookinDate DATETIME,
)

select * from Bookings

--procedure to book ticket
create or alter procedure BookTickets(@tno int,@cid int,@tclass varchar(20),@seats int,@status varchar(50) output)
as
begin
    declare @bid int
    select @bid=ISNULL(MAX(BookingId),0)+1 from Bookings
    declare @Availableseats int,@isavailable bit;
    select @Availableseats =   AvailableBerths,@isavailable=IsActive from Trains where Train_No = @tno;
    if @Availableseats >= @seats AND @isavailable=1
    begin
        insert into Bookings values (@tno,@bid ,@cid,@tclass,@seats, getdate());
-- Updating available berths
        update Trains set AvailableBerths = AvailableBerths - @seats where Train_No = @tno;
		set @status='Booking confirmed !!';
    end
    else
    begin
        set @status='Less berths are available or train is inactive !!';
    end
end
--testing BookTickets Procedure in sql
exec BookTickets 100,1,'first class',10

--procedure to cancel booking
create or alter procedure CancelBooking (@bid int)
as
begin
    declare @tno int, @seats int;
    select @tno = Train_No, @seats = NoOfTicketsNeedToBook from Bookings where BookingId = @bid;
    delete from Bookings where BookingID = @bid;
    update Trains set AvailableBerths = AvailableBerths + @seats where Train_No = @tno;
end
 --procedure to show all trains
 create or alter proc ShowTrains
 as
 begin
     select * from Trains where IsActive=1;
 end

 --procedure to select train after giving source and destination
 create or alter procedure SelectTrain(@tsource varchar(20),@tdestination varchar(20))
as
begin
  
   select * from Trains where Source=@tsource and Destination=@tdestination and ISActive=1; 
end