CREATE PROCEDURE [dbo].[sp_List_Product_Image]
@Product_Image_Id INT=NULL,
@Product_Id INT=NULL

AS
BEGIN    
BEGIN TRY   

    IF @Product_Image_Id=0 SET @Product_Image_Id=NULL
    IF @Product_Id=0 SET @Product_Id=NULL
	
    SELECT * FROM tbl_Product_Image PI 
	INNER JOIN tbl_Product PD ON PI.FK_Product_Id=PD.Product_Id
	
	WHERE PI.Product_Image_Id=ISNULL(@Product_Image_Id,PI.Product_Image_Id) AND
	PI.FK_Product_Id=ISNULL(@Product_Id,PI.FK_Product_Id) 

	AND PI.Is_Active=1 
	ORDER BY PI.Product_Image_Id

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : LIST PRODUCTS IMAGE FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END
