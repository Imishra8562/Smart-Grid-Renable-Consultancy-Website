CREATE PROCEDURE [dbo].[sp_List_Product_Benefits]
@Product_Benefits_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Product_Benefits_Id=0 SET @Product_Benefits_Id=NULL
    IF @Product_Id=0 SET @Product_Id=NULL
	
    SELECT * FROM tbl_Product_Benefits PB 
	INNER JOIN tbl_Product PD ON PB.FK_Product_Id=PD.Product_Id
	
	WHERE PB.Product_Benefits_Id=ISNULL(@Product_Benefits_Id,PB.Product_Benefits_Id) AND
	PB.FK_Product_Id=ISNULL(@Product_Id,PB.FK_Product_Id) 

	AND PB.Is_Active=1 
	ORDER BY PB.Product_Benefits_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST PRODUCTS BENEFITS FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
