CREATE PROCEDURE [dbo].[sp_List_Product]
@Product_Id INT=NULL,
@Industries_Id INT=NULL,
@Product_Url_Link NVARCHAR(MAX)=NULL

AS
BEGIN                           
 BEGIN TRY      

      IF @Product_Id=0 SET @Product_Id=NULL 
      IF @Industries_Id=0 SET @Industries_Id=NULL 
      
 
     SELECT * FROM tbl_Product P
     INNER JOIN tbl_Industries I on p.FK_Industries_Id = I.Industries_Id
     WHERE P.Product_Id=ISNULL(@Product_Id,P.Product_Id)
     AND P.FK_Industries_Id=ISNULL(@Industries_Id,P.FK_Industries_Id)
     AND P.Product_Url_Link=ISNULL(@Product_Url_Link,P.Product_Url_Link)
     AND P.Is_Active=1 ORDER BY Product_Id


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Product FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END