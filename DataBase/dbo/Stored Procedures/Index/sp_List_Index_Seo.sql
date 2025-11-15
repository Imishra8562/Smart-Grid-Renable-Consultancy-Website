CREATE PROCEDURE [dbo].[sp_List_Index_Seo]
@Index_Seo_Id INT=NULL,
@Index_Seo_Slug NVARCHAR(MAX)=NULL
AS
BEGIN    
 BEGIN TRY   

      IF @Index_Seo_Id=0 SET @Index_Seo_Id=NULL
      
      SELECT * FROM tbl_Index_Seo 
      WHERE Index_Seo_Id=ISNULL(@Index_Seo_Id,Index_Seo_Id) 
      AND Index_Seo_Slug=ISNULL(@Index_Seo_Slug,Index_Seo_Slug)
      AND Is_Active=1 ORDER BY Index_Seo_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Index Seo FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END