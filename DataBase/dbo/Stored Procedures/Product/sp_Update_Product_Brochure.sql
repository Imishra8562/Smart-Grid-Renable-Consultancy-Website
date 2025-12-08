CREATE PROCEDURE [dbo].[sp_Update_Product_Brochure]	
@Product_Brochure_Id INT=NULL,
@Product_Brochure_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
@Product_Brochure_File NVARCHAR(MAX)= NULL,
@Product_Brochure_Decriptions NVARCHAR(MAX)= NULL,


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
    UPDATE tbl_Product_Brochure SET
                          FK_Product_Id=@FK_Product_Id,
                          Product_Brochure_File=@Product_Brochure_File,
                          Product_Brochure_Decriptions=@Product_Brochure_Decriptions,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Product_Brochure_Id=@Product_Brochure_Id

    SELECT @Product_Brochure_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product Brochure FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END