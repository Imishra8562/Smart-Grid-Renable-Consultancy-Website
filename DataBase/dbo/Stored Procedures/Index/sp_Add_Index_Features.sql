CREATE PROCEDURE [dbo].[sp_Add_Index_Features]
@Index_Features_Code         NVARCHAR(MAX)=NULL,
@Index_Features_Image        NVARCHAR(MAX)=NULL,
@Index_Features_Title        NVARCHAR(MAX)=NULL,
@Index_Features_Headline1    NVARCHAR(MAX)=NULL,
@Index_Features_SubHeadline1 NVARCHAR(MAX)=NULL,
@Index_Features_Headline2    NVARCHAR(MAX)=NULL,
@Index_Features_SubHeadline2 NVARCHAR(MAX)=NULL,
@Index_Features_Headline3    NVARCHAR(MAX)=NULL,
@Index_Features_SubHeadline3 NVARCHAR(MAX)=NULL,


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
	   
   DECLARE @Index_FeaturesId INT
   SELECT @Index_FeaturesId=Index_Features_Id from tbl_Index_Features where Index_Features_Code=@Index_Features_Code AND Is_Active=1
		 
   IF @Index_FeaturesId IS NULL
      BEGIN
         INSERT INTO tbl_Index_Features(
		 Index_Features_Code,        
		 Index_Features_Image,       
		 Index_Features_Title,       
		 Index_Features_Headline1,   
		 Index_Features_SubHeadline1,
		 Index_Features_Headline2,   
		 Index_Features_SubHeadline2,
		 Index_Features_Headline3,   
		 Index_Features_SubHeadline3,Created_By,Created_IP)

		 VALUES(
		 @Index_Features_Code ,       
		 @Index_Features_Image ,      
		 @Index_Features_Title ,      
		 @Index_Features_Headline1 ,  
		 @Index_Features_SubHeadline1,
		 @Index_Features_Headline2   ,
		 @Index_Features_SubHeadline2,
		 @Index_Features_Headline3   ,
		 @Index_Features_SubHeadline3,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Index Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END