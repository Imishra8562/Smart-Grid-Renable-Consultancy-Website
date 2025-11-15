CREATE PROCEDURE [dbo].[sp_List_Index_Team]
	@Index_Team_Id INT=NULL,
@Index_Team_Member_Name NVARCHAR(MAX)=NULL
AS
BEGIN    
 BEGIN TRY   

      IF @Index_Team_Id=0 SET @Index_Team_Id=NULL
      
      SELECT * FROM tbl_Index_Team 
      WHERE Index_Team_Id=ISNULL(@Index_Team_Id,Index_Team_Id) 
      AND Index_Team_Member_Name=ISNULL(@Index_Team_Member_Name,Index_Team_Member_Name)
      AND Is_Active=1 ORDER BY Index_Team_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Index Team FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END