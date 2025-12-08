CREATE PROCEDURE [dbo].[sp_Add_Contact]
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Website NVARCHAR(MAX)=NULL,
@Subject NVARCHAR(MAX)=NULL,
@Message NVARCHAR(MAX)=NULL,
@Review NVARCHAR(MAX)=NULL,

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN
BEGIN TRY  
	   
   DECLARE @Contact_Id INT
   SELECT @Contact_Id=Contact_Id from tbl_Contact where Created_IP=@Created_IP AND Name=@Name  AND Is_Active=1
		 
   IF @Contact_Id IS NULL
      BEGIN
         INSERT INTO tbl_Contact(Name,Email,Phone_No,Website,Subject,Message,Review,Created_By,Created_IP)
		 VALUES(@Name,@Email,@Phone_No,@Website,@Subject,@Message,@Review,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Contact FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
