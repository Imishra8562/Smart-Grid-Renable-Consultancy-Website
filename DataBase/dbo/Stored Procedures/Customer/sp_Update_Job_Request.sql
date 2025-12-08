CREATE PROCEDURE [dbo].[sp_Update_Job_Request]
@Job_Request_Id INT=NULL,
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Upload_Resume NVARCHAR(MAX)=NULL,
@Job_Position NVARCHAR(MAX)=NULL,
@Message NVARCHAR(MAX)=NULL,
@Description NVARCHAR(MAX)=NULL,


@Created_On DATETIME=NULL,
@Created_By INT=NULL,
@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Created_IP NVARCHAR(MAX)=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN
BEGIN TRY  
	   
   UPDATE tbl_Job_Request SET Description=@Description,

                                            
                         Modified_On=GETDATE(),
                         Modified_IP=@Modified_IP,
                         Modified_By=@Modified_By
                   WHERE Job_Request_Id=@Job_Request_Id
   SELECT @Job_Request_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Job Request FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
