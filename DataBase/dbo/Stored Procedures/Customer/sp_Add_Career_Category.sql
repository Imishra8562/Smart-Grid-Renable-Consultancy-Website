CREATE PROCEDURE [dbo].[sp_Add_Career_Category]

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
	   DECLARE @Career_Category_Id INT
   SELECT @Career_Category_Id=Career_Category_Id from tbl_Career_Category where Career_Category_Code=@Career_Category_Code AND Is_Active=1
    IF @Career_Category_Id IS NULL
	 BEGIN
	     INSERT INTO tbl_Career_Category(
		 Career_Category_Title,
		 Career_Category_Code,
		 Career_Category_Image,
		 Career_Category_Description,
		 Created_By,Created_IP)
		 VALUES(
		 @Career_Category_Title,
		 @Career_Category_Code ,
		 @Career_Category_Image,
		 @Career_Category_Description,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END
END TRY   
BEGIN CATCH  
    DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Career Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
