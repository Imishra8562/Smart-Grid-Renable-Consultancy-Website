CREATE PROCEDURE [dbo].[sp_Update_Blog_Comment]
@Blog_Comment_Id INT=NULL,
@FK_Blog_Id INT=NULL,
@FK_Status_Id INT=NULL,
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(Max)=NULL,
@Website NVARCHAR(Max)=NULL,
@Message NVARCHAR(Max)=NULL,
@Description NVARCHAR(Max)=NULL,

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
	   
   UPDATE tbl_Blog_Comment SET FK_Status_Id=@FK_Status_Id,                              

                               Modified_On=@Modified_On,
                               Modified_IP=@Modified_IP,
                               Modified_By=@Modified_By
                         WHERE Blog_Comment_Id=@Blog_Comment_Id
   SELECT @Blog_Comment_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Blog_Comment FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
