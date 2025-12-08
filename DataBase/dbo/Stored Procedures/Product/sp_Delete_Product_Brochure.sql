CREATE PROCEDURE [dbo].[sp_Delete_Product_Brochure]
@Product_Brochure_Id INT
AS
BEGIN    
 BEGIN TRY  

	BEGIN
	UPDATE tbl_Product_Brochure SET Is_Active=0 WHERE Product_Brochure_Id=@Product_Brochure_Id
	SELECT @Product_Brochure_Id
	END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Product Brochure FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
   END CATCH
END
