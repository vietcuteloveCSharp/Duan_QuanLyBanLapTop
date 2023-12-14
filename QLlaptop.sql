CREATE DATABASE Laptop
go
use Laptop

 create table hang(
  id_hang int identity(1,1) primary key,
  tenhang nvarchar(30) not null,
  trangthai nvarchar(30)
  )

 Create table Pin(
	id_pin int identity(1,1) primary key,
	tenpin nvarchar(30) not null ,
	dungluong int not null ,
	loaipin nvarchar(20)not null,
	thoigiansd int not null,
	trangthai nvarchar(20) not null
	)
create  table Ram(
	Id_ram int identity(1,1) primary key,
	tenram nvarchar(20) not null,
	bus int not null ,
	trangthai nvarchar(20)not null
)
create table Carddohoa(
	Id_carddohoa int identity(1,1) primary key,
	tencard nvarchar(30)not null,
	dungluong int not null,
	trangthai nvarchar(20) not null
)
create table ocung(
	Id_ocung int identity(1,1) primary key,
	dungluong int not null,
	tenocung nvarchar(30) not null,
	loai nvarchar(20)not null
)
create table chip(
	Id_chip int identity(1,1) primary key,
	tenchip nvarchar(30) not null ,
	trangthai nvarchar(20) not null
)

create table laptop(
id_lt int identity(1,1) primary key,
tenlaptop nvarchar(30) not null ,
cannang float not null ,
mota nvarchar(100) not null ,
trangthai nvarchar(20) not null,
idhang int
CONSTRAINT FK_laptop_hang FOREIGN KEY (idhang) REFERENCES hang(id_hang)
)

create table hinhanh(
Id_hinhanh int identity(1,1) primary key,
Src NVARCHAR(MAX) not null,
nguoitao  NVARCHAR(30) not null ,
ngaytao date not null,
idlaptop int,
CONSTRAINT fk_hinhanh_laptop FOREIGN KEY (idlaptop) REFERENCES laptop(id_lt)
)


create table phanquyen(
id_phanquyen int identity(1,1) primary key,
tenquyen nvarchar(30) not null ,
quyen INT CONSTRAINT check_quyen CHECK (quyen >= 0 AND quyen <= 10)
) 


create table khachhang(
id_khachhang int identity(1,1) primary key,
tenkh nvarchar(50) not null,
diachi nvarchar(50) not null ,
dienthoai varchar(10) CONSTRAINT CHK_dienthoai CHECK (dienthoai NOT LIKE '%[^0-9]%'),
email varchar(50) not null
)

create table taikhoan(
id_taikhoan int identity(1,1) primary key,
username nvarchar(30) not null ,
password varchar(30) not null,
hoten nvarchar(50)not null ,
diachi nvarchar(50)not null ,
dienthoai varchar(10) CONSTRAINT CHK_dienthoainv CHECK (dienthoai NOT LIKE '%[^0-9]%'),
email varchar(50) not null ,
hinhanh nvarchar(max) not null,
ngaysinh datetime not null,
id_phanquyen int,
TrangThai bit
 CONSTRAINT FK_taikhoan_phanquyen FOREIGN KEY (id_phanquyen) REFERENCES phanquyen(id_phanquyen)
)


create table hoadon(
id_hoadon int identity(1,1) primary key,
chuthich nvarchar(100) not null,
ngaymua datetime not null ,
tongtien decimal not null ,
trangthai bit not null ,
id_khachhang int ,
id_taikhoan int
 CONSTRAINT FK_hoadon_khachhang FOREIGN KEY (id_khachhang) REFERENCES khachhang(id_khachhang),
 CONSTRAINT FK_hoadon_taikhoan FOREIGN KEY (Id_taikhoan) REFERENCES taikhoan(Id_taikhoan)
)



create table hoadonct(
id_hdct int identity(1,1) primary key,
imel varchar(15) not null,
id_hoadon int ,
gia decimal not null 
 CONSTRAINT FK_hoadonct_hoadon FOREIGN KEY (id_hoadon) REFERENCES hoadon(id_hoadon),
 CONSTRAINT FK_hoadonct_ltct FOREIGN KEY (imel) REFERENCES laptopchitiet(imel)

)
create table laptopchitiet(
 imel  varchar(15) PRIMARY KEY,
 gianhap decimal not null,
 Id_pin int ,
 Id_chip int ,
 id_hang int,
 Id_ram int ,
 Id_carddohoa int ,
 Id_ocung int ,
 Id_laptop int,
 TrangThai bit not null
 CONSTRAINT FK_laptopchitiet_Pin FOREIGN KEY (Id_pin) REFERENCES Pin(Id_pin),
  CONSTRAINT FK_laptopchitiet_chip FOREIGN KEY (Id_chip) REFERENCES chip(Id_chip),
 CONSTRAINT FK_laptopchitiet_ram FOREIGN KEY (Id_ram) REFERENCES ram(Id_ram),
  CONSTRAINT FK_laptopchitiet_carddohoa FOREIGN KEY (Id_carddohoa) REFERENCES carddohoa(Id_carddohoa),
  CONSTRAINT FK_laptopchitiet_ocung FOREIGN KEY (Id_ocung) REFERENCES ocung(Id_ocung),
  CONSTRAINT FK_laptopchitiet_laptop FOREIGN KEY (id_laptop) REFERENCES laptop(id_lt)
  )

create table nhaphang(
id_nhaphang int identity(1,1) primary key,
ngaynhap  date not null,
nhacungcap nvarchar(50) not null,
ghichu nvarchar(50)not null,
soluongnhhap int not null,
id_taikhoan int,
CONSTRAINT FK_Nhaphang_taikhoan FOREIGN KEY (id_taikhoan) REFERENCES taikhoan(id_taikhoan)
)

create table Nhaphangchitiet(
id_nhct int identity(1,1) primary key,
imel varchar(15) not null,
gianhap decimal not null,
id_nhaphang int,
 CONSTRAINT FK_NHCT_ltct FOREIGN KEY (imel) REFERE`NCES laptopchitiet(imel),
CONSTRAINT FK_NHCT_nhaphang FOREIGN KEY (id_nhaphang) REFERENCES nhaphang(id_nhaphang)
)


