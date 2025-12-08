CREATE PROCEDURE [dbo].[sp_Update_Blog_FAQ]	
@Blog_FAQ_Id INT=NULL,
@Blog_FAQ_Code NVARCHAR(MAX)= NULL ,
@FK_Blog_Id INT =NULL,
@Blog_FAQ_Question NVARCHAR(MAX)= NULL,
@Blog_FAQ_Answer NVARCHAR(MAX)= NULL,

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN    
 BEGIN TRY   
   BEGIN 
    UPDATE tbl_Blog_FAQ SET
                          FK_Blog_Id=@FK_Blog_Id,
                          Blog_FAQ_Question=@Blog_FAQ_Question,
                          Blog_FAQ_Answer=@Blog_FAQ_Answer,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Blog_FAQ_Id=@Blog_FAQ_Id

    SELECT @Blog_FAQ_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Blog FAQ FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END