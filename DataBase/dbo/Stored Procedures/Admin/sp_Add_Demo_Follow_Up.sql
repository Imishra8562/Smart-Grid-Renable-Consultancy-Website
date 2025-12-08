CREATE PROCEDURE [dbo].[sp_Add_Demo_Follow_Up]
@Demo_Follow_Up_Code NVARCHAR(MAX)=NULL,
@FK_Software_Demo_Id INT=NULL,
@Demo_Follow_Up_By NVARCHAR(MAX)=NULL,
@Query_Response NVARCHAR(MAX)=NULL,
@Next_Follow_Date NVARCHAR(MAX)=NULL,
@Next_Follow_Time NVARCHAR(MAX)=NULL,
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
	   
   DECLARE @Demo_Follow_Up_Id INT
   SELECT @Demo_Follow_Up_Id=Demo_Follow_Up_Id from tbl_Demo_Follow_Up where FK_Software_Demo_Id=@FK_Software_Demo_Id AND Is_Active=1
		 
   IF @Demo_Follow_Up_Id IS NULL
     BEGIN
     UPDATE tbl_Demo_Follow_Up SET Is_Active=0 WHERE Demo_Follow_Up_Id=@Demo_Follow_Up_Id
     END
  
      BEGIN
               SELECT @Demo_Follow_Up_Code = ('DFUC-') + (SELECT CAST(CONVERT(numeric(7,0),RAND() * 8999999) + 1000000 AS NVARCHAR))

         INSERT INTO tbl_Demo_Follow_Up(Demo_Follow_Up_Code,FK_Software_Demo_Id,Demo_Follow_Up_By,Query_Response,Next_Follow_Date,Next_Follow_Time,Description,Created_By,Created_IP)
		 VALUES(@Demo_Follow_Up_Code,@FK_Software_Demo_Id,@Demo_Follow_Up_By,@Query_Response,@Next_Follow_Date,@Next_Follow_Time,@Description,@Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Demo Follow Up FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
