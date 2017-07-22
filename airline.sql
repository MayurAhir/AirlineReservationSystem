create database airline;
use airline;
create table flight(
f_no int primary key,
aircraft varchar(20),
sourc varchar(30),
destination varchar(30),
airline varchar(20),
flighttime datetime,
seats int,
departure time,
arrival time,
travel_hours int
);

create table passenger(
p_id int primary key, 
fname varchar(30),
lname varchar(30),
city varchar(20),
state1 varchar(20),
country varchar(20),
dob date,
passport_no int
);

create table reservation (
r_id int primary key ,
sourc varchar(20),
destination varchar(20),
booking_dt date,
traveldate datetime,
f_no int references flight(f_no),
t_id int references ticket(t_id),
p_id int references passenger(p_id)
);
drop table reservation;

create table ticket(
t_id int primary key,
t_type varchar(20),
price int,
);
create table users(
username varchar(20),
password1 varchar(20)
)
insert into flight values(101,'airbus','mumbai','london','airIndia',GETDATE(),10,CAST(GETDATE() as time),'15:09:02',5);


insert into flight values(102,'airbus-310','delhi','dubai','airIndia',GETDATE(),10,'10:05:03','15:09:02',10);


select * from flight;
insert into passenger values(201,'mayur','ahir','navsari','gujarat','india','1995-03-16',1234445);
insert into passenger values(203,'akshay','ahir','navsari','gujarat','india','1995-03-16',1234445);

insert into ticket values(1,'business',100000);
insert into ticket values(2,'economy',50000);

create table reservation (
r_id int primary key ,
sourc varchar(20),
destination varchar(20),
booking_dt datetime,
traveldate datetime,
f_no int references flight(f_no),
t_id int references ticket(t_id)
);
drop table reservation;

insert into reservation values(1001,'mumbai','london',GETDATE(),'2016-12-12',101,1,201);

