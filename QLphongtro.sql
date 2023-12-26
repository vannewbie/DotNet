CREATE DATABASE QLPHONGTRO;

-- Lô 1: Tạo database và sử dụng nó

USE QLPHONGTRO;

-- Lô 2: Tạo bảng LoaiPhong
CREATE TABLE LoaiPhong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiPhong NVARCHAR(255) NOT NULL,
    DonGia INT NOT NULL
);

-- Lô 3: Tạo bảng Phong
CREATE TABLE Phong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    IDLoaiPhong INT FOREIGN KEY REFERENCES LoaiPhong(ID),
    TenPhong NVARCHAR(255) NOT NULL,
    TrangThai BIT NOT NULL
);

-- Lô 4: Tạo bảng KhachHang
CREATE TABLE KhachHang (
    ID INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(255) NOT NULL,
    SDT NVARCHAR(20),
    DiaChi NVARCHAR(255)
);

-- Lô 5: Tạo bảng ThuePhong
CREATE TABLE ThuePhong (
    ID INT PRIMARY KEY IDENTITY(1,1),
    IDPhong INT FOREIGN KEY REFERENCES Phong(ID),
    IDKhachHang INT FOREIGN KEY REFERENCES KhachHang(ID),
    NgayThue DATETIME NOT NULL,
    NgayTra DATETIME NOT NULL,
    TienDatCoc INT NOT NULL,
    CONSTRAINT CK_ThuePhong CHECK (NgayTra > NgayThue)
);

CREATE PROCEDURE loadDSLoaiPhong
AS
BEGIN
    SELECT * FROM LoaiPhong;
END;
GO

CREATE PROCEDURE loadDSPhong
AS
BEGIN
    SELECT * FROM Phong;
END;
GO

CREATE PROCEDURE loadDSKhachHangGhepHoTen
AS
BEGIN
    SELECT ID, CONCAT(HoTen, ' - ', DiaChi) AS HoTen FROM KhachHang;
END;
GO

CREATE PROCEDURE ThuePhong
    @idphong INT,
    @idKH INT,
    @datCoc INT,
    @ngayThue DATETIME,
    @ngayTra DATETIME
AS
BEGIN
    INSERT INTO ThuePhong (IDPhong, IDKhachHang, NgayThue, NgayTra, TienDatCoc)
    VALUES (@idphong, @idKH, @ngayThue, @ngayTra, @datCoc);
END;
GO

CREATE PROCEDURE loadDSThuePhong
    @tukhoa NVARCHAR(255)
AS
BEGIN
    SELECT ThuePhong.ID, Phong.TenPhong, KhachHang.HoTen, ThuePhong.NgayThue, ThuePhong.NgayTra, ThuePhong.TienDatCoc
    FROM ThuePhong
    INNER JOIN Phong ON ThuePhong.IDPhong = Phong.ID
    INNER JOIN KhachHang ON ThuePhong.IDKhachHang = KhachHang.ID
    WHERE KhachHang.HoTen LIKE '%' + @tukhoa + '%';
END;
GO

CREATE PROCEDURE ThanhToan
    @id INT,
    @soTien INT
AS
BEGIN
    UPDATE ThuePhong
    SET TienDatCoc = TienDatCoc - @soTien
    WHERE ID = @id;
END;
GO

CREATE PROCEDURE loadThongTinHopDongThuePhong
    @id INT
AS
BEGIN
    SELECT KhachHang.HoTen, Phong.TenPhong, Phong.GiaPhong
    FROM ThuePhong
    INNER JOIN Phong ON ThuePhong.IDPhong = Phong.ID
    INNER JOIN KhachHang ON ThuePhong.IDKhachHang = KhachHang.ID
    WHERE ThuePhong.ID = @id;
END;
GO

CREATE PROCEDURE loadDSPhongThue
AS
BEGIN
    SELECT * FROM Phong WHERE TrangThai = 1;
END;
GO

CREATE PROCEDURE sqlDeletePhong
    @idPhong INT
AS
BEGIN
    DELETE FROM Phong WHERE ID = @idPhong;
END;
GO

CREATE PROCEDURE sqlUpdateTrangThaiPhong
    @idPhong INT,
    @trangThai BIT
AS
BEGIN
    UPDATE Phong SET TrangThai = @trangThai WHERE ID = @idPhong;
END;
GO

CREATE PROCEDURE sqlSelectPhong
    @idPhong INT
AS
BEGIN
    SELECT * FROM Phong WHERE ID = @idPhong;
END;
GO

CREATE PROCEDURE themMoiPhong
    @idLoaiPhong INT,
    @tenPhong NVARCHAR(255),
    @trangThai BIT
AS
BEGIN
    INSERT INTO Phong (IDLoaiPhong, TenPhong, TrangThai)
    VALUES (@idLoaiPhong, @tenPhong, @trangThai);
END;
GO

CREATE PROCEDURE sqlUpdatePhong
    @idPhong INT,
    @tenPhong NVARCHAR(255),
    @idLoaiPhong INT,
    @trangThai BIT
AS
BEGIN
    UPDATE Phong
    SET IDLoaiPhong = @idLoaiPhong,
        TenPhong = @tenPhong,
        TrangThai = @trangThai
    WHERE ID = @idPhong;
END;
GO

















