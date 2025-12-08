CREATE PROCEDURE [dbo].[sp_Delete_Industries]
@Industries_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Industries SET Is_Active=0,Modified_On=GETDATE() WHERE Industries_Id=@Industries_Id
   SELECT @Industries_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Industries FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
