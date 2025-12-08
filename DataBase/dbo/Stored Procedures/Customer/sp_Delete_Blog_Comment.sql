CREATE PROCEDURE [dbo].[sp_Delete_Blog_Comment]
@Blog_Comment_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Blog_Comment SET Is_Active=0,Modified_On=GETDATE() WHERE Blog_Comment_Id=@Blog_Comment_Id
   SELECT @Blog_Comment_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Blog_Comment FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END