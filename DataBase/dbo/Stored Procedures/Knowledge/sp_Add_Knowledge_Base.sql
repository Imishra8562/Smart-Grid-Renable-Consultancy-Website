CREATE PROCEDURE [dbo].[sp_Add_Knowledge_Base]
@Knowledge_Base_Code NVARCHAR(MAX)=NULL,
@Knowledge_Base_Name NVARCHAR(MAX)=NULL,
@Knowledge_Base_Page_Title NVARCHAR(MAX)=NULL,
@Knowledge_Base_Meta_Keyword NVARCHAR(MAX)=NULL,
@Knowledge_Base_Meta_Description NVARCHAR(MAX)=NULL,
@Knowledge_Base_News_Keyword NVARCHAR(MAX)=NULL,
@Knowledge_Base_News_Description NVARCHAR(MAX)=NULL,
@Knowledge_Base_Og_Image NVARCHAR(MAX)=NULL,
@Knowledge_Base_Og_Title NVARCHAR(MAX)=NULL,
@Knowledge_Base_Og_Description NVARCHAR(MAX)=NULL,
@Knowledge_Base_Image NVARCHAR(MAX)=NULL,
@Knowledge_Base_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_Base_Description NVARCHAR(MAX)=NULL,
@Knowledge_Base_Url_Link NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Knowledge_BaseId INT
   SELECT @Knowledge_BaseId=Knowledge_Base_Id from tbl_Knowledge_Base where Knowledge_Base_Name=@Knowledge_Base_Name AND Is_Active=1
		 
   IF @Knowledge_BaseId IS NULL
      BEGIN
         INSERT INTO tbl_Knowledge_Base(Knowledge_Base_Code,Knowledge_Base_Name,Knowledge_Base_Page_Title,Knowledge_Base_Meta_Keyword,Knowledge_Base_Meta_Description,Knowledge_Base_News_Keyword,Knowledge_Base_News_Description,
									Knowledge_Base_Og_Image,Knowledge_Base_Og_Title,Knowledge_Base_Og_Description,Knowledge_Base_Image,Knowledge_Base_Image_Alt_Tag,Knowledge_Base_Description,Knowledge_Base_Url_Link,Created_By,Created_IP)
		 VALUES(@Knowledge_Base_Code,@Knowledge_Base_Name,@Knowledge_Base_Page_Title,@Knowledge_Base_Meta_Keyword,@Knowledge_Base_Meta_Description,@Knowledge_Base_News_Keyword,@Knowledge_Base_News_Description,
				@Knowledge_Base_Og_Image,@Knowledge_Base_Og_Title,@Knowledge_Base_Og_Description,@Knowledge_Base_Image,@Knowledge_Base_Image_Alt_Tag,@Knowledge_Base_Description,@Knowledge_Base_Url_Link,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Knowledge Base FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
