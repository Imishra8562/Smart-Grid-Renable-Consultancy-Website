CREATE PROCEDURE [dbo].[sp_Add_Client]
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
	   
   DECLARE @Client_Id INT
   SELECT @Client_Id=Client_Id from tbl_Client where Company_Name=@Company_Name AND Is_Active=1
		 
   IF @Client_Id IS NULL
      BEGIN
         INSERT INTO tbl_Client(Client_Code,FK_Product_Id,Client_Name,Client_Designation,Company_Logo,Company_Name,Client_Text_Description,Client_Video_Thumbnail,Client_Video_Description,Created_By,Created_IP)
		 VALUES(@Client_Code,@FK_Product_Id,@Client_Name,@Client_Designation,@Company_Logo,@Company_Name,@Client_Text_Description,@Client_Video_Thumbnail,@Client_Video_Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Client FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
