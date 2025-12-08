CREATE PROCEDURE [dbo].[sp_List_Blog]
@Blog_Id INT=NULL,
@Blog_Link NVARCHAR(MAX)=NULL,
@Blog_Category_Id INT=Null

AS
BEGIN                           
 BEGIN TRY      

      IF @Blog_Id=0 SET @Blog_Id=NULL 
      IF @Blog_Category_Id=0 Set @Blog_Category_Id=NULL
      
 
     SELECT * FROM tbl_Blog BG
     INNER JOIN tbl_Blog_Category BC ON BG.FK_Blog_Category_Id=BC.Blog_Category_Id      
     WHERE BG.Blog_Id=ISNULL(@Blog_Id,BG.Blog_Id)
     AND BG.Blog_Link=ISNULL(@Blog_Link,BG.Blog_Link)
     AND BG.FK_Blog_Category_Id=ISNULL(@Blog_Category_Id,BG.FK_Blog_Category_Id)
     AND BG.Is_Active=1 ORDER BY Blog_Id DESC


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END

