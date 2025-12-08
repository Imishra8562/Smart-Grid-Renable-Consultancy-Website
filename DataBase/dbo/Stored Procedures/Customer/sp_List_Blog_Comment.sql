CREATE PROCEDURE [dbo].[sp_List_Blog_Comment]
@Blog_Comment_Id INT=NULL,
@Blog_Id INT=NUll,
@Status_Id INT=NUll

AS
BEGIN                           
 BEGIN TRY      

      IF @Blog_Comment_Id=0 SET @Blog_Comment_Id=NULL 
      IF @Blog_Id=0 Set @Blog_Id=NULL
      IF @Status_Id=0 Set @Status_Id=NULL
      
 
     SELECT * FROM tbl_Blog_Comment BC
     INNER JOIN tbl_Blog B ON BC.FK_Blog_Id=B.Blog_Id
     INNER JOIN tbl_Status S ON BC.FK_Status_Id=S.Status_Id    
     WHERE BC.Blog_Comment_Id=ISNULL(@Blog_Comment_Id,BC.Blog_Comment_Id)
     AND BC.FK_Blog_Id=ISNULL(@Blog_Id,BC.FK_Blog_Id)
     AND BC.FK_Status_Id=ISNULL(@Status_Id,BC.FK_Status_Id)
     AND BC.Is_Active=1 ORDER BY Blog_Comment_Id DESC


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Blog_Comment FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END