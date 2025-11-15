CREATE PROCEDURE [dbo].[sp_Delete_Index_Features]
	@Index_Features_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Index_Features SET Is_Active=0,Modified_On=GETDATE() WHERE Index_Features_Id=@Index_Features_Id
   SELECT @Index_Features_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Index Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
