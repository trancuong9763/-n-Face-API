create database DiemDanh
use DiemDanh

create table ThongTinSV
(	
	
	Ma_SV			char(10) primary key,
	Ten_SV			nvarchar(100),
	MaLop	varchar(15),
	SoNgayHoc	int,
	SoNgayVang int,	
	TrangThai bit DEFAULT 0 NOT NULL,	
)
create table QuanTriVien
(		
	Ten_QTV			varchar(100) primary key,
	Mat_Khau	varchar(50),
	Ten_GV nvarchar(100),
	SDT varchar(10),
	Email varchar(50),
	DiaChi nvarchar(100),
			
)

insert into QuanTriVien values('admin','e10adc3949ba59abbe56e057f20f883e','admin','0','admin@gmail.com','admin')
insert into ThongTinSV values('0306171182','Quan','CDTH17','0','0',0)
insert into ThongTinSV values('0306171117','Cuong','CDTH17','0','0',0)

