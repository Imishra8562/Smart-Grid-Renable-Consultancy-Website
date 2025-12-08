CREATE PROCEDURE [dbo].[sp_Update_Contact]
@Contact_Id INT=NULL,
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Website NVARCHAR(MAX)=NULL,
@Subject NVARCHAR(MAX)=NULL,
@Message NVARCHAR(MAX)=NULL,
@Review NVARCHAR(MAX)=NULL,

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
	   
   UPDATE tbl_Contact SET Review=@Review,

                                            
                         Modified_On=GETDATE(),
                         Modified_IP=@Modified_IP,
                         Modified_By=@Modified_By
                   WHERE Contact_Id=@Contact_Id
   SELECT @Contact_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Contact FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
