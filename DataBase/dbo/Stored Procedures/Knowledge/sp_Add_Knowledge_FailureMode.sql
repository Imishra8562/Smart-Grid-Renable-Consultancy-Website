CREATE PROCEDURE [dbo].[sp_Add_Knowledge_FailureMode]
@FK_Knowledge_Base_Id  INT=NULL,
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
	   
   DECLARE @Knowledge_FailureModeId INT
   SELECT @Knowledge_FailureModeId=Knowledge_FailureMode_Id from tbl_Knowledge_FailureMode where Knowledge_FailureMode_Code=@Knowledge_FailureMode_Code AND Is_Active=1
		 
   IF @Knowledge_FailureModeId IS NULL
      BEGIN
         INSERT INTO tbl_Knowledge_FailureMode(
		 FK_Knowledge_Base_Id,
		 Knowledge_FailureMode_Code ,        
		 Knowledge_FailureMode_Name,         
		 Knowledge_FailureMode_Title,        
		 Knowledge_FailureMode_Image ,       
		 Knowledge_FailureMode_Image_Alt_Tag,
		 Knowledge_FailureMode_Description,
		 Created_By,Created_IP)

		 VALUES(
		 @FK_Knowledge_Base_Id,
		 @Knowledge_FailureMode_Code ,        
		 @Knowledge_FailureMode_Name,         
		 @Knowledge_FailureMode_Title,        
		 @Knowledge_FailureMode_Image ,       
		 @Knowledge_FailureMode_Image_Alt_Tag,
		 @Knowledge_FailureMode_Description,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Knowledge FailureMode FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END