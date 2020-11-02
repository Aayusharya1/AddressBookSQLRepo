

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




