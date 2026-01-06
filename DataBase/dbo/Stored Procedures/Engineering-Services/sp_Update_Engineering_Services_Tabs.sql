CREATE PROCEDURE [dbo].[sp_Update_Engineering_Services_Tabs]
@Engineering_Services_Tabs_Id INT=NULL,
@FK_Engineering_Services_Id INT=NULL,
@Engineering_Services_Tabs_Title NVARCHAR(200)=NULL,
@Engineering_Services_Tabs_Content NVARCHAR(MAX)=NULL,
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
	  UPDATE tbl_Engineering_Services_Tabs SET 
				 FK_Engineering_Services_Id = @FK_Engineering_Services_Id,
				 Engineering_Services_Tabs_Title = @Engineering_Services_Tabs_Title,
				 Engineering_Services_Tabs_Content = @Engineering_Services_Tabs_Content,
	             Modified_On=@Modified_On,
                 Modified_IP=@Modified_IP,
                 Modified_By=@Modified_By
		 WHERE Engineering_Services_Tabs_Id = @Engineering_Services_Tabs_Id;
		 SELECT @Engineering_Services_Tabs_Id
	END TRY
	BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
	SELECT @ErrorMessage ='SP ERROR : UPDATE Engineering Services Tab FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)
	END CATCH
	END