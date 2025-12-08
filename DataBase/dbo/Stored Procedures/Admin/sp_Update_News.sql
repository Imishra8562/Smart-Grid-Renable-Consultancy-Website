CREATE PROCEDURE [dbo].[sp_Update_News]
@News_Id INT=NULL,
@News_Code NVARCHAR(MAX)=NULL,
@News_Image NVARCHAR(MAX)=NULL,
@News_Description NVARCHAR(Max)=NULL,

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
	   
   UPDATE tbl_News SET News_Image=@News_Image,
                       News_Description=@News_Description,
                                          
                       Modified_On=@Modified_On,
                       Modified_IP=@Modified_IP,
                       Modified_By=@Modified_By
                 WHERE News_Id=@News_Id
   SELECT @News_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE News FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
