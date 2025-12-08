CREATE PROCEDURE [dbo].[sp_List_Event_Detail]
@Event_Detail_Id INT=NULL,
@Event_Id INT=Null

AS
BEGIN                           
 BEGIN TRY      

      IF @Event_Detail_Id=0 SET @Event_Detail_Id=NULL 
      IF @Event_Id=0 Set @Event_Id=NULL
      
 
     SELECT * FROM tbl_Event_Detail ED
     INNER JOIN tbl_Event E ON ED.FK_Event_Id=E.Event_Id   
     WHERE ED.Event_Detail_Id=ISNULL(@Event_Detail_Id,ED.Event_Detail_Id)
     AND ED.FK_Event_Id=ISNULL(@Event_Id,ED.FK_Event_Id)
     AND ED.Is_Active=1 ORDER BY Event_Detail_Id 


 END TRY   
 BEGIN CATCH    
	DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Event_Detail FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
	RAISERROR (@ErrorMessage, 16, 1)   
 END CATCH    
END

