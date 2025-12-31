CREATE PROCEDURE [dbo].[sp_Update_Engineering_Services]
@Engineering_Services_Id INT=NULL,
@Engineering_Services_Code NVARCHAR(100)=NULL,
@Engineering_Services_Name NVARCHAR(300)=NULL,
@Engineering_Services_Page_Title NVARCHAR(500)=NULL,
@Engineering_Services_Meta_Keyword NVARCHAR(1000)=NULL,
@Engineering_Services_Meta_Description NVARCHAR(2000)=NULL,
@Engineering_Services_News_Keyword NVARCHAR(1000)=NULL,
@Engineering_Services_News_Description NVARCHAR(2000)=NULL,
@Engineering_Services_Og_Image NVARCHAR(MAX)=NULL,
@Engineering_Services_Og_Title NVARCHAR(500)=NULL,
@Engineering_Services_Og_Description NVARCHAR(2000)=NULL,
@Engineering_Services_Image NVARCHAR(500)=NULL,
@Engineering_Services_Image_Alt_Tag NVARCHAR(500)=NULL,
@Engineering_Services_Description NVARCHAR(MAX)=NULL,
@Engineering_Services_Url_Link NVARCHAR(500)=NULL,

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
	   UPDATE tbl_Engineering_Services SET
	   Engineering_Services_Code            =@Engineering_Services_Code,
	   Engineering_Services_Name            =@Engineering_Services_Name,
	   Engineering_Services_Page_Title      =@Engineering_Services_Page_Title,
	   Engineering_Services_Meta_Keyword    =@Engineering_Services_Meta_Keyword,
	   Engineering_Services_Meta_Description=@Engineering_Services_Meta_Description,
	   Engineering_Services_News_Keyword    =@Engineering_Services_News_Keyword,
	   Engineering_Services_News_Description=@Engineering_Services_News_Description,
	   Engineering_Services_Og_Image        =@Engineering_Services_Og_Image,
	   Engineering_Services_Og_Title        =@Engineering_Services_Og_Title,
	   Engineering_Services_Og_Description  =@Engineering_Services_Og_Description,
	   Engineering_Services_Image           =@Engineering_Services_Image,
	   Engineering_Services_Image_Alt_Tag   =@Engineering_Services_Image_Alt_Tag,
	   Engineering_Services_Description     =@Engineering_Services_Description,
	   Engineering_Services_Url_Link        =@Engineering_Services_Url_Link,
	   Modified_On=@Modified_On,
       Modified_IP=@Modified_IP,
       Modified_By=@Modified_By
 WHERE Engineering_Services_Id=@Engineering_Services_Id
  		 
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Engineering Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END