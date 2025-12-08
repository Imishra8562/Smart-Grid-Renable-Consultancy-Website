CREATE PROCEDURE [dbo].[sp_List_Product_Module]
@Product_Module_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Product_Module_Id=0 SET @Product_Module_Id=NULL
    IF @Product_Id=0 SET @Product_Id=NULL
	
    SELECT * FROM tbl_Product_Module PM 
	INNER JOIN tbl_Product PD ON PM.FK_Product_Id=PD.Product_Id
	
	WHERE PM.Product_Module_Id=ISNULL(@Product_Module_Id,PM.Product_Module_Id) AND
	PM.FK_Product_Id=ISNULL(@Product_Id,PM.FK_Product_Id) 

	AND PM.Is_Active=1 
	ORDER BY PM.Product_Module_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST PRODUCTS MODULE FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
