CREATE TABLE [dbo].[tbl_Knowledge_WorkflowStep]
(
    [Knowledge_WorkflowStep_Id] INT IDENTITY(1,1) NOT NULL,
    [FK_Knowledge_Base_Id] INT NOT NULL,
    [Knowledge_WorkflowStep_Code] NVARCHAR(MAX) NULL,
    [Knowledge_WorkflowStep_Name] NVARCHAR(MAX) NULL,
    [Knowledge_WorkflowStep_Title] NVARCHAR(MAX) NULL,
    [Knowledge_WorkflowStep_Image] NVARCHAR(MAX) NULL,
    [Knowledge_WorkflowStep_Image_Alt_Tag] NVARCHAR(MAX) NULL,
    [Knowledge_WorkflowStep_Description] NVARCHAR(MAX) NULL,

    -- Audit Fields
    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),

    CONSTRAINT [Pk_Knowledge_WorkflowStep] PRIMARY KEY CLUSTERED ([Knowledge_WorkflowStep_Id] ASC)
    WITH 
    (
        PAD_INDEX = OFF,
        STATISTICS_NORECOMPUTE = OFF,
        IGNORE_DUP_KEY = OFF,
        ALLOW_ROW_LOCKS = ON,
        ALLOW_PAGE_LOCKS = ON
    )
    ON [PRIMARY]
)
ON [PRIMARY];
