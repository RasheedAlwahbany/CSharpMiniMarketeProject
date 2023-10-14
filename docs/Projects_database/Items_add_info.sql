alter proc additems @itid char(9),@itname varchar(40),@ittype varchar(40),@quant int,@quant2 int,@ppi decimal(9,2),@ppp decimal(9,2),@des varchar(40),@itedate varchar(40),@snum char(9)
as begin

insert into items values(@itid,@itname,@ittype,@quant,@quant2,@ppi,@ppp,@des,@itedate,getdate(),@snum);


end