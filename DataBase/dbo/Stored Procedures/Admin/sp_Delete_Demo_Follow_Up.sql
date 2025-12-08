CREATE PROCEDURE [dbo].[sp_Delete_Demo_Follow_Up]
@Demo_Follow_Up_Id INT

AS
BEGIN    
 BEGIN TRY   
 	
	UPDATE tbl_Demo_Follow_Up SET Is_Active= 0 WHERE Demo_Follow_Up_Id=@Demo_Follow_Up_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE DEMO FOLLOW UP FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
