CREATE PROCEDURE [dbo].[sp_Update_Product]
@Product_Id INT=NULL,
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
	   
   UPDATE tbl_Product SET       FK_Industries_Id=@FK_Industries_Id,
                                Product_Name=@Product_Name,
                                Product_Page_Title=@Product_Page_Title,
                                Product_Meta_Keyword=@Product_Meta_Keyword,
                                Product_Meta_Description=@Product_Meta_Description,
                                Product_News_Keyword=@Product_News_Keyword,
                                Product_News_Description=@Product_News_Description,
                                Product_Og_Image=@Product_Og_Image,
                                Product_Og_Title=@Product_Og_Title,
                                Product_Og_Description=@Product_Og_Description,
                                Product_Image=@Product_Image,
                                Product_Image_Alt_Tag=@Product_Image_Alt_Tag,
                                Product_Description=@Product_Description,
                                Product_Rating=@Product_Rating,
                                Product_Review_Count=@Product_Review_Count,
                                Product_Url_Link=@Product_Url_Link,
                       
                                Modified_On=@Modified_On,
                                Modified_IP=@Modified_IP,
                                Modified_By=@Modified_By
                          WHERE Product_Id=@Product_Id

   SELECT @Product_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
