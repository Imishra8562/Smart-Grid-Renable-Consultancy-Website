CREATE PROCEDURE [dbo].[sp_Add_Engineering_Services_Gallery]
@FK_Engineering_Services_Id INT NOT NULL,
@Engineering_Services_Gallery_Image NVARCHAR(500)=NULL,
@Engineering_Services_Gallery_Image_Code NVARCHAR(100)=NULL,
@Engineering_Services_Gallery_AltText NVARCHAR(500)=NULL,	

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

DECLARE @Engineering_Services_GalleryId INT
   SELECT @Engineering_Services_GalleryId=Engineering_Services_Gallery_Id from tbl_Engineering_Services_Gallery where Engineering_Services_Gallery_Image_Code=@Engineering_Services_Gallery_Image_Code AND Is_Active=1
	 IF @Engineering_Services_GalleryId IS NULL
      BEGIN
	  INSERT INTO tbl_Engineering_Services_Gallery(
	  FK_Engineering_Services_Id,
	  Engineering_Services_Gallery_Image,
	  Engineering_Services_Gallery_Image_Code,
	  Engineering_Services_Gallery_AltText,
	  Created_By,Created_IP)
	  VALUES(
	  @FK_Engineering_Services_Id,
	  @Engineering_Services_Gallery_Image,
	  @Engineering_Services_Gallery_Image_Code,
	  @Engineering_Services_Gallery_AltText,
	  @Created_By,@Created_IP)
	  SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Engineering Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END