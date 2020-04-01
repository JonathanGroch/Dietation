drop DATABASE if exists Dietation;
CREATE DATABASE Dietation;

use Dietation;


create table if not exists Users (
	UserID int not null auto_increment,
    FirstName varchar(255) not null,
    LastName varchar(255),
    AuthenticationMethod varchar(255),
    LoginID varchar(255),
    EmailAddress varchar(255) not null,
    Primary key (UserID)
);


create table if not exists FoodFilter (
	FoodID int not null auto_increment,
    FoodName varchar(255) not null,
    GlutenFree int not null,
    DairyFree int not null,
    NutFree int not null,
    Vegan int not null,
    Pescatarian int not null,
    Primary key (FoodID)
);
    

create table if not exists UserHistory (
	OrderID int not null auto_increment,
	UserID int not null,
    FoodID int not null,
    
    
    Primary key (OrderID),
    foreign key(UserID)
		references Users(UserID),
	foreign key(FoodID)
		references Foodfilter(FoodID)
);
    



