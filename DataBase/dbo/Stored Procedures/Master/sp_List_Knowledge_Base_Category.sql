CREATE PROCEDURE [dbo].[sp_List_Knowledge_Base_Category]
@Knowledge_Base_Category_Id INT=NULL,
@Category_Description NVARCHAR(MAX)=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Knowledge_Base_Category_Id=0 SET @Knowledge_Base_Category_Id=NULL
      
      SELECT * FROM tbl_Knowledge_Base_Category B
      WHERE B.Knowledge_Base_Category_Id=ISNULL(@Knowledge_Base_Category_Id,B.Knowledge_Base_Category_Id) 
      AND B.Category_Description=ISNULL(@Category_Description,B.Category_Description)
      AND Is_Active=1 ORDER BY Knowledge_Base_Category_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Knowledge Base Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END