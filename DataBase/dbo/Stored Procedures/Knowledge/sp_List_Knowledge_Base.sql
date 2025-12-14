CREATE PROCEDURE [dbo].[sp_List_Knowledge_Base]
@Knowledge_Base_Id INT=NULL,
@Knowledge_Base_Category_Id INT=NULL,
@Knowledge_Base_Url_Link NVARCHAR(MAX)=NULL

AS
BEGIN                           
 BEGIN TRY      

      IF @Knowledge_Base_Id=0 SET @Knowledge_Base_Id=NULL 
      
 
     SELECT * FROM tbl_Knowledge_Base I
        
     WHERE I.Knowledge_Base_Id=ISNULL(@Knowledge_Base_Id,I.Knowledge_Base_Id)
     AND I.FK_Knowledge_Base_Category_Id=ISNULL(@Knowledge_Base_Category_Id,I.FK_Knowledge_Base_Category_Id)
     AND I.Knowledge_Base_Url_Link=ISNULL(@Knowledge_Base_Url_Link,I.Knowledge_Base_Url_Link)
     AND I.Is_Active=1 ORDER BY Knowledge_Base_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Knowledge Base FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END

