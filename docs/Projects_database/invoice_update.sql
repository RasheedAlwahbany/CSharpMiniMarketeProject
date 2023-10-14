create proc updateinvoice @inid char(9),@empid char(9),@cfn varchar(40),@cln varchar(40),@cph char(9),@itid char(40),@itname varchar(40),@ittype varchar(40),@quant int 
,@ppi decimal(9,2),@tot decimal(9,2),@pay decimal(9,2),@rest decimal(9,2),@des varchar(80),@itnp char(1)
as begin

update invoice set  emp_id=@empid ,c_fn=@cfn,c_lname=@cln,c_phone=@cph,it_id=@itid ,it_name=@itname,it_type=@ittype,quantity=@quant ,price_p_i=@ppi,total=@tot,pay=@pay,rest=@rest,des=@des,it_in_packet=@itnp
where in_id=@inid

end
--insert into invoice values('1','1' ,'hg','gh','909','1' ,'rf','go',2 ,10,20,20,0,'hello',getdate(),'1');

