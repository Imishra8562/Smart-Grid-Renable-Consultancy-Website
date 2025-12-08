CREATE PROCEDURE [dbo].[sp_Add_Product]
@Product_Code NVARCHAR(MAX)=NULL,
@FK_Industries_Id INT=NULL,
@Product_Name NVARCHAR(MAX)=NULL,
@Product_Page_Title NVARCHAR(MAX)=NULL,
@Product_Meta_Keyword NVARCHAR(MAX)=NULL,
@Product_Meta_Description NVARCHAR(MAX)=NULL,
@Product_News_Keyword NVARCHAR(MAX)=NULL,
@Product_News_Description NVARCHAR(MAX)=NULL,
@Product_Og_Image NVARCHAR(MAX)=NULL,
@Product_Og_Title NVARCHAR(MAX)=NULL,
@Product_Og_Description NVARCHAR(MAX)=NULL,
@Product_Image NVARCHAR(MAX)=NULL,
@Product_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Product_Description NVARCHAR(MAX)=NULL,
@Product_Rating NVARCHAR(MAX)=NULL,
@Product_Review_Count NVARCHAR(MAX)=NULL,
@Product_Url_Link NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @ProductId INT
   SELECT @ProductId=Product_Id from tbl_Product where Product_Name=@Product_Name AND Is_Active=1
		 
   IF @ProductId IS NULL
      BEGIN
         INSERT INTO tbl_Product(Product_Code,FK_Industries_Id,Product_Name,Product_Page_Title,Product_Meta_Keyword,Product_Meta_Description,Product_News_Keyword,Product_News_Description,
									Product_Og_Image,Product_Og_Title,Product_Og_Description,Product_Image,Product_Image_Alt_Tag,Product_Description,Product_Rating,Product_Review_Count,Product_Url_Link,Created_By,Created_IP)
		 VALUES(@Product_Code,@FK_Industries_Id,@Product_Name,@Product_Page_Title,@Product_Meta_Keyword,@Product_Meta_Description,@Product_News_Keyword,@Product_News_Description,
				@Product_Og_Image,@Product_Og_Title,@Product_Og_Description,@Product_Image,@Product_Image_Alt_Tag,@Product_Description,@Product_Rating,@Product_Review_Count,@Product_Url_Link,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Product FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
