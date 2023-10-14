alter proc addinvoice @inid char(9),@empid char(9),@cfn varchar(40),@cln varchar(40),@cph char(9),@itid char(40),@itname varchar(40),@ittype varchar(40),@quant int 
,@ppi decimal(9,2),@tot decimal(9,2),@pay decimal(9,2),@rest decimal(9,2),@des varchar(80),@itnp char(1)
as begin
declare @inv char(9);
select @inv=in_id from invoice where in_id=@inid;
insert into invoice values(@inid ,@empid ,@cfn,@cln,@cph,@itid ,@itname,@ittype,@quant ,@ppi,@tot,@pay,@rest,@des,getdate(),@itnp);


--add to history
declare @sid char(9);
select @sid=s_id from saled where s_id=@inid
if(@inv!='')
print 'not add'
else
begin
if(@sid!='')
begin
delete from saled where s_id=@inid;
insert into saled values(@inid,@empid,@itid,@quant,@ppi,@tot,@pay,@rest,@des,getdate());
end
else
insert into saled values(@inid,@empid,@itid,@quant,@ppi,@tot,@pay,@rest,@des,getdate());
end





--calculate the items
declare @qup int,@qui int,@qui2 int
select @qup=quantity_p_p,@qui=quantity_p_i from items where it_id=@itid;
if(@itnp !='1') 
begin
while(@quant>@qui)
begin
set @qui=@qui-@quant;
update items set quantity_p_p=@qup-1 where it_id=@itid;
end
end
else
begin
update items set quantity_p_p=@qup-@quant where it_id=@itid;
end
end
--insert into invoice values('1','1' ,'hg','gh','909','1' ,'rf','go',2 ,10,20,20,0,'hello',getdate(),'1');

