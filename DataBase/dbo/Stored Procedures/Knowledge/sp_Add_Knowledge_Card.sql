CREATE PROCEDURE [dbo].[sp_Add_Knowledge_Card]
@FK_Knowledge_Base_Id  INT=NULL,
@Knowledge_Card_Code          NVARCHAR(MAX)=NULL,
@Knowledge_Card_Name          NVARCHAR(MAX)=NULL,
@Knowledge_Card_Title         NVARCHAR(MAX)=NULL,
@Knowledge_Card_Image         NVARCHAR(MAX)=NULL,
@Knowledge_Card_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_Card_Description   NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Knowledge_CardId INT
   SELECT @Knowledge_CardId=Knowledge_Card_Id from tbl_Knowledge_Card where Knowledge_Card_Code=@Knowledge_Card_Code AND Is_Active=1
		 
   IF @Knowledge_CardId IS NULL
      BEGIN
         INSERT INTO tbl_Knowledge_Card(
		 FK_Knowledge_Base_Id,
		 Knowledge_Card_Code ,        
		 Knowledge_Card_Name,         
		 Knowledge_Card_Title,        
		 Knowledge_Card_Image ,       
		 Knowledge_Card_Image_Alt_Tag,
		 Knowledge_Card_Description,Created_By,Created_IP)

		 VALUES(
		 @FK_Knowledge_Base_Id,
		 @Knowledge_Card_Code ,        
		 @Knowledge_Card_Name,         
		 @Knowledge_Card_Title,        
		 @Knowledge_Card_Image ,       
		 @Knowledge_Card_Image_Alt_Tag,
		 @Knowledge_Card_Description,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Knowledge Card FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END