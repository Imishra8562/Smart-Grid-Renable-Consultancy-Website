CREATE PROCEDURE [dbo].[sp_Add_Product_Benefits]
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

   DECLARE @Product_Benefits_Id INT
   SELECT @Product_Benefits_Id=Product_Benefits_Id FROM tbl_Product_Benefits WHERE Product_Benefits_Id=@Product_Benefits_Id AND Is_Active=1

   IF @Product_Benefits_Id IS NULL 
   BEGIN
    --SELECT @Product_Benefits_Code = ('PB-') + (SELECT CAST(CONVERT(numeric(8,0),RAND() * 8999999) + 1000000 AS NVARCHAR))
           INSERT INTO tbl_Product_Benefits(Product_Benefits_Code,
                                            FK_Product_Id,
                                            Product_Benefits_Name,
                                            Product_Benefits_Images,
                                            Product_Benefits_Decriptions,
                                            Created_By,
                                            Created_IP)
                                           VALUES(
                                            @Product_Benefits_Code,
                                            @FK_Product_Id,
                                            @Product_Benefits_Name,
                                            @Product_Benefits_Images,
                                            @Product_Benefits_Decriptions,
                                            @Created_By,
                                            @Created_IP)
    SELECT SCOPE_IDENTITY()
   END
   END    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Product Benifits FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
