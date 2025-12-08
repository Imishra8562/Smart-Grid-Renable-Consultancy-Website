CREATE PROCEDURE [dbo].[sp_List_Client]
@Client_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN                           
 BEGIN TRY      

      IF @Client_Id=0 SET @Client_Id=NULL 
      IF @Product_Id=0 Set @Product_Id=NULL
      
 
     SELECT * FROM tbl_Client BG
     INNER JOIN tbl_Product P ON BG.FK_Product_Id=P.Product_Id      
     WHERE BG.Client_Id=ISNULL(@Client_Id,BG.Client_Id)
     AND BG.FK_Product_Id=ISNULL(@Product_Id,BG.FK_Product_Id)
     AND BG.Is_Active=1 ORDER BY Client_Id DESC


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END

