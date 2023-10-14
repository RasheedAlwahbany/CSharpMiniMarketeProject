create proc addhistory @sid char(9),@empid char(9),@itid char(9),@qua int,@p_p_i decimal(9,2),@tot decimal(9,2),@pay decimal(9,2),@rest decimal(9,2),@des varchar(80)
as begin

insert into saled values(@sid,@empid,@itid,@qua,@p_p_i,@tot,@pay,@rest,@des,getdate());

end
