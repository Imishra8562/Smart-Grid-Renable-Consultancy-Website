CREATE PROCEDURE [dbo].[sp_Add_Engineering_Services_SubTopic]
@FK_Engineering_Services_Id INT NOT NULL,
@Engineering_Services_SubTopic_Code NVARCHAR(100)=NULL,
@Engineering_Services_SubTopic_Name NVARCHAR(200)=NULL,
@Engineering_Services_SubTopic_Description NVARCHAR(MAX)=NULL,

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
   DECLARE @Engineering_Services_SubTopicId INT
   SELECT @Engineering_Services_SubTopicId=Engineering_Services_SubTopic_Id from tbl_Engineering_Services_SubTopic where Engineering_Services_SubTopic_Name=@Engineering_Services_SubTopic_Name AND Is_Active=1
		
   IF @Engineering_Services_SubTopicId IS NULL
	  BEGIN
		 INSERT INTO tbl_Engineering_Services_SubTopic(
		 FK_Engineering_Services_Id,
		 Engineering_Services_SubTopic_Code,
		 Engineering_Services_SubTopic_Name,
		 Engineering_Services_SubTopic_Description,
		 Created_By,Created_IP)
		 VALUES(
		 @FK_Engineering_Services_Id,
		 @Engineering_Services_SubTopic_Code,
		 @Engineering_Services_SubTopic_Name,
		 @Engineering_Services_SubTopic_Description,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
	  END
END TRY
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Engineering Services SubTopic FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END