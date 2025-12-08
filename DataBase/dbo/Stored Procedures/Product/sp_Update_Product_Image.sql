CREATE PROCEDURE [dbo].[sp_Update_Product_Image]	
@Product_Image_Id INT=NULL,
@Product_Image_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
@Product_Details_Image  NVARCHAR(MAX)= NULL,
@Product_Details_Decriptions  NVARCHAR(MAX)= NULL,


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
    UPDATE tbl_Product_Image SET
                          FK_Product_Id=@FK_Product_Id,
                          Product_Details_Image=@Product_Details_Image,
                          Product_Details_Decriptions=@Product_Details_Decriptions,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Product_Image_Id=@Product_Image_Id

    SELECT @Product_Image_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product Images FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END