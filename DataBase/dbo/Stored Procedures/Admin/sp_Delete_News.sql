CREATE PROCEDURE [dbo].[sp_Delete_News]
@News_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_News SET Is_Active=0,Modified_On=GETDATE() WHERE News_Id=@News_Id
   SELECT @News_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE News FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
