alter proc updateitems @itid char(9),@itname varchar(40),@ittype varchar(40),@quant int,@quant2 int,@ppi decimal(9,2),@ppp decimal(9,2),@des varchar(40),@itedate varchar(40),@snum char(9)
as begin

update items set it_name=@itname,it_type=@ittype,quantity_p_p=@quant,quantity_p_i=@quant2,price_p_i=@ppi,price_p_p=@ppp,des=@des,it_edate=@itedate,st_num=@snum
where it_id=@itid


end
