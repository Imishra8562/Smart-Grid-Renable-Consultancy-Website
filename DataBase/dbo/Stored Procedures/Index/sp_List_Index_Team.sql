CREATE PROCEDURE [dbo].[sp_List_Index_Team]
@Index_Team_Id INT = NULL,
@Index_Seo_Id INT = NULL
    
AS
BEGIN
    BEGIN TRY
        IF @Index_Team_Id = 0 SET @Index_Team_Id = NULL
        IF @Index_Seo_Id = 0 SET @Index_Seo_Id = NULL

        SELECT * FROM tbl_Index_Team F
        INNER JOIN tbl_Index_Seo S ON F.FK_Index_Seo_Id = S.Index_Seo_Id
        WHERE F.Index_Team_Id = ISNULL(@Index_Team_Id, F.Index_Team_Id) 
        AND F.FK_Index_Seo_Id = ISNULL(@Index_Seo_Id, F.FK_Index_Seo_Id)             
        AND F.Is_Active=1 ORDER BY Index_Team_Id
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Index Team FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
        RAISERROR (@ErrorMessage, 16, 1);   
    END CATCH    
END
