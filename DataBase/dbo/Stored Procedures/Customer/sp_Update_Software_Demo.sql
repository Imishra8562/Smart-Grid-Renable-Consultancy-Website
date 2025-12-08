CREATE PROCEDURE [dbo].[sp_Update_Software_Demo]
@Software_Demo_Id INT=NULL,
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
	   
   UPDATE tbl_Software_Demo SET Is_Follow_Up_Closed=@Is_Follow_Up_Closed,

                                            
                         Modified_On=GETDATE(),
                         Modified_IP=@Modified_IP,
                         Modified_By=@Modified_By
                   WHERE Software_Demo_Id=@Software_Demo_Id
   SELECT @Software_Demo_Id
                      
END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Software Demo FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
