CREATE PROCEDURE [dbo].[sp_List_Index_Services]
	@Index_Services_Id INT=NULL,
@Index_Services_Code NVARCHAR(MAX)=NULL
AS
BEGIN    
 BEGIN TRY   

      IF @Index_Services_Id=0 SET @Index_Services_Id=NULL
      
      SELECT * FROM tbl_Index_Services 
      WHERE Index_Services_Id=ISNULL(@Index_Services_Id,Index_Services_Id) 
      AND Index_Services_Code=ISNULL(@Index_Services_Code,Index_Services_Code)
      AND Is_Active=1 ORDER BY Index_Services_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Index Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END