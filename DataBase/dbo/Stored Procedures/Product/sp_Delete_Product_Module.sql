CREATE PROCEDURE [dbo].[sp_Delete_Product_Module]
@Product_Module_Id INT
AS
BEGIN    
 BEGIN TRY  

	BEGIN
	UPDATE tbl_Product_Module SET Is_Active=0 WHERE Product_Module_Id=@Product_Module_Id
	SELECT @Product_Module_Id
	END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Product Module FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
   END CATCH
END
