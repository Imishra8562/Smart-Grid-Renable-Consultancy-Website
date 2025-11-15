CREATE PROCEDURE [dbo].[sp_List_Index_Features]
	@Index_Features_Id INT=NULL,
@Index_Features_Code NVARCHAR(MAX)=NULL
AS
BEGIN    
 BEGIN TRY   

      IF @Index_Features_Id=0 SET @Index_Features_Id=NULL
      
      SELECT * FROM tbl_Index_Features 
      WHERE Index_Features_Id=ISNULL(@Index_Features_Id,Index_Features_Id) 
      AND Index_Features_Code=ISNULL(@Index_Features_Code,Index_Features_Code)
      AND Is_Active=1 ORDER BY Index_Features_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Index Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END