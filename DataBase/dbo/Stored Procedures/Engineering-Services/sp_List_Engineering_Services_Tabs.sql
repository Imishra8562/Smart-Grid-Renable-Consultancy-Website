CREATE PROCEDURE [dbo].[sp_List_Engineering_Services_Tabs]
	@Engineering_Services_Id INT=NULL,
	@Engineering_Services_Tabs_Id INT=NULL
AS
BEGIN
BEGIN TRY
	IF @Engineering_Services_Tabs_Id=0 SET @Engineering_Services_Tabs_Id = NULL ;
	IF  @Engineering_Services_Id=0 SET @Engineering_Services_Id = NULL;
	SELECT * FROM tbl_Engineering_Services_Tabs EST
	 INNER JOIN tbl_Engineering_Services ES ON EST.FK_Engineering_Services_Id=ES.Engineering_Services_Id
	 WHERE 
	 EST.Engineering_Services_Tabs_Id=ISNULL(@Engineering_Services_Tabs_Id,EST.Engineering_Services_Tabs_Id)
	 AND EST.FK_Engineering_Services_Id=ISNULL(@Engineering_Services_Id,EST.FK_Engineering_Services_Id)
	 AND EST.Is_Active=1 ORDER BY Engineering_Services_Tabs_Id;
END TRY
	 BEGIN CATCH
		 DECLARE @ErrorMessage NVARCHAR(MAX);
		 SET @ErrorMessage ='SP ERROR: LIST Engineering Services Tabs FAILED' + CHAR(13) + CHAR(10) +'ERROR: ' + ERROR_MESSAGE();
		 RAISERROR (@ErrorMessage, 16, 1);
END CATCH
END
