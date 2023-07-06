# DitechBackend
## Backend

Backend was built with c# .net 5
## Features
- Crud (insert, delete, update, show) for City and Seller tables.
- It was used Entity Framework Core like ORM.
- It was used database first.
- For this project, two design patterns were used: Dependency injection, Repository and Unit of Work
- Docker is configured, but you could use IIS Express or others.



## Installation
Run the following scripts in sql server

```sh
CREATE DATABASE DitechPrueba;

CREATE TABLE City (
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Description VARCHAR(255),
); 

CREATE TABLE Seller (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255),
    Last_Name VARCHAR(255),
	Document VARCHAR(255),
    City_id int FOREIGN KEY REFERENCES City(Id)
); 
```


**Free Software, Hell Yeah!**
