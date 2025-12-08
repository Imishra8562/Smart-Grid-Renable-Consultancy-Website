CREATE PROCEDURE [dbo].[sp_Update_Client]
@Client_Id INT=NULL,
@Client_Code NVARCHAR(MAX)=NULL,
@FK_Product_Id INT=NULL,
@Client_Name NVARCHAR(MAX)=NULL,
@Client_Designation NVARCHAR(MAX)=NULL,
@Company_Logo NVARCHAR(MAX)=NULL,
@Company_Name NVARCHAR(MAX)=NULL,
@Client_Text_Description NVARCHAR(MAX)=NULL,
@Client_Video_Thumbnail NVARCHAR(MAX)=NULL,
@Client_Video_Description NVARCHAR(MAX)=NULL,

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
	   
   UPDATE tbl_Client SET FK_Product_Id=@FK_Product_Id,
                         Client_Name=@Client_Name,
                         Company_Logo=@Company_Logo,
                         Client_Designation=@Client_Designation,
                         Company_Name=@Company_Name,
                         Client_Text_Description=@Client_Text_Description,
                         Client_Video_Thumbnail=@Client_Video_Thumbnail,
                         Client_Video_Description=@Client_Video_Description,
                                          
                         Modified_On=@Modified_On,
                         Modified_IP=@Modified_IP,
                         Modified_By=@Modified_By
                   WHERE Client_Id=@Client_Id
   SELECT @Client_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Client FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
