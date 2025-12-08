CREATE PROCEDURE [dbo].[sp_Add_Event_Detail]
@FK_Event_Id INT = NULL,
@Event_Code NVARCHAR(MAX)=NULL,
@Event_Image NVARCHAR(MAX)=NULL,
@Description NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Event_Detail_Id INT
   SELECT @Event_Detail_Id=Event_Detail_Id from tbl_Event_Detail where Event_Detail_Id=@Event_Detail_Id AND Is_Active=1
		 
   IF @Event_Detail_Id IS NULL
      BEGIN
         INSERT INTO tbl_Event_Detail(FK_Event_Id,Event_Code,Event_Image,Description,Created_By,Created_IP)
		 VALUES(@FK_Event_Id,@Event_Code,@Event_Image,@Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Event_Detail FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
