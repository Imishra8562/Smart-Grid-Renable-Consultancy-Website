CREATE PROCEDURE [dbo].[sp_Add_Index_Slider]
@FK_Index_Seo_Id INT=NULL,
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
	   
   DECLARE @Index_SliderId INT
   SELECT @Index_SliderId=Index_Slider_Id from tbl_Index_Slider where Index_Slider_Code=@Index_Slider_Code AND Is_Active=1
		 
   IF @Index_SliderId IS NULL
      BEGIN
         INSERT INTO tbl_Index_Slider(
		 FK_Index_Seo_Id ,
		 Index_Slider_Code,        
		 Index_Slider_Image,       
		 Index_Slider_Alt_Tag ,    
		 Index_Slider_Headline,    
		 Index_Slider_SubHeadline ,
		 Created_By,Created_IP)

		 VALUES(
		 @FK_Index_Seo_Id ,
		 @Index_Slider_Code ,       
		 @Index_Slider_Image ,      
		 @Index_Slider_Alt_Tag ,    
		 @Index_Slider_Headline,    
		 @Index_Slider_SubHeadline ,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Index Slider FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END