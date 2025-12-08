CREATE PROCEDURE [dbo].[sp_Add_Blog_FAQ]
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

   DECLARE @Blog_FAQ_Id INT
   SELECT @Blog_FAQ_Id=Blog_FAQ_Id FROM tbl_Blog_FAQ WHERE Blog_FAQ_Id=@Blog_FAQ_Id AND Is_Active=1

   IF @Blog_FAQ_Id IS NULL 
   BEGIN
    SELECT @Blog_FAQ_Code = ('BF-') + (SELECT CAST(CONVERT(numeric(8,0),RAND() * 8999999) + 1000000 AS NVARCHAR))
                  INSERT INTO tbl_Blog_FAQ(       
                                           Blog_FAQ_Code,
                                           FK_Blog_Id,
                                           Blog_FAQ_Question,
                                           Blog_FAQ_Answer,
                                           Created_By,
                                           Created_IP)
                                           VALUES(
                                           @Blog_FAQ_Code,
                                           @FK_Blog_Id,
                                           @Blog_FAQ_Question,
                                           @Blog_FAQ_Answer,
                                           @Created_By,
                                           @Created_IP)
    SELECT SCOPE_IDENTITY()
   END
   END    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Blog FAQ FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
