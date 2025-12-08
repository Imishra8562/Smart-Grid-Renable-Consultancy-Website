CREATE PROCEDURE [dbo].[sp_List_Demo_Follow_Up]
@Demo_Follow_Up_Id INT=NULL,
@Software_Demo_Id INT=NULL,
@Demo_Follow_Up_Code  NVARCHAR(MAX)=NULL,
@Is_Active BIT=NULL,
@Created_By INT=NULL

AS
BEGIN    
 BEGIN TRY   

     IF @Demo_Follow_Up_Id=0 SET @Demo_Follow_Up_Id=NULL
	 IF @Software_Demo_Id=0 SET @Software_Demo_Id=NULL
	 IF @Is_Active=0 SET @Is_Active=NULL
	 IF @Created_By=0 SET @Created_By=NULL
	 
    SELECT *
	FROM tbl_Demo_Follow_Up EFU
	INNER JOIN tbl_Software_Demo E ON EFU.FK_Software_Demo_Id=E.Software_Demo_Id
	LEFT JOIN tbl_User U ON EFU.Created_By = U.User_Id
	
	
	WHERE EFU.Demo_Follow_Up_Id=ISNULL(@Demo_Follow_Up_Id,EFU.Demo_Follow_Up_Id)	
	AND EFU.FK_Software_Demo_Id=ISNULL(@Software_Demo_Id,EFU.FK_Software_Demo_Id)
	AND EFU.Demo_Follow_Up_Code=ISNULL(@Demo_Follow_Up_Code,EFU.Demo_Follow_Up_Code)
	AND EFU.Is_Active=ISNULL(@Is_Active,EFU.Is_Active)
	AND EFU.Created_By=ISNULL(@Created_By,EFU.Created_By)
	ORDER BY EFU.Demo_Follow_Up_Id 


END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST  Demo FOLLOW UP FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
