CREATE PROCEDURE [dbo].[sp_Delete_Career_Category]
@Career_Category_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Career_Category SET Is_Active=0,Modified_On=GETDATE() WHERE Career_Category_Id=@Career_Category_Id
   SELECT @Career_Category_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Career Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END