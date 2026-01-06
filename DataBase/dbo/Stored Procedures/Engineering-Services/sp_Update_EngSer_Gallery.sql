CREATE PROCEDURE [dbo].[sp_Update_EngSer_Gallery]
@FK_Engineering_Services_Id INT=NULL,
@EngSer_Gallery_Id INT=NULL,
@EngSer_Gallery_Code         NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Image_Url    NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Title        NVARCHAR(MAX)=NULL, 
@EngSer_Gallery_Description NVARCHAR(MAX)=NULL,

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL
As
BEGIN
BEGIN TRY
        UPDATE tbl_EngSer_Gallery SET 
                 FK_Engineering_Services_Id = @FK_Engineering_Services_Id,
                 EngSer_Gallery_Image_Url = @EngSer_Gallery_Image_Url,
                 EngSer_Gallery_Title = @EngSer_Gallery_Title,
                 EngSer_Gallery_Description = @EngSer_Gallery_Description,
                 Modified_On = @Modified_On,
                 Modified_By = @Modified_By,
                 Modified_IP = @Modified_IP
        WHERE EngSer_Gallery_Id = @EngSer_Gallery_Id;
        Select @EngSer_Gallery_Id
END TRY
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Engineering Services Gallery FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END