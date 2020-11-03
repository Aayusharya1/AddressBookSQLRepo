

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