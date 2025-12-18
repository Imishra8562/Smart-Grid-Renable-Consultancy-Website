CREATE PROCEDURE [dbo].[sp_Update_Knowledge_WorkflowStep]
@FK_Knowledge_Base_Id INT=NULL,
@Knowledge_WorkflowStep_Id INT=NULL,
@Knowledge_WorkflowStep_Code          NVARCHAR(MAX)=NULL,
@Knowledge_WorkflowStep_Name          NVARCHAR(MAX)=NULL,
@Knowledge_WorkflowStep_Title         NVARCHAR(MAX)=NULL,
@Knowledge_WorkflowStep_Image         NVARCHAR(MAX)=NULL,
@Knowledge_WorkflowStep_Image_Alt_Tag NVARCHAR(MAX)=NULL,
@Knowledge_WorkflowStep_Description   NVARCHAR(MAX)=NULL,

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
 Update tbl_Knowledge_WorkflowStep SET 
         FK_Knowledge_Base_Id = @FK_Knowledge_Base_Id ,
         Knowledge_WorkflowStep_Name  = @Knowledge_WorkflowStep_Name ,        
         Knowledge_WorkflowStep_Title  =@Knowledge_WorkflowStep_Title ,       
         Knowledge_WorkflowStep_Image  = @Knowledge_WorkflowStep_Image,        
         Knowledge_WorkflowStep_Image_Alt_Tag  =@Knowledge_WorkflowStep_Image_Alt_Tag,
         Knowledge_WorkflowStep_Description   = @Knowledge_WorkflowStep_Description,
         Modified_On=@Modified_On,Modified_IP=@Modified_IP,Modified_By=@Modified_By
         where Knowledge_WorkflowStep_Id= @Knowledge_WorkflowStep_Id
         select @Knowledge_WorkflowStep_Id
         END TRY   
BEGIN CATCH    
   DECLARE @ErrorMessage VARCHAR(MAX);    
   SELECT @ErrorMessage ='SP ERROR : UPDATE Knowledge WorkflowStep FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   SELECT @ErrorMessage ='SP ERROR : UPDATE Knowledge WorkflowStep FAILED' + Char(13) + Char(10) + 'THE ERROR WAS : ' + Char(13) + Char(10) + ERROR_MESSAGE()   
   RAISERROR (@ErrorMessage, 16, 1)   
END CATCH
END