
--employee table

create table employee(
emp_id char(9) primary key,
fname varchar(40),
lname varchar(40),
passwd varchar(60) unique null,
des varchar(80),
j_type varchar(40),
salary decimal(9,2),
bouns decimal(9,2),
minus decimal(9,2),
phone int,
Address varchar(40),
h_date date,
ismanager char(1),
m_id char(9),
uname varchar(40),

--alter table employee add m_id char(9),foreign key(m_id) references employee(emp_id)
)

--customers table

create table customer(
c_id char(9) primary key,
fname varchar(40),
lname varchar(40),
c_phone int,
des varchar(80),
c_date date,
emp_id char(9),--foreign key
quantity int,
total decimal(9,2),
pay decimal(9,2),
rest decimal(9,2),
foreign key(emp_id) references employee(emp_id)
)



--items table
create table items(
it_id char(9) primary key,
it_name varchar(40),
it_type varchar(40),
quantity_p_p int,
quantity_p_i int,
price_p_i decimal(9,2),
price_p_p decimal(9,2),
des varchar(40),
it_edate date,
st_date date,
st_num char(9),
foreign key(st_num) references stored(st_id)
)

--stored table

create table stored(
st_id char(9) primary key,
manager_id char(9) ,--froian key
address varchar(50),
des varchar(40),
st_date date,
foreign key(manager_id) references employee(emp_id)
)


--salling table

create table saled(
s_id char(9) primary key ,
emp_id char(9) ,--foriegn key,

it_id char(9) ,--foriegn key
quantity int,
price_p_i decimal(9,2),
total decimal(9,2),
pay decimal(9,2),
rest decimal(9,2),
des varchar(80),
s_date date,
foreign key(emp_id) references employee(emp_id),
foreign key(it_id) references items(it_id),
)
--invoice table


create table invoice(
in_id char(9) primary key ,
emp_id char(9) ,--foriegn key,
C_fn varchar(40),
C_lname varchar(40),
c_phone char(9),
it_id char(9) ,--foriegn key
it_name varchar(40),
it_type varchar(40),
quantity int,
price_p_i decimal(9,2),
total decimal(9,2),
pay decimal(9,2),
rest decimal(9,2),
des varchar(80),
in_date date,
it_in_packet char(1),
foreign key(emp_id) references employee(emp_id),
foreign key(it_id) references items(it_id)
)
 
