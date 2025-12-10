CREATE PROCEDURE [dbo].[sp_Update_Knowledge_Card]
@FK_Knowledge_Base_Id INT=NULL,
@Knowledge_Card_Id    INT=NULL,
@Knowledge_Card_Code          NVARCHAR(MAX)=NULL,
@Knowledge_Card_Name          NVARCHAR(MAX)=NULL,
@Knowledge_Card_Title         NVARCHAR(MAX)=NULL,
@Knowledge_Card_Image         NVARCHAR(MAX)=NULL,
@Knowledge_Card_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_Card_Description   NVARCHAR(MAX)=NULL,

@Modified_On DATETIME=NULL,
@Modified_By INT=NULL,
@Modified_IP NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL

AS
BEGIN
BEGIN TRY  
 UPDATE tbl_Knowledge_Card SET 
         FK_Knowledge_Base_Id =@FK_Knowledge_Base_Id,      
		 Knowledge_Card_Name =@Knowledge_Card_Name,         
		 Knowledge_Card_Title =@Knowledge_Card_Title,      
		 Knowledge_Card_Image =@Knowledge_Card_Image ,   
		 Knowledge_Card_Image_Alt_Tag =@Knowledge_Card_Image_Alt_Tag,
		 Knowledge_Card_Description=@Knowledge_Card_Description,
   		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By
		 WHERE Knowledge_Card_Id=@Knowledge_Card_Id 
        SELECT @Knowledge_Card_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Knowledge Card FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END