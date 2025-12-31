CREATE PROCEDURE [dbo].[sp_Delete_Engineering_Services_Features]
		@Engineering_Services_Features_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Engineering_Services_Features SET Is_Active=0,Modified_On=GETDATE() WHERE Engineering_Services_Features_Id=@Engineering_Services_Features_Id
   SELECT @Engineering_Services_Features_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Engineering Services Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
