CREATE DATABASE ShopDB;
GO

USE ShopDB;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('User', 'Admin')) NOT NULL
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(10, 2) NOT NULL,
    ImageURL NVARCHAR(2083) NOT NULL -- ”величено дл€ хранени€ ссылок на изображени€ из интернета
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10, 2) NOT NULL
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) ON DELETE CASCADE,
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- ƒанные дл€ тестировани€
INSERT INTO Users (FullName, Email, PasswordHash, Role)
VALUES ('Admin User', 'admin@shop.com', '123', 'Admin'),
       ('Test User', 'user@shop.com', '123', 'User');

INSERT INTO Products (ProductName, Description, Price, ImageURL)
VALUES ('Laptop', 'Gaming laptop with powerful GPU', 1500.00, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTKjCMToU0ORpSplDJyxyqAKzawvBRkUGulJA&s'),
       ('Mouse', 'Wireless gaming mouse', 50.00, 'https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQmGG1ZDJYE8f-pk9_ViisTmuS8cTu-1gkYKae_feZiRSYdxFAggCNpJTr9Sz5VVx5u_XOBQJA2YfM3gfOQUhq8PtarNDaQFOw_Lz2SUDkFWO6nWFXyvWS4ENc'),
       ('Keyboard', 'Mechanical keyboard with RGB', 100.00, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRRrg64ntzePy1UcxyGBRwl8wQln0JmS46Urw&s');
