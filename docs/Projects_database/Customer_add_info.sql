alter proc addcustm @cid char(9),@fn varchar(40),@ln varchar(40),@cph int,@des varchar(80),@emp char(9),@quant int,@tot decimal(9,2),@pay decimal(9,2),@rest decimal(9,2)
as begin

insert into customer values(@cid,@fn,@ln,@cph,@des,getdate(),@emp,@quant,@tot,@pay,@rest);

end
