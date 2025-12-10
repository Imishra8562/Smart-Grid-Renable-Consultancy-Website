CREATE PROCEDURE [dbo].[sp_Delete_Knowledge_Base]
	@Knowledge_Base_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Knowledge_Base SET Is_Active=0,Modified_On=GETDATE() WHERE Knowledge_Base_Id=@Knowledge_Base_Id
   SELECT @Knowledge_Base_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Knowledge Base FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
