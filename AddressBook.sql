

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


