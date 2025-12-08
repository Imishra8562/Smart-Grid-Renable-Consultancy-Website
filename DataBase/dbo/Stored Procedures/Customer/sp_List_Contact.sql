CREATE PROCEDURE [dbo].[sp_List_Contact]
@Contact_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Contact_Id=0 SET @Contact_Id=NULL
      
      SELECT * FROM tbl_Contact WHERE Contact_Id=ISNULL(@Contact_Id,Contact_Id) AND Is_Active=1 ORDER BY Contact_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Contact FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END