CREATE PROCEDURE [dbo].[sp_List_Knowledge_FailureMode]
@Knowledge_Base_Id INT = NULL,
@Knowledge_FailureMode_Id INT = NULL
    
AS
BEGIN
    BEGIN TRY
        IF @Knowledge_Base_Id = 0 SET @Knowledge_Base_Id = NULL
        IF @Knowledge_FailureMode_Id = 0 SET @Knowledge_FailureMode_Id = NULL

        SELECT * FROM tbl_Knowledge_FailureMode KB
          INNER JOIN tbl_Knowledge_Base KC  ON KB.FK_Knowledge_Base_Id = KC.Knowledge_Base_Id
          WHERE KC.Knowledge_Base_Id = ISNULL(@Knowledge_Base_Id, KC.Knowledge_Base_Id) 
            AND KB.Knowledge_FailureMode_Id = ISNULL(@Knowledge_FailureMode_Id, KB.Knowledge_FailureMode_Id)
            AND KB.Is_Active = 1
          ORDER BY Knowledge_Base_Id
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Knowledge FailureMode FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
        RAISERROR (@ErrorMessage, 16, 1);   
    END CATCH    
END
