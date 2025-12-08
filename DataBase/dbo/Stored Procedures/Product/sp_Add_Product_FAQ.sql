CREATE PROCEDURE [dbo].[sp_Add_Product_FAQ]
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

   DECLARE @Product_FAQ_Id INT
   SELECT @Product_FAQ_Id=Product_FAQ_Id FROM tbl_Product_FAQ WHERE Product_FAQ_Id=@Product_FAQ_Id AND Is_Active=1

   IF @Product_FAQ_Id IS NULL 
   BEGIN
    --SELECT @Product_FAQ_Code = ('PF-') + (SELECT CAST(CONVERT(numeric(8,0),RAND() * 8999999) + 1000000 AS NVARCHAR))
           INSERT INTO tbl_Product_FAQ(Product_FAQ_Code,
                                            FK_Product_Id,
                                            Product_FAQ_Question,
                                            Product_FAQ_Answer,
                                            Created_By,
                                            Created_IP)
                                           VALUES(
                                            @Product_FAQ_Code,
                                            @FK_Product_Id,
                                            @Product_FAQ_Question,
                                            @Product_FAQ_Answer,
                                            @Created_By,
                                            @Created_IP)
    SELECT SCOPE_IDENTITY()
   END
   END    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Product FAQ FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
