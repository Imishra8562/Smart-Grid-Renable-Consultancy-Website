CREATE PROCEDURE [dbo].[sp_Add_Index_Seo]
@Index_Seo_Code             NVARCHAR(MAX)=NULL, 
@Index_Seo_Page_Title       NVARCHAR(MAX)=NULL,
@Index_Seo_Meta_Keyword     NVARCHAR(MAX)=NULL,
@Index_Seo_Meta_Description NVARCHAR(MAX)=NULL,
@Index_Seo_Og_Image         NVARCHAR(MAX)=NULL,
@Index_Seo_Image_Alt_Tag    NVARCHAR(MAX)=NULL,
@Index_Seo_Og_Title         NVARCHAR(MAX)=NULL,
@Index_Seo_Og_Description   NVARCHAR(MAX)=NULL,
@Index_Seo_Slug             NVARCHAR(MAX)=NULL,  

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN
BEGIN TRY  
	   
   DECLARE @Index_SeoId INT
   SELECT @Index_SeoId=Index_Seo_Id from tbl_Index_Seo where Index_Seo_Code=@Index_Seo_Code AND Is_Active=1
		 
   IF @Index_SeoId IS NULL
      BEGIN
         INSERT INTO tbl_Index_Seo(
		 Index_Seo_Code,
		 Index_Seo_Page_Title,
		 Index_Seo_Meta_Keyword,
		 Index_Seo_Meta_Description,
		 Index_Seo_Og_Image,
		 Index_Seo_Image_Alt_Tag,
		 Index_Seo_Og_Title,
		 Index_Seo_Og_Description,
		 Index_Seo_Slug,            
		 Created_By,Created_IP)

		 VALUES(
		 @Index_Seo_Code,
		 @Index_Seo_Page_Title,
		 @Index_Seo_Meta_Keyword,
		 @Index_Seo_Meta_Description,
		 @Index_Seo_Og_Image,
		 @Index_Seo_Image_Alt_Tag,
		 @Index_Seo_Og_Title,
		 @Index_Seo_Og_Description,
		 @Index_Seo_Slug,@Created_By,@Created_IP)

		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Index_Seo FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END