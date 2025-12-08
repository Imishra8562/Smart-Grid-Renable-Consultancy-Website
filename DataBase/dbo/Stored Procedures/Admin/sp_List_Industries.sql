CREATE PROCEDURE [dbo].[sp_List_Industries]
@Industries_Id INT=NULL,
@Industries_Url_Link NVARCHAR(MAX)=NULL

AS
BEGIN                           
 BEGIN TRY      

      IF @Industries_Id=0 SET @Industries_Id=NULL 
      
 
     SELECT * FROM tbl_Industries I
        
     WHERE I.Industries_Id=ISNULL(@Industries_Id,I.Industries_Id)
     AND I.Industries_Url_Link=ISNULL(@Industries_Url_Link,I.Industries_Url_Link)
     AND I.Is_Active=1 ORDER BY Industries_Id


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Industries FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END

