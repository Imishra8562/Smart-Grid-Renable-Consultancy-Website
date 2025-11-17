CREATE PROCEDURE [dbo].[sp_Update_Index_Team]
@Index_Team_Id               INT=NULL,
@Index_Team_Member_Name          NVARCHAR(MAX)=NULL, 
@Index_Team_Member_Code          NVARCHAR(MAX)=NULL,
@Index_Team_Member_Designation   NVARCHAR(MAX)=NULL,
@Index_Team_Member_Image         NVARCHAR(MAX)=NULL,
@Index_Team_Member_Facebook_Url  NVARCHAR(MAX)=NULL,
@Index_Team_Member_Twitter_Url   NVARCHAR(MAX)=NULL,
@Index_Team_Member_Linkedin_Url  NVARCHAR(MAX)=NULL,
@Index_Team_Member_Instagram_Url NVARCHAR(MAX)=NULL,

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
         UPDATE tbl_Index_Team SET 
         Index_Team_Member_Name          =@Index_Team_Member_Name         , 
         Index_Team_Member_Designation   =@Index_Team_Member_Designation  ,
         Index_Team_Member_Image         =@Index_Team_Member_Image        ,
         Index_Team_Member_Facebook_Url  =@Index_Team_Member_Facebook_Url ,
         Index_Team_Member_Twitter_Url   =@Index_Team_Member_Twitter_Url  ,
         Index_Team_Member_Linkedin_Url  =@Index_Team_Member_Linkedin_Url ,
         Index_Team_Member_Instagram_Url=@Index_Team_Member_Instagram_Url ,
		 Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By

		WHERE Index_Team_Id=@Index_Team_Id 
        SELECT @Index_Team_Id
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Index Team FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
