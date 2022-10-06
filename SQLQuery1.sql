Create database ContosoEventsDB
use ContosoEventsDB
--User Table
--User User_Id Column incerments like 1,6,11......
create table User_Details
(
User_Id int identity(1,5),
User_UserName  varchar(30) UNIQUE not null,
User_FirstName varchar(30),
User_LastName varchar(30),
User_Email varchar(30) UNIQUE not null,
User_Contact bigint UNIQUE not null ,
User_Password varchar(30),
User_Gender varchar(10),
User_Country varchar(30),
User_Address varchar(50)
constraint PK_User_Details primary key(User_Id)
)

select * from [dbo].[User_Details]


create table Ticket_Category
(
TicketCategory_Id int identity(1,1),
TicketCategory_Name varchar(50),
TicketCategory_TicketsAvailable int,
constraint PK_Ticket_Category primary key(TicketCategory_Id)
)


--Events Table
--Events Event_ID Column incerments like 111,115,119.......

create table Events_Details (
Event_ID int identity(101,5),
Event_Name varchar(50)  not null,
Event_Type varchar(30)  not null,
Event_Location varchar(30),
Event_Startdate date not null,
Event_Enddate date not null,
Event_Status varchar(10),
Event_Ticket_Catageory int
constraint PK_Events_Details primary key(Event_ID)
constraint FK_Events_Details foreign key (Event_Ticket_Catageory) references Ticket_Category(TicketCategory_Id)
)

select * from [dbo].[Events_Details]

--Booking Table
--Booking Booking_Id Column incerments like 222,224,226.......
create table Booking_Details
(
Booking_Id int identity(1001,5),
Booking_Event_Id int,
Booking_Amount Money not null,
Booking_User_Id int,
Booking_NumberofTickets Int not null,
Booking_Single_UnitPrice Money

constraint PK_Booking_Details primary key(Booking_Id)
constraint FK_Booking_Details 
           foreign key (Booking_Event_Id) references Events_Details(Event_ID),
           foreign key (Booking_User_Id) references User_Details(User_Id)

)
select * from [dbo].[Booking_Details]

--Promo Code details
--Table with all promocodes

create table Promo_Codes
(
Promo_Id int identity(1,1),
Promo_Name varchar(50) UNIQUE not null,
Promo_Offer int
constraint PK_Promo_Codes primary key(Promo_Id)
)

select * from Promo_Codes


--Payment Table
--PaymentTable column Payment_Id Column incerments like 333,335,337.......

CREATE table Payment_Details
(
Payment_Id int identity(10001,5),
Payment_User_Id int,
Payment_Event_Id int,
Payment_Promo_Id int,
Payment_Amount Money not null
constraint PK_Payment_Details primary key(Payment_Id)
constraint FK_Payment_Details
           foreign key (Payment_User_Id) references User_Details(User_Id),
           foreign key (Payment_Event_Id) references Events_Details(Event_ID),
		   foreign key (Payment_Promo_Id) references Promo_Codes(Promo_Id)
)



select * from [dbo].[Payment_Details]
select * from [dbo].[User_Details]
select * from [dbo].[Events_Details]
select * from [dbo].[Booking_Details]
select * from [dbo].[Promo_Codes]
select * from [dbo].[Ticket_Category]
