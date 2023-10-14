alter proc addstored @stid char(9),@mid char(9),@des varchar(40),@address varchar(50)
as begin
insert into stored values(@stid,@mid,@address,@des,getdate());



end