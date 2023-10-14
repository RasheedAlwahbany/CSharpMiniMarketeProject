alter proc updatestored @stid char(9),@mid char(9),@des varchar(40),@address varchar(50)
as begin
update stored set manager_id=@mid,des=@des,address=@address
where st_id=@stid;


end