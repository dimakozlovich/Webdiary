create table UserSecurity
(
   UserId int primary key identity(1,1) Not Null,
   Password varchar(100),
   Email varchar(50),
   Salt varchar(50), 
   FirstName varchar(50),
   LastName varchar(50),

)