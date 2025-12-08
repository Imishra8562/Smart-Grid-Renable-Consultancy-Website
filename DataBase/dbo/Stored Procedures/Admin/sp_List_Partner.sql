CREATE PROCEDURE [dbo].[sp_List_Partner]
@Partner_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Partner_Id=0 SET @Partner_Id=NULL
      
      SELECT * FROM tbl_Partner WHERE Partner_Id=ISNULL(@Partner_Id,Partner_Id) AND Is_Active=1 ORDER BY Partner_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Partner FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END