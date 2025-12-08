CREATE PROCEDURE [dbo].[sp_Add_Software_Demo]
@Software_Demo_Code NVARCHAR(MAX)=NULL,
@Name NVARCHAR(MAX)=NULL,
@Email NVARCHAR(MAX)=NULL,
@Phone_No NVARCHAR(MAX)=NULL,
@Software NVARCHAR(MAX)=NULL,
@Message NVARCHAR(MAX)=NULL,
@Team_Size NVARCHAR(MAX)=NULL,
@Software_Requirement_Time NVARCHAR(MAX)=NULL,
@Organization_Name NVARCHAR(MAX)=NULL,
@Monthly_Loan NVARCHAR(MAX)=NULL,
@MLM_Plan NVARCHAR(MAX)=NULL,
@Loan_Type NVARCHAR(MAX)=NULL,
@City_Name NVARCHAR(MAX)=NULL,
@Currently_Using NVARCHAR(MAX)=NULL,
@Manage_your_leads NVARCHAR(MAX)=NULL,
@Is_Quick_Apply BIT=NULL,
@Is_Landing_Page BIT=NULL,
@Is_Follow_Up_Closed BIT=NULL,

@Has_Website BIT=NULL,
@Website_URL NVARCHAR(MAX)=NULL,
@Website_Service_Type NVARCHAR(MAX)=NULL,
@Has_EWebsite_Site BIT=NULL,
@EWebsite_Site_URL NVARCHAR(MAX)=NULL,
@EWebsite_Service_Type NVARCHAR(MAX)=NULL,
@B2B_Name NVARCHAR(MAX)=NULL,
@B2B_Describe NVARCHAR(MAX)=NULL,
@B2C_Name NVARCHAR(MAX)=NULL,
@B2C_Describe NVARCHAR(MAX)=NULL,
@Required_Portal_Type NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Software_Demo_Id INT
   SELECT @Software_Demo_Id=Software_Demo_Id from tbl_Software_Demo where Software=@Software AND Name=@Name AND Created_IP=@Created_IP AND Is_Active=1
		 
   IF @Software_Demo_Id IS NULL
      BEGIN
	        SELECT @Software_Demo_Code = ('SDC-') + (SELECT CAST(CONVERT(numeric(7,0),RAND() * 8999999) + 1000000 AS NVARCHAR))

         INSERT INTO tbl_Software_Demo(Software_Demo_Code,Name,Email,Phone_No,Software,Message,Team_Size,Software_Requirement_Time,Organization_Name,Monthly_Loan,MLM_Plan,Loan_Type,City_Name,Currently_Using,
		 Has_Website,
         Website_URL ,
         Website_Service_Type ,
         Has_EWebsite_Site ,
         EWebsite_Site_URL ,
         EWebsite_Service_Type ,
         B2B_Name ,
         B2B_Describe ,
         B2C_Name ,
         B2C_Describe ,
         Required_Portal_Type ,
		 Manage_your_leads,Is_Quick_Apply,Is_Landing_Page,Is_Follow_Up_Closed,Created_By,Created_IP)
		 VALUES(@Software_Demo_Code,@Name,@Email,@Phone_No,@Software,@Message,@Team_Size,@Software_Requirement_Time,@Organization_Name,@Monthly_Loan,@MLM_Plan,@Loan_Type,@City_Name,@Currently_Using,
		 @Has_Website,
         @Website_URL ,
         @Website_Service_Type ,
         @Has_EWebsite_Site ,
         @EWebsite_Site_URL ,
         @EWebsite_Service_Type ,
         @B2B_Name ,
         @B2B_Describe ,
         @B2C_Name ,
         @B2C_Describe ,
         @Required_Portal_Type ,
		 @Manage_your_leads,@Is_Quick_Apply,@Is_Landing_Page,@Is_Follow_Up_Closed,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Software Demo FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
