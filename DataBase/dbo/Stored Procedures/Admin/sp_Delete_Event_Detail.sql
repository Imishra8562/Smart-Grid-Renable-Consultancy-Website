CREATE PROCEDURE [dbo].[sp_Delete_Event_Detail]
@Event_Detail_Id INT

AS
BEGIN
BEGIN TRY     
 	
   UPDATE tbl_Event_Detail SET Is_Active=0,Modified_On=GETDATE() WHERE Event_Detail_Id=@Event_Detail_Id
   SELECT @Event_Detail_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : DELETE Event_Detail FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END