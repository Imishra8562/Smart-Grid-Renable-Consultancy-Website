CREATE PROCEDURE [dbo].[sp_List_Career_Category]
@Career_Category_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Career_Category_Id=0 SET @Career_Category_Id=NULL
      
      SELECT * FROM tbl_Career_Category WHERE Career_Category_Id=ISNULL(@Career_Category_Id,Career_Category_Id) AND Is_Active=1 ORDER BY Career_Category_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Career Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END	