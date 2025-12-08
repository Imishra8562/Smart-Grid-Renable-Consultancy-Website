CREATE PROCEDURE [dbo].[sp_Add_Job_Request]
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Upload_Resume NVARCHAR(MAX)=NULL,
@Job_Position NVARCHAR(MAX)=NULL,
@Message NVARCHAR(MAX)=NULL,
@Description NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Job_Request_Id INT
   SELECT @Job_Request_Id=Job_Request_Id from tbl_Job_Request where Created_IP=@Created_IP AND Name=@Name AND Is_Active=1
		 
   IF @Job_Request_Id IS NULL
      BEGIN
         INSERT INTO tbl_Job_Request(Name,Email,Phone_No,Upload_Resume,Job_Position,Message,Description,Created_By,Created_IP)
		 VALUES(@Name,@Email,@Phone_No,@Upload_Resume,@Job_Position,@Message,@Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Job Request FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
