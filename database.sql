--database created
CREATE DATABASE userData;
USE userData;

--table created
CREATE TABLE user_form (
			id INT PRIMARY KEY IDENTITY,
			first_name VARCHAR(30),
			last_name VARCHAR(30) NOT NULL,
			date_of_birth DATE,
			gender VARCHAR(10),
			phone_number VARCHAR(15) NOT NULL,
			email_address VARCHAR(50) UNIQUE NOT NULL,
			address VARCHAR(100),
			city VARCHAR(30),
			state VARCHAR(30),
			user_name VARCHAR(30) UNIQUE NOT NULL,
			password VARCHAR(30) NOT NULL
);

--create procedure for add user data
CREATE PROCEDURE sp_InsertUser(
	@FirstName VARCHAR(30),
    @LastName VARCHAR(30),
    @DateOfBirth DATE,
    @Gender VARCHAR(10),
    @PhoneNumber VARCHAR(15),
    @EmailAddress VARCHAR(50),
    @Address VARCHAR(100),
    @City VARCHAR(30),
    @State VARCHAR(30),
    @UserName VARCHAR(30),
    @Password VARCHAR(50)
)
AS
BEGIN
	INSERT INTO user_form(first_name,last_name,date_of_birth,gender,phone_number,email_address,
						  address,city,state,user_name,password) 
	VALUES(@FirstName,@LastName,@DateOfBirth,@Gender,@PhoneNumber,@EmailAddress,@Address,@City,@State,@UserName,@Password);
END;

--create procedure for get all user
CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
	SELECT * FROM user_form;
END;

--create procedure for get user by ID
CREATE PROCEDURE sp_GetUserById @Id int
AS
BEGIN
	SELECT * FROM user_form where id = @Id
END;

--create procedure for update user
CREATE PROCEDURE sp_UpdateUser(
	@Id int,
	@FirstName VARCHAR(30),
    @LastName VARCHAR(30),
    @DateOfBirth DATE,
    @Gender VARCHAR(10),
    @PhoneNumber VARCHAR(15),
    @EmailAddress VARCHAR(50),
    @Address VARCHAR(100),
    @City VARCHAR(30),
    @State VARCHAR(30),
    @UserName VARCHAR(30),
    @Password VARCHAR(50)
)
AS
BEGIN
	UPDATE user_form 
	SET first_name = @FirstName,
		last_name = @LastName,
		date_of_birth = @DateOfBirth,
		gender = @Gender,
		phone_number = @PhoneNumber,
		email_address = @EmailAddress,
		address = @Address,
		city = @City,
		state = @State,
		user_name = @UserName,
		password = @Password
	WHERE id = @Id;
END;

--create procedure for delete user
CREATE PROCEDURE sp_DeleteUser @Id INT
AS
BEGIN
	DELETE FROM user_form WHERE id = @Id;
END;
