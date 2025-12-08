CREATE PROCEDURE [dbo].[sp_List_Blog_FAQ]
@Blog_FAQ_Id INT=NULL,
@Blog_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Blog_FAQ_Id=0 SET @Blog_FAQ_Id=NULL
    IF @Blog_Id=0 SET @Blog_Id=NULL
	
    SELECT * FROM tbl_Blog_FAQ PB 
	INNER JOIN tbl_Blog PD ON PB.FK_Blog_Id=PD.Blog_Id
	
	WHERE PB.Blog_FAQ_Id=ISNULL(@Blog_FAQ_Id,PB.Blog_FAQ_Id) AND
	PB.FK_Blog_Id=ISNULL(@Blog_Id,PB.FK_Blog_Id) 

	AND PB.Is_Active=1 
	ORDER BY PB.Blog_FAQ_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST Blog FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
