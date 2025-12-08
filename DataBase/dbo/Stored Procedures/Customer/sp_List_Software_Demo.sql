CREATE PROCEDURE [dbo].[sp_List_Software_Demo]
@Software_Demo_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Software_Demo_Id=0 SET @Software_Demo_Id=NULL
      
      SELECT * FROM tbl_Software_Demo WHERE Software_Demo_Id=ISNULL(@Software_Demo_Id,Software_Demo_Id) AND Is_Active=1 ORDER BY Software_Demo_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Software_Demo FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END