CREATE PROCEDURE [dbo].[sp_List_Product_Portfolio]
@Product_Portfolio_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Product_Portfolio_Id=0 SET @Product_Portfolio_Id=NULL
    IF @Product_Id=0 SET @Product_Id=NULL
	
    SELECT * FROM tbl_Product_Portfolio PP 
	INNER JOIN tbl_Product PD ON PP.FK_Product_Id=PD.Product_Id
	
	WHERE PP.Product_Portfolio_Id=ISNULL(@Product_Portfolio_Id,PP.Product_Portfolio_Id) AND
	PP.FK_Product_Id=ISNULL(@Product_Id,PP.FK_Product_Id) 

	AND PP.Is_Active=1 
	ORDER BY PP.Product_Portfolio_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST PRODUCTS PORTFOLIO FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
