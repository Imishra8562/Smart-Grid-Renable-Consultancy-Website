CREATE PROCEDURE [dbo].[sp_Update_Demo_Follow_Up]
@Demo_Follow_Up_Id INT=NULL,
@Demo_Follow_Up_Code NVARCHAR(MAX)=NULL,
@FK_Software_Demo_Id INT=NULL,
@Demo_Follow_Up_By NVARCHAR(MAX)=NULL,
@Query_Response NVARCHAR(MAX)=NULL,
@Next_Follow_Date NVARCHAR(MAX)=NULL,
@Next_Follow_Time NVARCHAR(MAX)=NULL,
@Description NVARCHAR(MAX)=NULL,

@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN    
 BEGIN TRY   

   BEGIN
  
    UPDATE tbl_Demo_Follow_Up SET FK_Software_Demo_Id=@FK_Software_Demo_Id,
                                    Demo_Follow_Up_By=TRIM(LTRIM(RTRIM(UPPER(@Demo_Follow_Up_By)))),
                                    Query_Response=@Query_Response,
                                    Description=@Description,
                          Modified_By=@Modified_By,
                          Modified_On=GETDATE(),
                          Modified_IP=@Modified_IP                  
                    WHERE Demo_Follow_Up_Id=@Demo_Follow_Up_Id

    SELECT @Demo_Follow_Up_Id

   END
    
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE DEMO FOLLOW UP FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END