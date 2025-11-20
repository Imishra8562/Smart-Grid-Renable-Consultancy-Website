CREATE PROCEDURE [dbo].[sp_Update_Index_Services]
@FK_Index_Seo_Id INT=NULL,
@Index_Services_Id               INT=NULL,
@Index_Services_Code          NVARCHAR(MAX)=NULL, 
@Index_Services_Icon          NVARCHAR(MAX)=NULL,
@Index_Services_Title         NVARCHAR(MAX)=NULL,
@Index_Services_Description   NVARCHAR(MAX)=NULL,

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
         UPDATE tbl_Index_Services SET 
         FK_Index_Seo_Id =@FK_Index_Seo_Id ,
         Index_Services_Icon         =@Index_Services_Icon        ,
         Index_Services_Title        =@Index_Services_Title       ,
         Index_Services_Description  =@Index_Services_Description ,
		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By

		WHERE Index_Services_Id=@Index_Services_Id 
        SELECT @Index_Services_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Index Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
