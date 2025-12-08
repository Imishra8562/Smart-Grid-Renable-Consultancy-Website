CREATE PROCEDURE [dbo].[sp_Add_Blog_Comment]
@FK_Blog_Id INT=NULL,
@FK_Status_Id INT=NULL,
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Website NVARCHAR(MAX)=NULL,
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
	   
   DECLARE @Blog_Comment_Id INT
   SELECT @Blog_Comment_Id=Blog_Comment_Id from tbl_Blog_Comment where Message=@Message AND Created_IP=@Created_IP AND Is_Active=1
		 
   IF @Blog_Comment_Id IS NULL
      BEGIN
         INSERT INTO tbl_Blog_Comment(FK_Blog_Id,FK_Status_Id,Name,Email,Website,Message,Description,Created_By,Created_IP)
		 VALUES(@FK_Blog_Id,1,@Name,@Email,@Website,@Message,@Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Blog Comment FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
