CREATE PROCEDURE [dbo].[sp_Delete_Blog]
@Blog_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Blog SET Is_Active=0,Modified_On=GETDATE() WHERE Blog_Id=@Blog_Id
   SELECT @Blog_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
