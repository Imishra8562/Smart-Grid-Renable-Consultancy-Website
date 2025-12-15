CREATE PROCEDURE [dbo].[sp_Add_Knowledge_Base_Category]
@Category_Name NVARCHAR(MAX)=NULL,
@Category_Description NVARCHAR(MAX)=NULL,
@Category_Url_Link NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Knowledge_Base_Category_Id INT
   SELECT @Knowledge_Base_Category_Id=Knowledge_Base_Category_Id from tbl_Knowledge_Base_Category where Category_Name=@Category_Name AND Is_Active=1
		 
   IF @Knowledge_Base_Category_Id IS NULL
      BEGIN
         INSERT INTO tbl_Knowledge_Base_Category(Category_Name,Category_Description,Category_Url_Link,Created_By,Created_IP)
		 VALUES(@Category_Name,@Category_Description,@Category_Url_Link,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Knowledge Base Category FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
