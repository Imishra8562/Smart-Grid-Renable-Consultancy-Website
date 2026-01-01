CREATE PROCEDURE [dbo].[sp_Add_EngSer_Gallery]
@FK_Engering_Services_Id INT=NULL,
@EngSer_Gallery_Code         NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Image        NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Title        NVARCHAR(MAX)=NULL,
@EngSer_Gallery_Headline1    NVARCHAR(MAX)=NULL,
@EngSer_Gallery_SubHeadline1 NVARCHAR(MAX)=NULL,

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