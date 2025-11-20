CREATE PROCEDURE [dbo].[sp_Update_Index_Features]
@FK_Index_Seo_Id INT=NULL,
@Index_Features_Id               INT=NULL,
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
         UPDATE tbl_Index_Features SET 
         FK_Index_Seo_Id             =@FK_Index_Seo_Id ,
         Index_Features_Image        =@Index_Features_Image        ,
         Index_Features_Title        =@Index_Features_Title        ,
         Index_Features_Headline1    =@Index_Features_Headline1    ,
         Index_Features_SubHeadline1 =@Index_Features_SubHeadline1 ,
         Index_Features_Headline2    =@Index_Features_Headline2    ,
         Index_Features_SubHeadline2 =@Index_Features_SubHeadline2 ,
         Index_Features_Headline3    =@Index_Features_Headline3    ,
         Index_Features_SubHeadline3 =@Index_Features_SubHeadline3 ,              
		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By

		WHERE Index_Features_Id=@Index_Features_Id 
        SELECT @Index_Features_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Index Features FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
