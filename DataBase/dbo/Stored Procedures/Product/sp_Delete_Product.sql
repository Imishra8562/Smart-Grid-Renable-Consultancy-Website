CREATE PROCEDURE [dbo].[sp_Delete_Product]
@Product_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Product SET Is_Active=0,Modified_On=GETDATE() WHERE Product_Id=@Product_Id
   SELECT @Product_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Product FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
