CREATE PROCEDURE [dbo].[sp_List_EngSer_Gallery]
	@EngSer_Gallery_Id INT = NULL,
	@Engineering_Services_Id INT = NULL
AS
BEGIN
 BEGIN TRY
		IF @EngSer_Gallery_Id = 0 SET @EngSer_Gallery_Id = NULL
		IF @Engineering_Services_Id = 0 SET @Engineering_Services_Id = NULL
		SELECT * FROM tbl_EngSer_Gallery G
		INNER JOIN tbl_Engineering_Services S ON G.FK_Engineering_Services_Id = S.Engineering_Services_Id
		WHERE G.EngSer_Gallery_Id = ISNULL(@EngSer_Gallery_Id, G.EngSer_Gallery_Id)
		AND G.FK_Engineering_Services_Id = ISNULL(@Engineering_Services_Id, G.FK_Engineering_Services_Id)
		AND G.Is_Active=1 ORDER BY EngSer_Gallery_Id
	END TRY
	BEGIN CATCH
		DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Engineering Services Gallery FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
		RAISERROR (@ErrorMessage, 16, 1);   
	END CATCH    
END