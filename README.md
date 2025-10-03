# SHOP API
## Table of Contents
- [About](#about)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Installation](#installation)
- [Downloading project](#downloading-project)
- [Launching](#launching)
- [Database Testing](#database-testing)
- [Overall Testing](#overall-testing)
## About
This SHOP API is being developed as a task. The API is designed like a small web shop (front-end + back-end) with very basic functionality: a login/register system and adding products to a cart. 
Additionally, a few extra methods have been created for adding a list of products to facilitate better testing.
## Features
- Register/Login/Logout
- See product list with infinite scroll
- Add item to Cart
  - Increase/decrease items
## Tech Stack
| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8.0 | Web API Framework |
| React 19.1.1 | Front-End Framework |
| C# 12 | Programming language |
| Swagger | API documentation |
| MySql | Database |
| Docker | Components containerization |

## Installation
1. Whole project is containerized and created using containers so firstly you need to install docker engine:
Link: https://docs.docker.com/engine/install/

## Downloading project
For project to launch firstly need to download project or clone it from repository.
#### 1. Download
- Go to this repository: https://github.com/arnoldasstrukcinskas/Shop
- Then press green button Code and and Download Zip.
- Unpack zip file
- Move to [Launching](#launching)
#### 2. Clone(If you have git)
- Open Terminal and go to directory you want to clone project(add your own directory)
  ```bash
  cd D:\example
  ```
- In terminal use this command:
  ```bash
  git clone https://github.com/arnoldasstrukcinskas/Shop.git
  ```
- Move to [Launching](#launching)
  
## Launching
#### 1. If you do not have .NET tools pacakge you have to install or update it(for migrations):
##### Install (Use in any directory):
```bash
dotnet tool install --global dotnet-ef
```
##### Update: (Use in any directory)
```bash
dotnet tool update --global dotnet-ef
```
#### 2. Go to project directory(this is example directory)
```bash
cd "D:\Downloads\OrderManagement_V2"
```
#### 3. Build project(with logs)
```bash
docker-compose build
```
#### 4. Launch project(with logs)
```bash
docker-compose up
```
#### 5. Launch project(without logs) -> OPTIONAL
```bash
docker-compose up -d
```
#### 6. Stop project(without logs)
```bash
ctrl + c
```

#### EXTRA! Migrations are created. (In case u will need to create migrations of database)
##### In main directory of project:
```bash
dotnet ef migrations add InitialCreate --project OrderManagement.DATA --startup-project OrderManagement.API
```
##### Auto-migrations are used but if needed to update manually:
```bash
dotnet ef database update --project OrderManagement.DATA --startup-project OrderManagement.API
```

## Database Testing
(How to connect for testing via cmd)
#### 1. Open terminal and chech container ID
```bash
docker ps
```
#### 2. Connect to database(Enter conainer ID)
```bash
docker exec -it shopDB mysql -u root -p
```
#### 3. Chech if database exists
```bash
SHOW DATABASES;
```
#### 4. Enter Database
```bash
USE shopdb;
```

## Overall Testing
(How to connect for testing via front-end)
#### 1. Open terminal and chech container ID
```bash
Go to: http://localhost:5042/login or http://localhost:5042/Register
(But there is craeted accounts for testing)
```
#### 2. Connect to database(Enter conainer ID)
```bash
Enter:
  username: user
  password: user
  username: example
  password: example
```
#### 3. Last bot not least
```bash
HAVE FUN!
```
