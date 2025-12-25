CREATE PROCEDURE [dbo].[sp_List_Engineering_Services]
	@Engineering_Services_Id INT=NULL,
	@Engineering_Services_Url_Link NVARCHAR(MAX)=NULL
	AS
	BEGIN
	BEGIN TRY      
		  IF @Engineering_Services_Id=0 SET @Engineering_Services_Id=NULL 
		
	
		 SELECT * FROM tbl_Engineering_Services ES
			
		 WHERE ES.Engineering_Services_Id=ISNULL(@Engineering_Services_Id,ES.Engineering_Services_Id)
		 AND ES.Engineering_Services_Url_Link=ISNULL(@Engineering_Services_Url_Link,ES.Engineering_Services_Url_Link)
		 AND ES.Is_Active=1 ORDER BY Engineering_Services_Id
	END TRY
	BEGIN CATCH
		 DECLARE @ErrorMessage VARCHAR(MAX);
		 SELECT @ErrorMessage ='SP ERROR : LIST Engineering Services FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()
		 RAISERROR (@ErrorMessage, 16, 1)
	END CATCH
	END

	
