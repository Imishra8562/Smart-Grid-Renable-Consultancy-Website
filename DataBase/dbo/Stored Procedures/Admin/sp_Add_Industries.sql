CREATE PROCEDURE [dbo].[sp_Add_Industries]
@Industries_Code NVARCHAR(MAX)=NULL,
@Industries_Name NVARCHAR(MAX)=NULL,
@Industries_Page_Title NVARCHAR(MAX)=NULL,
@Industries_Meta_Keyword NVARCHAR(MAX)=NULL,
@Industries_Meta_Description NVARCHAR(MAX)=NULL,
@Industries_News_Keyword NVARCHAR(MAX)=NULL,
@Industries_News_Description NVARCHAR(MAX)=NULL,
@Industries_Og_Image NVARCHAR(MAX)=NULL,
@Industries_Og_Title NVARCHAR(MAX)=NULL,
@Industries_Og_Description NVARCHAR(MAX)=NULL,
@Industries_Image NVARCHAR(MAX)=NULL,
@Industries_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Industries_Description NVARCHAR(MAX)=NULL,
@Industries_Url_Link NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @IndustriesId INT
   SELECT @IndustriesId=Industries_Id from tbl_Industries where Industries_Name=@Industries_Name AND Is_Active=1
		 
   IF @IndustriesId IS NULL
      BEGIN
         INSERT INTO tbl_Industries(Industries_Code,Industries_Name,Industries_Page_Title,Industries_Meta_Keyword,Industries_Meta_Description,Industries_News_Keyword,Industries_News_Description,
									Industries_Og_Image,Industries_Og_Title,Industries_Og_Description,Industries_Image,Industries_Image_Alt_Tag,Industries_Description,Industries_Url_Link,Created_By,Created_IP)
		 VALUES(@Industries_Code,@Industries_Name,@Industries_Page_Title,@Industries_Meta_Keyword,@Industries_Meta_Description,@Industries_News_Keyword,@Industries_News_Description,
				@Industries_Og_Image,@Industries_Og_Title,@Industries_Og_Description,@Industries_Image,@Industries_Image_Alt_Tag,@Industries_Description,@Industries_Url_Link,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Industries FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
