

--Creating AddressBook database

create database Address_Book_Service



--Using AddressBook Service database
use Address_Book_Service

--Creating Addressbook table
create table AddressBook
(
FirstName varchar(20) not null,
LastName varchar (20) not null,
Address varchar(50) not null,
City varchar(15) not null,
State varchar(15) not null,
Zipcode varchar(10) not null,
Phone varchar(15) not null,
Email varchar(20) not null 
);

select * from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Addressbook'

--Inserting contacts into AddressBook table
insert into AddressBook values
('Aayush','Arya','123,xyz street','New Delhi','Delhi', '1100001','+91 9999999999', 'aayush@gmail.com'),
('Aayu','Arya','1234,xwewyz street','New Delhi','Delhi', '1101111','+91 9988899999', 'aayu@gmail.com'),
('Aayus','Arya','12345,xyz street','New Delhi','Delhi', '1100009','+91 9999999888', 'aayus@gmail.com');

select * from AddressBook

-- Editing the phone no. using name

update AddressBook set Phone = '+91 8888888888' where FirstName = 'Aayush' and LastName ='Arya';

--Deleting contact using name
delete AddressBook where FirstName = 'Aayush' and LastName ='Arya';

--Retrieve contact using name

select * from AddressBook where City = 'New Delhi'

insert into AddressBook values
('Aayush1','Arya','123,xyz street','Bangalore','Karnataka', '1100001','+91 9999999991', 'aayush@gmail.com'),
('Aayu1','Arya','1234,xwewyz street','Pune','Maharashtra', '1101111','+91 9988899991', 'aayu@gmail.com'),
('Aayus1','Arya','12345,xyz street','Mumbai','Maharashtra', '1100009','+91 9999999881', 'aayus@gmail.com');



select COUNT(City), City, State from AddressBook
group by State, City;

--Retrieve contacts sorted alphabetically by first name for a given city
select * from AddressBook
where City = 'New Delhi'
order by FirstName;

--UC9 Adding columns Address Book Name and Contact Type To Address Book Table
alter table AddressBook
add bookname varchar(15);

alter table AddressBook
add contact_type varchar(15);

update AddressBook set bookname = 'Capgemini' 
where FirstName in ('Aayush1','Aayu','Aayus1')

update AddressBook set bookname = 'Bridgelabz' 
where FirstName in ('Aayus','Aayu1')


update AddressBook set contact_type = 'family' 
where FirstName in ('Aayus','Aayu1')

update AddressBook set contact_type = 'friends' 
where FirstName in ('Aayu','Aayus1')

update AddressBook set contact_type = 'profession' 
where FirstName in ('Aayush1')

--Counting by type
select count(contact_type) as No_of_Contact_Type,contact_type from AddressBook
group by contact_type


insert into AddressBook values
('Aayush1','Arya','123,xyz street','Bangalore','Karnataka', '1100001','+91 9999999991', 'aayush@gmail.com','Capgemini', 'family')

--deleting the last added row and contact type column in order to restructure the table and add another separate table for contact type
delete AddressBook where FirstName = 'Aayush1' and contact_type = 'family'
alter table AddressBook
drop column contact_type 

select * from AddressBook

--setting FirstName as primary key
alter table AddressBook
add primary key (FirstName)

--Creating another table ContactType

Create table ContactType1
(
FirstName varchar(20) not null foreign key references AddressBook(FirstName),
Contact_type varchar(20)
)

insert into ContactType1 values
('Aayu','family'),
('Aayu','profession'),
('Aayu1','friend'),
('Aayus','family'),
('Aayush1','friend')

select * from ContactType1

select * from AddressBook inner join ContactType1 on AddressBook.FirstName =ContactType1.FirstName

alter table AddressBook
add DateAdded datetime;

update AddressBook set DateAdded = '2020-05-19' 
where FirstName in ('Aayush1')

update AddressBook set DateAdded = '2019-05-19' 
where FirstName in ('Aayu')

update AddressBook set DateAdded = '2020-08-09' 
where FirstName in ('Aayu1')

update AddressBook set DateAdded = '2020-05-19' 
where FirstName in ('Aayus1')

update AddressBook set DateAdded = '2020-01-19' 
where FirstName in ('Aayus')

alter table AddressBook
drop column bookname

create procedure SpAddContactDetails
(
@FirstName varchar(255),
@LastName varchar(255),
@Phone varchar(255),
@Email varchar(255),
@DateAdded DateTime,
@Contact_type varchar(255),
@Address varchar(255),
@City varchar(255),
@State varchar(255),
@Zipcode varchar(255)
)
as
begin
insert into AddressBook values
(
@FirstName,@LastName, @Address, @City, @State, @Zipcode, @Phone, @Email, @DateAdded
);
insert into ContactType1 values
(
@FirstName, @Contact_type
)
end