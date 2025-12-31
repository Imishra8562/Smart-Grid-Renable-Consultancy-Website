CREATE PROCEDURE [dbo].[sp_Update_Engineering_Services_Gallery]
@Engineering_Services_Gallery_Id INT=NULL,
@FK_Engineering_Services_Id INT=NULL,
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
	  UPDATE tbl_Engineering_Services_Gallery SET 
				 FK_Engineering_Services_Id = @FK_Engineering_Services_Id,
				 Engineering_Services_Gallery_Image = @Engineering_Services_Gallery_Image,
				 Engineering_Services_Gallery_Image_Code = @Engineering_Services_Gallery_Image_Code,
				 Engineering_Services_Gallery_AltText = @Engineering_Services_Gallery_AltText,
				 Modified_On = @Modified_On,
				 Modified_By = @Modified_By,
				 Modified_IP = @Modified_IP
		 WHERE Engineering_Services_Gallery_Id = @Engineering_Services_Gallery_Id;
		 SELECT @Engineering_Services_Gallery_Id
	END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Engineering Services Gallery FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END