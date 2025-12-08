CREATE PROCEDURE [dbo].[sp_Update_Product_Benefits]	
@Product_Benefits_Id INT=NULL,
@Product_Benefits_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
@Product_Benefits_Name  NVARCHAR(MAX)= NULL,
@Product_Benefits_Images  NVARCHAR(MAX)= NULL,
@Product_Benefits_Decriptions  NVARCHAR(MAX)= NULL,


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
    UPDATE tbl_Product_Benefits SET
                          FK_Product_Id=@FK_Product_Id,
                          Product_Benefits_Name=@Product_Benefits_Name,
                          Product_Benefits_Images=@Product_Benefits_Images,
                          Product_Benefits_Decriptions=@Product_Benefits_Decriptions,

                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Product_Benefits_Id=@Product_Benefits_Id

    SELECT @Product_Benefits_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Product Benefits FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END