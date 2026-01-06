CREATE PROCEDURE [dbo].[sp_Delete_EngSer_Gallery]
	@EngSer_Gallery_Id INT
	As
	Begin
	 Begin Try
	     UPDATE tbl_EngSer_Gallery SET Is_Active=0,Modified_On=GETDATE() WHERE EngSer_Gallery_Id=@EngSer_Gallery_Id
		 SELECT @EngSer_Gallery_Id
	 End Try
	 Begin Catch
	  DECLARE @ErrorMessage VARCHAR(MAX);
	  SELECT @ErrorMessage ='SP ERROR : DELETE Engineering Services Gallery FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()
	  RAISERROR (@ErrorMessage, 16, 1)
	 End Catch
	 END