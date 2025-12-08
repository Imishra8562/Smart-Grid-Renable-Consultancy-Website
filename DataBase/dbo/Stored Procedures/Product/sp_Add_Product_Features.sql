CREATE PROCEDURE [dbo].[sp_Add_Product_Features]
@Product_Features_Code NVARCHAR(MAX)= NULL ,
@FK_Product_Id INT= NULL,
@Product_Features_Name  NVARCHAR(MAX)= NULL,
@Product_Features_Images  NVARCHAR(MAX)= NULL,
@Product_Features_Decriptions  NVARCHAR(MAX)= NULL,

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

   DECLARE @Product_Features_Id INT
   SELECT @Product_Features_Id=Product_Features_Id FROM tbl_Product_Features WHERE Product_Features_Id=@Product_Features_Id AND Is_Active=1

   IF @Product_Features_Id IS NULL 
   BEGIN
           INSERT INTO tbl_Product_Features(Product_Features_Code,
                                            FK_Product_Id,
                                            Product_Features_Name,
                                            Product_Features_Images,
                                            Product_Features_Decriptions,
                                            Created_By,
                                            Created_IP)
                                           VALUES(
                                            @Product_Features_Code,
                                            @FK_Product_Id,
                                            @Product_Features_Name,
                                            @Product_Features_Images,
                                            @Product_Features_Decriptions,
                                            @Created_By,
                                            @Created_IP)
    SELECT SCOPE_IDENTITY()
   END
   END    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Product Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
