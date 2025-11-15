CREATE PROCEDURE [dbo].[sp_List_Index_Slider]
	@Index_Slider_Id INT=NULL,
@Index_Slider_Code NVARCHAR(MAX)=NULL
AS
BEGIN    
 BEGIN TRY   

      IF @Index_Slider_Id=0 SET @Index_Slider_Id=NULL
      
      SELECT * FROM tbl_Index_Slider 
      WHERE Index_Slider_Id=ISNULL(@Index_Slider_Id,Index_Slider_Id) 
      AND Index_Slider_Code=ISNULL(@Index_Slider_Code,Index_Slider_Code)
      AND Is_Active=1 ORDER BY Index_Slider_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Index Slider FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END