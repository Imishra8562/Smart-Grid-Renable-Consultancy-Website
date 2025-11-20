CREATE PROCEDURE [dbo].[sp_Update_Index_Slider]
@FK_Index_Seo_Id INT=NULL,
@Index_Slider_Id           INT=NULL,
@Index_Slider_Code         NVARCHAR(MAX)=NULL,
@Index_Slider_Image        NVARCHAR(MAX)=NULL,
@Index_Slider_Alt_Tag      NVARCHAR(MAX)=NULL,
@Index_Slider_Headline     NVARCHAR(MAX)=NULL,
@Index_Slider_SubHeadline  NVARCHAR(MAX)=NULL,

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
         UPDATE tbl_Index_Slider SET 
         FK_Index_Seo_Id =@FK_Index_Seo_Id ,
         Index_Slider_Image       =@Index_Slider_Image       ,
         Index_Slider_Alt_Tag     =@Index_Slider_Alt_Tag     ,
         Index_Slider_Headline    =@Index_Slider_Headline    ,
         Index_Slider_SubHeadline =@Index_Slider_SubHeadline ,
		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By

		WHERE Index_Slider_Id=@Index_Slider_Id 
        SELECT @Index_Slider_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Index Slider FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
	