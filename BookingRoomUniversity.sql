CREATE DATABASE BookingRoomUniversity 
GO
drop database BookingRoomUniversity
USE master
USE BookingRoomUniversity 
GO

-- 📌 Campus (Cơ sở)
CREATE TABLE Campuses (
    CampusID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL
);

-- 📌 Department (Khoa/Bộ môn)
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    CampusID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    Status INT DEFAULT 1, -- 1: Active, 0: Inactive
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL,
    FOREIGN KEY (CampusID) REFERENCES Campuses(CampusID)
);

-- 📌 Room (Phòng họp)
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    CampusID INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Capacity INT NOT NULL, -- Số lượng người tối đa
    Description NVARCHAR(255) NULL,
    Status INT DEFAULT 1, -- 1: Còn trống, 0: Đã đặt
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL,
    FOREIGN KEY (CampusID) REFERENCES Campuses(CampusID)
);

CREATE TABLE Roles (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL,
);


-- 📌 User (Người dùng - Giáo viên, Admin)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    DepartmentID INT NOT NULL,
    RoleID  INT NOT NULL, -- 1: Giáo viên, 2: Admin
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID),
    FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

-- 📌 Bảng trung gian User_Room (Xử lý quan hệ N-N giữa User và Room)
CREATE TABLE User_Rooms (
    UserID INT NOT NULL,
    RoomID INT NOT NULL,
    PRIMARY KEY (UserID, RoomID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

-- 📌 Booking (Lịch đặt phòng)
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL,
    RoomID INT NOT NULL,
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Description NVARCHAR(255) NULL,
    Status INT DEFAULT 1, -- 1: Chờ xác nhận, 2: Đã xác nhận, 3: Hoàn thành, 0: Hủy
    CreatedTime DATETIME DEFAULT GETDATE(),
    UpdatedTime DATETIME NULL,
    DeleteTime DATETIME NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);
