CREATE PROCEDURE [dbo].[sp_Add_Knowledge_RelatedSolution]
	@FK_Knowledge_Base_Id  INT=NULL,
@Knowledge_RelatedSolution_Code          NVARCHAR(MAX)=NULL,
@Knowledge_RelatedSolution_Name          NVARCHAR(MAX)=NULL,
@Knowledge_RelatedSolution_Title         NVARCHAR(MAX)=NULL,
@Knowledge_RelatedSolution_Image         NVARCHAR(MAX)=NULL,
@Knowledge_RelatedSolution_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_RelatedSolution_Description   NVARCHAR(MAX)=NULL,

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
	   
   DECLARE @Knowledge_RelatedSolutionId INT
   SELECT @Knowledge_RelatedSolutionId=Knowledge_RelatedSolution_Id from tbl_Knowledge_RelatedSolution where Knowledge_RelatedSolution_Code=@Knowledge_RelatedSolution_Code AND Is_Active=1
		 
   IF @Knowledge_RelatedSolutionId IS NULL
      BEGIN
         INSERT INTO tbl_Knowledge_RelatedSolution(
		 FK_Knowledge_Base_Id,
		 Knowledge_RelatedSolution_Code ,        
		 Knowledge_RelatedSolution_Name,         
		 Knowledge_RelatedSolution_Title,        
		 Knowledge_RelatedSolution_Image ,       
		 Knowledge_RelatedSolution_Image_Alt_Tag,
		 Knowledge_RelatedSolution_Description,Created_By,Created_IP)

		 VALUES(
		 @FK_Knowledge_Base_Id,
		 @Knowledge_RelatedSolution_Code ,        
		 @Knowledge_RelatedSolution_Name,         
		 @Knowledge_RelatedSolution_Title,        
		 @Knowledge_RelatedSolution_Image ,       
		 @Knowledge_RelatedSolution_Image_Alt_Tag,
		 @Knowledge_RelatedSolution_Description,
		 @Created_By,@Created_IP)
		 SELECT SCOPE_IDENTITY()
      END

END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : ADD Knowledge RelatedSolution FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END