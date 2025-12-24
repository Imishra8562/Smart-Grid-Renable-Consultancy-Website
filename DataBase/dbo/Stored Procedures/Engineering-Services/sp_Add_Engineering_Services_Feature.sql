CREATE PROCEDURE [dbo].[sp_Add_Engineering_Services_Feature]
@Engineering_Services_Applications_Code NVARCHAR(100) NULL,
@FK_Engineering_Services_Id INT NOT NULL,
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

AS
BEGIN
BEGIN TRY  

DECLARE @Engineering_Services_ApplicationsId INT
   SELECT @Engineering_Services_ApplicationsId=Engineering_Services_Applications_Id from tbl_Engineering_Services_Applications where Engineering_Services_Applications_Name=@Engineering_Services_Applications_Name AND Is_Active=1
	 IF @Engineering_Services_ApplicationsId IS NULL
      BEGIN
	  INSERT INTO tbl_Engineering_Services_Applications(
	  Engineering_Services_Applications_Code,
	  Engineering_Services_Applications_Name,
	  Engineering_Services_Applications_Description,
	  Engineering_Services_Applications_IconClass,
	  Created_By,Created_IP)
	  VALUES(
	  @Engineering_Services_Applications_Code,
	  @Engineering_Services_Applications_Name,
	  @Engineering_Services_Applications_Description,
	  @Engineering_Services_Applications_IconClass,
	  @Created_By,@Created_IP)
	  SELECT SCOPE_IDENTITY()
      END
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Engineering Services Applications FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
