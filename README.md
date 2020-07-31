# Hair Salon Webpage

#### Latest version date 7/31/2020

#### By Deryck Jackson

## Description

A website for tracking clients by their stylist

## Specifications

| Spec | Input | Output |
| :--- | :---: | ---: |
| User will be able to add a stylist with a name and details | Name: Jenny, Details: Works mornings | Jenny, Works mornings |
| User will be able to add a client with a Name and associate a stylist with them | Client: Joe, Stylist: Jenny | Joe, Jenny |
| User will be able to filter clients by Stylist | Stylist: Jenny | Client: Joe |
| User will not be able to add a Client before adding a stylist | Client: Joe, Stylist: None | Oops, You need to add a Stylist first! |

## Setup and Installation

* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* Install MySQL and set the system path, more information on how to do that can be found here: https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql
* Import the deryck_jackson.sql file into MYSQL Workbench under "Server -> Data Import -> Import from Self-Contained File

**OR**

* Run MySQL by entering `mysql -uroot -pepicodus` in the terminal
* Enter the following commands to create the necessary database and tables:
```
DROP DATABASE IF EXISTS `deryck_jackson`;
CREATE DATABASE `deryck_jackson`;

USE `FirstName_LastName`;

CREATE TABLE `clients` (
  `clientId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `stylistId` int DEFAULT '0',
  PRIMARY KEY (`clientId`)
);

CREATE TABLE `stylists` (
  `stylistId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Details` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`stylistId`)
);
```
* Clone the GitHub repository by running `git clone https://github.com/pagrimm/BestRestaurants.Solution.git` in the terminal
* Navigate to the newly created `BestRestaurants.Solution` folder
* Navigate to the `BestRestaurants` subfolder and run `dotnet restore`
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser

## Tech used

* C#
* ASP.NET MVC
* Entity Framework Core
* MYSQL

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

Copyright (c) 2020 Deryck Jackson