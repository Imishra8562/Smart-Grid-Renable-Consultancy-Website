CREATE PROCEDURE [dbo].[sp_Update_Product_FAQ]	
@Product_FAQ_Id INT=NULL,
@Product_FAQ_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
@Product_FAQ_Question NVARCHAR(MAX)= NULL,
@Product_FAQ_Answer NVARCHAR(MAX)= NULL,

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
    UPDATE tbl_Product_FAQ SET
                          FK_Product_Id=@FK_Product_Id,
                          Product_FAQ_Question=@Product_FAQ_Question,
                          Product_FAQ_Answer=@Product_FAQ_Answer,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Product_FAQ_Id=@Product_FAQ_Id

    SELECT @Product_FAQ_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product FAQ FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END