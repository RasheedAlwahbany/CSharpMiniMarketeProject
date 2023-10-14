create proc addemployee @empid char(9),@fn varchar(40),@ln varchar(40),@pass varchar(40),@des varchar(80),@jtype varchar(40),@salary decimal(9,2),@bouns decimal(9,2),@minus decimal(9,2),@phone int,@address varchar(40),@ism char(1),@mid char(9),@un varchar(40)
as begin

insert into employee values(@empid,@fn,@ln,@pass,@des,@jtype,@salary,@bouns,@minus,@phone,@address,getdate(),@ism,@mid,@un);

end
--select * from  employee 
--insert into employee values('1','rasheed','adnan','hr','good','manager',100000,0,0,765564,'sanaa',getdate(),'1','1','HR');
