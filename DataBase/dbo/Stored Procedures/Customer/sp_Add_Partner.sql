CREATE PROCEDURE [dbo].[sp_Add_Partner]
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Website NVARCHAR(MAX)=NULL,
@Upload_File NVARCHAR(MAX)=NULL,
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
	   
   DECLARE @Partner_Id INT
   SELECT @Partner_Id=Partner_Id from tbl_Partner where Name=@Name AND Created_IP=@Created_IP AND Is_Active=1
		 
   IF @Partner_Id IS NULL
      BEGIN
         INSERT INTO tbl_Partner(Name,Email,Phone_No,Website,Upload_File,Subject,Message,Review,Created_By,Created_IP)
		 VALUES(@Name,@Email,@Phone_No,@Website,@Upload_File,@Subject,@Message,@Review,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Partner FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
