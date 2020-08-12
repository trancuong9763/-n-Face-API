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
create table LopHoc
(		
	Ma_Lop nvarchar(15),
	TrangThai bit,
)


insert into ThongTinSV values('0306171182','Quan','CDTH17','0','0',0)
insert into ThongTinSV values('0306171117','Cuong','CDTH17','0','0',0)

