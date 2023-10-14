alter proc updatecustm @cid char(9),@fn varchar(40),@ln varchar(40),@cph int,@des varchar(80),@emp char(9),@quant int,@tot decimal(9,2),@pay decimal(9,2),@rest decimal(9,2)
as begin

update customer set fname=@fn,lname=@ln,c_phone=@cph,des=@des,emp_id=@emp,quantity=@quant,total=@tot,pay=@pay,rest=@rest
where c_id=@cid
end
