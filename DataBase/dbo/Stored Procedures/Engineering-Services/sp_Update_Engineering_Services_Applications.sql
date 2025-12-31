CREATE PROCEDURE [dbo].[sp_Update_Engineering_Services_Applications]
@Engineering_Services_Applications_Id INT=NULL,
@FK_Engineering_Services_Id INT=NULL,
@Engineering_Services_Applications_Name NVARCHAR(300)=NULL,
@Engineering_Services_Applications_Description NVARCHAR(MAX)=NULL,
@Engineering_Services_Applications_IconClass NVARCHAR(200)=NULL,

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
	UPDATE tbl_Engineering_Services_Applications SET 
	         FK_Engineering_Services_Id = @FK_Engineering_Services_Id,
	         Engineering_Services_Applications_Name = @Engineering_Services_Applications_Name,
	         Engineering_Services_Applications_Description = @Engineering_Services_Applications_Description,
	         Engineering_Services_Applications_IconClass = @Engineering_Services_Applications_IconClass,
	         Modified_On = @Modified_On,
	         Modified_By = @Modified_By,
	         Modified_IP = @Modified_IP
    WHERE Engineering_Services_Applications_Id = @Engineering_Services_Applications_Id;
	SELECT @Engineering_Services_Applications_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Engineering Services  Applications FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END