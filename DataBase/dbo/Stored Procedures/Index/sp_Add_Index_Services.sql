CREATE PROCEDURE [dbo].[sp_Add_Index_Services]
@Index_Services_Code          NVARCHAR(MAX)=NULL, 
@Index_Services_Icon          NVARCHAR(MAX)=NULL,
@Index_Services_Title         NVARCHAR(MAX)=NULL,
@Index_Services_Description   NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Index_ServicesId INT
   SELECT @Index_ServicesId=Index_Services_Id from tbl_Index_Services where Index_Services_Code=@Index_Services_Code AND Is_Active=1
		 
   IF @Index_ServicesId IS NULL
      BEGIN
         INSERT INTO tbl_Index_Services(
		 Index_Services_Code,      
		 Index_Services_Icon ,      
		 Index_Services_Title ,     
		 Index_Services_Description,           
		 Created_By,Created_IP)

		 VALUES(
		 @Index_Services_Code,      
		 @Index_Services_Icon ,      
		 @Index_Services_Title ,     
		 @Index_Services_Description,
         @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Index Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END