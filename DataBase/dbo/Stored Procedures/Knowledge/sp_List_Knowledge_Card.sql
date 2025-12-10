CREATE PROCEDURE [dbo].[sp_List_Knowledge_Card]
@Knowledge_Base_Id INT = NULL,
@Knowledge_Card_Id INT = NULL
    
AS
BEGIN
    BEGIN TRY
        IF @Knowledge_Base_Id = 0 SET @Knowledge_Base_Id = NULL
        IF @Knowledge_Card_Id = 0 SET @Knowledge_Card_Id = NULL

        SELECT * FROM tbl_Knowledge_Card KB
          INNER JOIN tbl_Knowledge_Base KC  ON KB.FK_Knowledge_Base_Id = KC.Knowledge_Base_Id
          WHERE KC.Knowledge_Base_Id = ISNULL(@Knowledge_Base_Id, KC.Knowledge_Base_Id) 
            AND KB.Knowledge_Card_Id = ISNULL(@Knowledge_Card_Id, KB.Knowledge_Card_Id)
            AND KB.Is_Active = 1
          ORDER BY Knowledge_Base_Id
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Knowledge Card FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
        RAISERROR (@ErrorMessage, 16, 1);   
    END CATCH    
END



