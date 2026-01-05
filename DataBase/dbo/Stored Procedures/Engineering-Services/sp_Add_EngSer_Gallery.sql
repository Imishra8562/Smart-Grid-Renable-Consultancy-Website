CREATE PROCEDURE [dbo].[sp_Add_EngSer_Gallery]
@FK_Engineering_Services_Id INT=NULL,
@EngSer_Gallery_Code         NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Image_Url        NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Title        NVARCHAR(MAX)=NULL, 
@EngSer_Gallery_Description NVARCHAR(MAX)=NULL,

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN
BEGIN TRY 
    DECLARE @EngSer_GalleryId INT
     SELECT @EngSer_GalleryId = EngSer_Gallery_Id FROM tbl_EngSer_Gallery where EngSer_Gallery_Code=@EngSer_Gallery_Code AND @Is_Active=1
     IF @EngSer_GalleryId IS NULL
     BEGIN
        INSERT INTO tbl_EngSer_Gallery (FK_Engineering_Services_Id,EngSer_Gallery_Code,EngSer_Gallery_Title,EngSer_Gallery_Description,EngSer_Gallery_Image_Url,
        Created_By,Created_IP)
        VALUES(@FK_Engineering_Services_Id,@EngSer_Gallery_Code,@EngSer_Gallery_Title,@EngSer_Gallery_Description,@EngSer_Gallery_Image_Url,
        @Created_By,@Created_IP)
        SELECT SCOPE_IDENTITY()
     END
END TRY
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD EngSer Gallery FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END