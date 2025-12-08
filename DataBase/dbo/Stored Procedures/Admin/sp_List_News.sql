CREATE PROCEDURE [dbo].[sp_List_News]
@News_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @News_Id=0 SET @News_Id=NULL
      
      SELECT * FROM tbl_News WHERE News_Id=ISNULL(@News_Id,News_Id) AND Is_Active=1 ORDER BY News_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST News FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END