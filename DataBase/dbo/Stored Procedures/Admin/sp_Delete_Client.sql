CREATE PROCEDURE [dbo].[sp_Delete_Client]
@Client_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Client SET Is_Active=0,Modified_On=GETDATE() WHERE Client_Id=@Client_Id
   SELECT @Client_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Client FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
