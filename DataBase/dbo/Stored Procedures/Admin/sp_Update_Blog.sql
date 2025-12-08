CREATE PROCEDURE [dbo].[sp_Update_Blog]
@Blog_Id INT=NULL,
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
    UPDATE tbl_Blog SET
                          FK_Blog_Category_Id=@FK_Blog_Category_Id,                       
                          Page_Title=@Page_Title,
                          Meta_Keyword=@Meta_Keyword,
                          Meta_Description=@Meta_Description,
                          News_Keyword=@News_Keyword,
                          News_Description=@News_Description,
                          Og_Title=@Og_Title,
                          Og_Description=@Og_Description,
                          Meta_Og_Image=@Meta_Og_Image,
                          Blog_Image=@Blog_Image,
                          Meta_Alt_tag=@Meta_Alt_tag,
                          Blog_Heading=@Blog_Heading,
                          Blog_Description=@Blog_Description,
                          Blog_Link=REPLACE(@Blog_Link, ' ', '-'),
                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Blog_Id=@Blog_Id
    SELECT @Blog_Id
   END   
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END