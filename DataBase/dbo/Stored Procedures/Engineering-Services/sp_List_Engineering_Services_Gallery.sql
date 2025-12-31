CREATE PROCEDURE [dbo].[sp_List_Engineering_Services_Gallery]
	@Engineering_Services_Id INT=NULL,
	@Engineering_Services_Gallery_Id INT=NULL
AS
BEGIN
BEGIN TRY
	IF @Engineering_Services_Gallery_Id=0 SET @Engineering_Services_Gallery_Id = NULL ;
	IF  @Engineering_Services_Id=0 SET @Engineering_Services_Id = NULL;
	SELECT * FROM tbl_Engineering_Services_Gallery ESG
	 INNER JOIN tbl_Engineering_Services ES ON ESG.FK_Engineering_Services_Id=ES.Engineering_Services_Id
	 WHERE 
	 ESG.Engineering_Services_Gallery_Id=ISNULL(@Engineering_Services_Gallery_Id,ESG.Engineering_Services_Gallery_Id)
	 AND ESG.FK_Engineering_Services_Id=ISNULL(@Engineering_Services_Id,ESG.FK_Engineering_Services_Id)
	 AND ESG.Is_Active=1 ORDER BY Engineering_Services_Gallery_Id;
END TRY
	 BEGIN CATCH
		 DECLARE @ErrorMessage NVARCHAR(MAX);
		 SET @ErrorMessage ='SP ERROR: LIST Engineering Services Gallery FAILED' + CHAR(13) + CHAR(10) +'ERROR: ' + ERROR_MESSAGE();
		 RAISERROR (@ErrorMessage, 16, 1);
END CATCH
END