CREATE PROCEDURE [dbo].[sp_Update_Event_Detail]
@Event_Detail_Id INT=NULL,
@FK_Event_Id INT=NULL,
@Event_Code NVARCHAR(MAX)=NULL,
@Event_Image NVARCHAR(MAX)=NULL,
@Description NVARCHAR(Max)=NULL,


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
	   
   UPDATE tbl_Event_Detail SET FK_Event_Id=@FK_Event_Id,
                               Event_Image=@Event_Image,
                               Description=@Description,
                                          
                               Modified_On=@Modified_On,
                               Modified_IP=@Modified_IP,
                               Modified_By=@Modified_By
                         WHERE Event_Detail_Id=@Event_Detail_Id
   SELECT @Event_Detail_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Event_Detail FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
