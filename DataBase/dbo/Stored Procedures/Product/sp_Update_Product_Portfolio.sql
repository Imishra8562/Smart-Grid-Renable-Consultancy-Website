CREATE PROCEDURE [dbo].[sp_Update_Product_Portfolio]	
@Product_Portfolio_Id INT=NULL,
@Product_Portfolio_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
--@Product_Portfolio_Name  NVARCHAR(MAX)= NULL,
@Product_Portfolio_Images  NVARCHAR(MAX)= NULL,
@Product_Portfolio_Decriptions  NVARCHAR(MAX)= NULL,


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
    UPDATE tbl_Product_Portfolio SET
                          FK_Product_Id=@FK_Product_Id,
                          --Product_Portfolio_Name=@Product_Portfolio_Name,
                          Product_Portfolio_Images=@Product_Portfolio_Images,
                          Product_Portfolio_Decriptions=@Product_Portfolio_Decriptions,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Product_Portfolio_Id=@Product_Portfolio_Id

    SELECT @Product_Portfolio_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product Portfolio FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END