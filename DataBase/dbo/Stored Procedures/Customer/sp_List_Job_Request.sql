CREATE PROCEDURE [dbo].[sp_List_Job_Request]
@Job_Request_Id INT=NULL

AS
BEGIN    
 BEGIN TRY   

      IF @Job_Request_Id=0 SET @Job_Request_Id=NULL
      
      SELECT * FROM tbl_Job_Request WHERE Job_Request_Id=ISNULL(@Job_Request_Id,Job_Request_Id) AND Is_Active=1 ORDER BY Job_Request_Id DESC

 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Job_Request FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END