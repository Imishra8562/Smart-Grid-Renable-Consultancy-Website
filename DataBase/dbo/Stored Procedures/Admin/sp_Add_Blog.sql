CREATE PROCEDURE [dbo].[sp_Add_Blog]
@FK_Blog_Category_Id INT= NULL,
@Blog_Code NVARCHAR (MAX) = NULL ,
@Page_Title  NVARCHAR(MAX)= NULL,
@Meta_Keyword NVARCHAR(MAX)= NULL,
@Meta_Description NVARCHAR(MAX)= NULL,
@News_Keyword NVARCHAR(MAX)= NULL,
@News_Description NVARCHAR(MAX)= NULL,
@Og_Title NVARCHAR(MAX) =NULL,
@Og_Description NVARCHAR(MAX)= NULL,
@Meta_Og_Image NVARCHAR(MAX)= NULL,
@Blog_Image NVARCHAR(MAX)= NULL,
@Meta_Alt_tag NVARCHAR(MAX)= NULL,
@Blog_Heading NVARCHAR(MAX)= NULL,
@Blog_Description NVARCHAR(MAX)= NULL,
@Blog_Link NVARCHAR(MAX)= NULL,


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

   DECLARE @Blog_Id INT
   SELECT @Blog_Id=Blog_Id FROM tbl_Blog WHERE Blog_Id=@Blog_Id AND Is_Active=1

   IF @Blog_Id IS NULL 
   BEGIN
                       INSERT INTO tbl_Blog(
                                            FK_Blog_Category_Id,
                                            Blog_Code,
                                            Page_Title,
                                            Meta_Keyword,
                                            Meta_Description,
                                            News_Keyword,
                                            News_Description,
                                            Og_Title,
                                            Og_Description,
                                            Meta_Og_Image,
                                            Blog_Image,
                                            Meta_Alt_tag,
                                            Blog_Heading,
                                            Blog_Description,
                                            Blog_Link,
                                            Created_By,
                                            Created_IP)
                                           VALUES(
                                          @FK_Blog_Category_Id,
                                            @Blog_Code,
                                            @Page_Title,
                                            @Meta_Keyword,
                                            @Meta_Description,
                                            @News_Keyword,
                                            @News_Description,
                                            @Og_Title,
                                            @Og_Description,
                                            @Meta_Og_Image,
                                            @Blog_Image,
                                            @Meta_Alt_tag,
                                            @Blog_Heading,
                                            @Blog_Description,
                                            REPLACE(@Blog_Link, ' ', '-'),
                                            @Created_By,
                                            @Created_IP)
    SELECT SCOPE_IDENTITY()
   END
   END    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
