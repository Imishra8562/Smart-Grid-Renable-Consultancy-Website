CREATE PROCEDURE [dbo].[sp_List_Engineering_Services_Applications]
	@Engineering_Services_Id INT=NULL,
	@Engineering_Services_Applications_Id INT=NULL
AS
BEGIN
BEGIN TRY
	IF @Engineering_Services_Applications_Id=0 SET @Engineering_Services_Applications_Id = NULL ;
	IF  @Engineering_Services_Id=0 SET @Engineering_Services_Id = NULL;

	SELECT * FROM tbl_Engineering_Services_Applications ESA
	 INNER JOIN tbl_Engineering_Services ES ON ESA.FK_Engineering_Services_Id=ES.Engineering_Services_Id
	 WHERE 
	 ESA.Engineering_Services_Applications_Id=ISNULL(@Engineering_Services_Applications_Id,ESA.Engineering_Services_Applications_Id)
	 AND ESA.FK_Engineering_Services_Id=ISNULL(@Engineering_Services_Id,ESA.FK_Engineering_Services_Id)
	 AND ESA.Is_Active=1 ORDER BY Engineering_Services_Applications_Id;
END TRY
	 BEGIN CATCH
		 DECLARE @ErrorMessage NVARCHAR(MAX);
		 SET @ErrorMessage ='SP ERROR: LIST Engineering Services Applications FAILED' + CHAR(13) + CHAR(10) +'ERROR: ' + ERROR_MESSAGE();
		 RAISERROR (@ErrorMessage, 16, 1);
END CATCH
END

--(
--    @Engineering_Services_Features_Id INT = NULL,
--    @Engineering_Services_Id INT = NULL
--)
--AS
--BEGIN
--    BEGIN TRY
--        IF @Engineering_Services_Features_Id = 0 SET @Engineering_Services_Features_Id = NULL;
--        IF @Engineering_Services_Id = 0 SET @Engineering_Services_Id = NULL;

--        SELECT * FROM tbl_Engineering_Services_Features ESF
--        INNER JOIN tbl_Engineering_Services ES ON ESF.FK_Engineering_Services_Id = ES.Engineering_Services_Id
--        WHERE
--            ESF.Engineering_Services_Features_Id =ISNULL(@Engineering_Services_Features_Id, ESF.Engineering_Services_Features_Id)
--            AND ESF.FK_Engineering_Services_Id =ISNULL(@Engineering_Services_Id, ESF.FK_Engineering_Services_Id)
--            AND ESF.Is_Active = 1 ORDER BY Engineering_Services_Features_Id;
--    END TRY
--    BEGIN CATCH
--        DECLARE @ErrorMessage NVARCHAR(MAX);
--        SET @ErrorMessage ='SP ERROR: LIST Engineering Services Features FAILED' + CHAR(13) + CHAR(10) +'ERROR: ' + ERROR_MESSAGE();
--        RAISERROR (@ErrorMessage, 16, 1);
--    END CATCH
--END
