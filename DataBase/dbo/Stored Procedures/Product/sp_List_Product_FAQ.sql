CREATE PROCEDURE [dbo].[sp_List_Product_FAQ]
@Product_FAQ_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Product_FAQ_Id=0 SET @Product_FAQ_Id=NULL
    IF @Product_Id=0 SET @Product_Id=NULL
	
    SELECT * FROM tbl_Product_FAQ PF 
	INNER JOIN tbl_Product PD ON PF.FK_Product_Id=PD.Product_Id
	
	WHERE PF.Product_FAQ_Id=ISNULL(@Product_FAQ_Id,PF.Product_FAQ_Id) AND
	PF.FK_Product_Id=ISNULL(@Product_Id,PF.FK_Product_Id) 

	AND PF.Is_Active=1 
	ORDER BY PF.Product_FAQ_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST PRODUCTS FAQ FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
