CREATE PROCEDURE [dbo].[sp_Add_Index_Team]
@Index_Team_Member_Name          NVARCHAR(MAX)=NULL, 
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
	   
   DECLARE @Index_TeamId INT
   SELECT @Index_TeamId=Index_Team_Id from tbl_Index_Team where Index_Team_Member_Designation=@Index_Team_Member_Designation AND Is_Active=1
		 
   IF @Index_TeamId IS NULL
      BEGIN
         INSERT INTO tbl_Index_Team(
		 Index_Team_Member_Name,         
		 Index_Team_Member_Designation , 
		 Index_Team_Member_Image  ,      
		 Index_Team_Member_Facebook_Url ,
		 Index_Team_Member_Twitter_Url,  
		 Index_Team_Member_Linkedin_Url ,
		 Index_Team_Member_Instagram_Url,
		 Created_By,Created_IP)

		 VALUES(
		 @Index_Team_Member_Name,         
		 @Index_Team_Member_Designation , 
		 @Index_Team_Member_Image  ,      
		 @Index_Team_Member_Facebook_Url ,
		 @Index_Team_Member_Twitter_Url,  
		 @Index_Team_Member_Linkedin_Url ,
		 @Index_Team_Member_Instagram_Url,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Index Slider FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END