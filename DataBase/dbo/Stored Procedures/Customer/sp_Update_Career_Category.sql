CREATE PROCEDURE [dbo].[sp_Update_Career_Category]
@Career_Category_Id INT=NULL,
@Career_Category_Title NVARCHAR(MAX)=NULL,  
@Career_Category_Code  NVARCHAR(MAX)=NULL,  
@Career_Category_Image NVARCHAR(MAX)=NULL,  
@Career_Category_Description NVARCHAR(MAX)=NULL , 

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
        UPDATE tbl_Career_Category SET
        Career_Category_Title = @Career_Category_Title ,
        Career_Category_Code  = @Career_Category_Code , 
        Career_Category_Image = @Career_Category_Image ,
        Career_Category_Description = @Career_Category_Description,
        Modified_On=GETDATE(),
        Modified_IP=@Modified_IP,
        Modified_By=@Modified_By
        WHERE Career_Category_Id=@Career_Category_Id
        SELECT @Career_Category_Id
        END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE @areer Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
