CREATE TABLE users
(
  id int PRIMARY KEY IDENTITY(1,1),
  username VARCHAR(50) NULL,
  password VARCHAR(50) NULL,
  role VARCHAR(50) NULL,
  status VARCHAR(50) NULL,
  date DATE NULL,
)

SELECT * FROM users

INSERT INTO  users(username, password, role, status, date) VALUES('admin', 'admin123', 'Admin', 'Active', '2024-11-01')

CREATE TABLE Categories(
id  INT PRIMARY KEY IDENTITY (1,1),
Category VARCHAR(MAX) NULL,
date DATE NULL
)

SELECT * FROM Categories
