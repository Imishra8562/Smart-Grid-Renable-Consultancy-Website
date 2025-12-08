CREATE PROCEDURE [dbo].[sp_Update_Industries]
@Industries_Id INT=NULL,
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
	   
   UPDATE tbl_Industries SET 
                                Industries_Name=@Industries_Name,
                                Industries_Page_Title=@Industries_Page_Title,
                                Industries_Meta_Keyword=@Industries_Meta_Keyword,
                                Industries_Meta_Description=@Industries_Meta_Description,
                                Industries_News_Keyword=@Industries_News_Keyword,
                                Industries_News_Description=@Industries_News_Description,
                                Industries_Og_Image=@Industries_Og_Image,
                                Industries_Og_Title=@Industries_Og_Title,
                                Industries_Og_Description=@Industries_Og_Description,
                                Industries_Image=@Industries_Image,
                                Industries_Image_Alt_Tag=@Industries_Image_Alt_Tag,
                                Industries_Description=@Industries_Description,
                                Industries_Url_Link=@Industries_Url_Link,
                       
                                Modified_On=@Modified_On,
                                Modified_IP=@Modified_IP,
                                Modified_By=@Modified_By
                          WHERE Industries_Id=@Industries_Id

   SELECT @Industries_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Industries FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
