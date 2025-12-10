CREATE PROCEDURE [dbo].[sp_Update_Knowledge_FailureMode]
@FK_Knowledge_Base_Id INT=NULL,
@Knowledge_FailureMode_Id    INT=NULL,
@Knowledge_FailureMode_Code          NVARCHAR(MAX)=NULL,
@Knowledge_FailureMode_Name          NVARCHAR(MAX)=NULL,
@Knowledge_FailureMode_Title         NVARCHAR(MAX)=NULL,
@Knowledge_FailureMode_Image         NVARCHAR(MAX)=NULL,
@Knowledge_FailureMode_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_FailureMode_Description   NVARCHAR(MAX)=NULL,

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
 UPDATE tbl_Knowledge_FailureMode SET 
         FK_Knowledge_Base_Id =@FK_Knowledge_Base_Id,      
		 Knowledge_FailureMode_Name =@Knowledge_FailureMode_Name,         
		 Knowledge_FailureMode_Title =@Knowledge_FailureMode_Title,      
		 Knowledge_FailureMode_Image =@Knowledge_FailureMode_Image ,   
		 Knowledge_FailureMode_Image_Alt_Tag =@Knowledge_FailureMode_Image_Alt_Tag,
		 Knowledge_FailureMode_Description=@Knowledge_FailureMode_Description,
   		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By
		 WHERE Knowledge_FailureMode_Id=@Knowledge_FailureMode_Id 
        SELECT @Knowledge_FailureMode_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Failure Mode FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END