#1). Add a new user to db, email, firstName, lastName, password, 
insert into users (FirstName,LastName,LoginID,userPassword,EmailAddress)
values('bob','rob','10102','121321312','acb'); #use own variables instead of these sample values


#2). Add a new foodProduct with accompanying tables of information, predefined filters, ingredients table, ectara, 
#foodfilter
insert into foodfilter (FoodName, GlutenFree, DairyFree, NutFree, Vegan, Pescatarian)
values ('chicken pot pie', 0, 1, 1, 0, 0); #use own variables instead of these sample values

#ingredients table
insert into ingredients (foodName, ingredient)
values ('chicken alfredo', 'chicken'); #use own variables instead of these sample values


#3). Query the database for every food ingredient of particular product 
select ingredient from ingredients where foodName='chicken alfredo'; #use own variables instead of these sample values


#4). query the database for an email and encrypted password.
select EmailAddress, userpassword from users where UserID=1; #use own variables instead of these sample values


#5). Query the database for a food product and its predefined filters
select FoodName, GlutenFree, DairyFree, NutFree, Vegan, Pescatarian from foodfilter where FoodName='chicken pot pie'; #use own variables instead of these sample values


#6 query to make user history upon search
insert into userhistory (UserID, FoodID)
values (1,1); #use own variables instead of these sample values, in this case instead of using the 1 and 1 would need to get the ascertaining values first


#7 get userid and food id
select UserID from users where EmailAddress='acb'; #use own variables instead of these sample values
select FoodID from foodfilter where FoodName='chicken pot pie'; #use own variables instead of these sample values


#8 get all user history
select OrderID, UserID, FoodID from userhistory where UserID=1; #use own variables instead of these sample values
