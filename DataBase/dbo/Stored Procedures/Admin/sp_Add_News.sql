CREATE PROCEDURE [dbo].[sp_Add_News]
@News_Code NVARCHAR(MAX)=NULL,
@News_Image NVARCHAR(MAX)=NULL,
@News_Description NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @News_Id INT
   SELECT @News_Id=News_Id from tbl_News where News_Description=@News_Description AND Is_Active=1
		 
   IF @News_Id IS NULL
      BEGIN
         INSERT INTO tbl_News(News_Code,News_Image,News_Description,Created_By,Created_IP)
		 VALUES(@News_Code,@News_Image,@News_Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD News FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
