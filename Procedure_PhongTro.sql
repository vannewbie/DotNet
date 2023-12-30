ALTER procedure [dbo].[ThemLoaiPhong]
  @tenloaiphong varchar(20),@dongia int
 as
 begin
   insert into tbLoaiPhong values(@tenloaiphong,@dongia)
   if @@Rowcount >1 return 1
   else return 0;
   end

    ALTER procedure [dbo].[CapNhatKhachHang]     
 @Id int,
 @Ten varchar(20),@CCCD varchar(15),@SDT varchar(12),@QueQuan varchar(15),@gioitinh varchar(10)
as
begin
 update tbKhachHang
 set Ten = @Ten,
     CMND = @CCCD,
	 SDT = @SDT,
	 QueQuan = @QueQuan,
	 gioitinh = @gioitinh
	 where ID = @Id
end
ALTER procedure [dbo].[CapNhatLoaiPhong]
  @id int,
  @tenloaiphong varchar(20),
  @dongia int
  as
  begin
     update tbLoaiPhong
	 set TenLoaiPhong = @tenloaiphong,
	     DonGia = @dongia
		 where ID = @id;
		 if @@ROWCOUNT > 0 return 1;
		 else return 0;
  end
   ALTER procedure [dbo].[LoadDsPhong]
 @timkiem nvarchar(20)
 as
  select p.Id,lp.TenLoaiPhong,
  p.TenPhong,lp.DonGia,p.CosoVatChat , 
  case 
     when p.TrangThai = 1 then N'Hoạt động'
	 else N'Không hoạt động'
  end as  TrangThai
 
 from tbPhongTro p
	 inner join tbLoaiPhong lp on p.IDLoaiPhong = lp.ID 
	 where DaXoa is null


ALTER procedure [dbo].[ThemKhachHang]
 @Ten varchar(20),@CCCD varchar(15),@SDT varchar(12),@QueQuan varchar(15),@gioitinh varchar(10)
 as 
 begin
   insert into tbKhachHang values(@Ten,@CCCD,@SDT,@QueQuan,@gioitinh)
   if @@ROWCOUNT >0 return 1;
   else return 0;
 end


 ALTER procedure [dbo].[ThemPhong]
@idLoaiPhong int,@tenphong varchar(50),@trangthai int,@cosovatchar nvarchar(50)
as
 insert into tbPhongTro values(@tenphong,@idLoaiPhong,@trangthai,@cosovatchar,null)


 ALTER procedure [dbo].[XoaKhachHang]
    @id int
 as
 begin
   delete from tbKhachHang where ID = @id;
 
   end


ALTER procedure [dbo].[XoaLoaiPhong]
    @id int
 as
 begin
   delete from tbLoaiPhong where ID = @id;
 
   end