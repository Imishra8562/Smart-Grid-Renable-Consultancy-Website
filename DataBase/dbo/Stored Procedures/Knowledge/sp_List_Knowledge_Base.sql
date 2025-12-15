CREATE PROCEDURE [dbo].[sp_List_Knowledge_Base]
(
    @Knowledge_Base_Id INT = NULL,
    @Knowledge_Base_Category_Id INT = NULL,
    @Knowledge_Base_Url_Link NVARCHAR(MAX) = NULL
)
AS
BEGIN
    BEGIN TRY

        IF @Knowledge_Base_Id = 0 SET @Knowledge_Base_Id = NULL;
        IF @Knowledge_Base_Category_Id = 0 SET @Knowledge_Base_Category_Id = NULL;
        IF @Knowledge_Base_Url_Link = '' SET @Knowledge_Base_Url_Link = NULL;

        SELECT 
            I.*,
            C.Category_Name,
            C.Category_Description,
            C.Category_Url_Link
        FROM tbl_Knowledge_Base I
        INNER JOIN tbl_Knowledge_Base_Category C ON I.FK_Knowledge_Base_Category_Id = C.Knowledge_Base_Category_Id
        WHERE(@Knowledge_Base_Id IS NULL OR I.Knowledge_Base_Id = @Knowledge_Base_Id)
        AND (@Knowledge_Base_Category_Id IS NULL  OR I.FK_Knowledge_Base_Category_Id = @Knowledge_Base_Category_Id)
        AND (@Knowledge_Base_Url_Link IS NULL OR I.Knowledge_Base_Url_Link = @Knowledge_Base_Url_Link)
        AND I.Is_Active = 1
        AND C.Is_Active = 1
        ORDER BY I.Knowledge_Base_Id DESC;

    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(MAX);
        SET @ErrorMessage ='SP ERROR : LIST Knowledge Base FAILED' + CHAR(13) + CHAR(10) +ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END



