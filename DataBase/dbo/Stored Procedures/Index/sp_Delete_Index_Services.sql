CREATE PROCEDURE [dbo].[sp_Delete_Index_Services]
	@Index_Services_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Index_Services SET Is_Active=0,Modified_On=GETDATE() WHERE Index_Services_Id=@Index_Services_Id
   SELECT @Index_Services_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Index Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
