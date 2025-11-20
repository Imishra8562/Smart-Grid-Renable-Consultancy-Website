CREATE PROCEDURE [dbo].[sp_List_Index_Slider]
@Index_Slider_Id INT = NULL,
@Index_Seo_Id INT = NULL
    
AS
BEGIN
    BEGIN TRY
        IF @Index_Slider_Id = 0 SET @Index_Slider_Id = NULL
        IF @Index_Seo_Id = 0 SET @Index_Seo_Id = NULL

        SELECT * FROM tbl_Index_Slider F
        INNER JOIN tbl_Index_Seo S ON F.FK_Index_Seo_Id = S.Index_Seo_Id
        WHERE F.Index_Slider_Id = ISNULL(@Index_Slider_Id, F.Index_Slider_Id) 
        AND F.FK_Index_Seo_Id = ISNULL(@Index_Seo_Id, F.FK_Index_Seo_Id)             
        AND F.Is_Active=1 ORDER BY Index_Slider_Id
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Index Slider FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
        RAISERROR (@ErrorMessage, 16, 1);   
    END CATCH    
END
