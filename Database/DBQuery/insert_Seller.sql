create Procedure insert_Seller
@firstName nvarchar(20),
@lastName nvarchar(20),
@userName nvarchar(20),
@phoneNumber nvarchar(11),
@email nvarchar(30),
@password nvarchar(20),
@commercialName nvarchar(50),
@address nvarchar(255)
as
begin 
	begin try
		begin transaction;

		DECLARE @InsertedUserID int;

		insert into Users values 
		(@firstName,@lastName,@userName,@phoneNumber,@email,@password,1);

		SET @InsertedUserID = SCOPE_IDENTITY();

		insert into Sellers values
		(@InsertedUserID,@commercialName , 0.0 ,@address);

		commit transaction;
	end try
	begin catch
		rollback transaction;
		throw;
	end catch;
end;