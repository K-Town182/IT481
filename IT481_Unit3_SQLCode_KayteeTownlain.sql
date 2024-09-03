use Northwind;

create role SalesRole;
create role HRRole;
create role CEORole;

grant select on Customers to SalesRole;
grant select on Orders to SalesRole;
grant select on Employees to HRRole;
grant select on Customers to CEORole;
grant select on Orders to CEORole;
grant select on Employees to CEORole;

create login User_CEO with password = 'passw0rd1';
create login User_HR with password = 'passw0rd1';
create login User_Sales with password = 'passw0rd1';

create user User_CEO for login User_CEO;
create user User_Hr for login User_HR;
create user User_Sales for login User_Sales;

alter role CEORole add member User_CEO;
alter role HRRole add member User_HR;
alter role SalesRole add member User_Sales;



