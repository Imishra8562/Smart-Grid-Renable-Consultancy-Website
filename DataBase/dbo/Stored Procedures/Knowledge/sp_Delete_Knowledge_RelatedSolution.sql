CREATE PROCEDURE [dbo].[sp_Delete_Knowledge_RelatedSolution]
	@Knowledge_RelatedSolution_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Knowledge_RelatedSolution SET Is_Active=0,Modified_On=GETDATE() WHERE Knowledge_RelatedSolution_Id=@Knowledge_RelatedSolution_Id
   SELECT @Knowledge_RelatedSolution_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Knowledge RelatedSolution FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
