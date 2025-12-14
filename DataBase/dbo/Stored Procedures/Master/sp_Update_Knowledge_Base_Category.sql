CREATE PROCEDURE [dbo].[sp_Update_Knowledge_Base_Category]
@Knowledge_Base_Category_Id INT=NULL,
@Category_Name NVARCHAR(MAX)=NULL,
@Category_Description NVARCHAR(Max)=NULL,

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
	   
   UPDATE tbl_Knowledge_Base_Category SET 
                                Category_Name=@Category_Name,
                                Category_Description=@Category_Description,
                                Modified_On=@Modified_On,
                                Modified_IP=@Modified_IP,
                                Modified_By=@Modified_By
                          WHERE Knowledge_Base_Category_Id=@Knowledge_Base_Category_Id

   SELECT @Knowledge_Base_Category_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Knowledge_Base_Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
