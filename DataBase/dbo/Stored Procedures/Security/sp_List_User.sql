CREATE PROCEDURE [dbo].[sp_List_User]
@User_Id INT=NULL,
@User_Role_Id INT=NULL,
@Mobile_No NVARCHAR(MAX)=NULL,
@Email_Id NVARCHAR(MAX)=NULL,
@User_Name NVARCHAR(MAX)=NULL

AS   
SET NOCOUNT ON    
BEGIN    
BEGIN TRY   

   BEGIN   

      IF @User_Id=0 SET @User_Id=NULL
      IF @User_Role_Id=0 SET @User_Role_Id=NULL
      IF @Email_Id='' SET @Email_Id=NULL

      SELECT *, CAST(U.Password AS VARCHAR(MAX)) AS Password_String FROM tbl_User U
      INNER JOIN tbl_User_Role UR ON UR.User_Role_Id=U.FK_User_Role_Id
      WHERE U.User_Id=ISNULL(@User_Id,U.User_Id) 
      AND U.FK_User_Role_Id=ISNULL(@User_Role_Id,U.FK_User_Role_Id) 
      AND U.Mobile_No=ISNULL(@Mobile_No,U.Mobile_No) 
      AND U.Email_Id=ISNULL(@Email_Id,U.Email_Id) 
      AND U.User_Name=ISNULL(@User_Name,U.User_Name) 

      AND U.Is_Active=1 
      ORDER BY U.User_Id

   END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST USER FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH    
END