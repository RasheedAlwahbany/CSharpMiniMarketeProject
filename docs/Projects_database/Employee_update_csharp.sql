create proc updateemployee @empid char(9),@fn varchar(40),@ln varchar(40),@pass varchar(40),@des varchar(80),@jtype varchar(40),@salary decimal(9,2),@bouns decimal(9,2),@minus decimal(9,2),@phone int,@address varchar(40),@ism char(1),@mid char(9),@un varchar(40)
as begin

update employee set fname=@fn,lname=@ln,passwd=@pass,des=@des,j_type=@jtype,salary=@salary,bouns=@bouns,minus=@minus,phone=@phone,Address=@address,ismanager=@ism,m_id=@mid,uname=@un
where emp_id=@empid

end
--select * from  employee 
