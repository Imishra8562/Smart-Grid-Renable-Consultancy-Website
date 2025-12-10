CREATE PROCEDURE [dbo].[sp_List_Knowledge_WorkflowStep]
@Knowledge_Base_Id INT = NULL,
@Knowledge_WorkflowStep_Id INT = NULL
    
AS
BEGIN
    BEGIN TRY
        IF @Knowledge_Base_Id = 0 SET @Knowledge_Base_Id = NULL
        IF @Knowledge_WorkflowStep_Id = 0 SET @Knowledge_WorkflowStep_Id = NULL

        SELECT * FROM tbl_Knowledge_Base KB
          INNER JOIN tbl_Knowledge_WorkflowStep KC  ON KC.FK_Knowledge_Base_Id = KB.Knowledge_Base_Id
          WHERE KB.Knowledge_Base_Id = ISNULL(@Knowledge_Base_Id, KB.Knowledge_Base_Id) 
            AND KC.Knowledge_WorkflowStep_Id = ISNULL(@Knowledge_WorkflowStep_Id, KC.Knowledge_WorkflowStep_Id)
            AND KB.Is_Active = 1
          ORDER BY Knowledge_Base_Id
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage VARCHAR(MAX); SELECT @ErrorMessage ='SP ERROR : LIST Knowledge WorkflowStep FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE();   
        RAISERROR (@ErrorMessage, 16, 1);   
    END CATCH    
END
