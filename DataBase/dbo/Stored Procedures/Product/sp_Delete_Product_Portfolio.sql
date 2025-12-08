CREATE PROCEDURE [dbo].[sp_Delete_Product_Portfolio]
@Product_Portfolio_Id INT
AS
BEGIN    
 BEGIN TRY  

	BEGIN
	UPDATE tbl_Product_Portfolio SET Is_Active=0 WHERE Product_Portfolio_Id=@Product_Portfolio_Id
	SELECT @Product_Portfolio_Id
	END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Product Portfolio FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
   END CATCH
END
