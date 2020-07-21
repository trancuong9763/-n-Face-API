create database DiemDanh

use DiemDanh

create table ThongTinSV
(	
	STT_SV			int identity(1,1),
	Ma_SV			char(10) primary key,
	Ten_SV			nvarchar(100),
	MaLop	varchar(15),	
)
create table QuanTriVien
(		
	Ten_QTV			nvarchar(100) primary key,
	Mat_Khau	varchar(15),		
)

insert into QuanTriVien values('admin','123456')
insert into ThongTinSV values('0306171182','Quan','CDTH17')
insert into ThongTinSV values('0306171117','Cuong','CDTH17')

create table XuatBangDiemDanh
(		
	Ma_SV			char(10) primary key,
	Ten_SV			nvarchar(100),
	MaLop	varchar(15),
	SoNgayHoc	int,
	SoNgayVang int,	
)	
GO
create proc USP_QuanTriVien
@tenQTV nvarchar(50),@matKhau nvarchar(50)
as
begin
 select * from QuanTriVien where Ten_QTV=@tenQTV and Mat_Khau = @matKhau
end
go