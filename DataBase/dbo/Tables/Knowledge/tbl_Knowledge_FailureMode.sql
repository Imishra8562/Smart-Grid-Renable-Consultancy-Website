CREATE TABLE [dbo].[tbl_Knowledge_FailureMode]
(
    [Knowledge_FailureMode_Id] INT IDENTITY(1,1) NOT NULL,
    [FK_Knowledge_Base_Id] INT NOT NULL,
    [Knowledge_FailureMode_Code] NVARCHAR(MAX) NULL,
    [Knowledge_FailureMode_Name] NVARCHAR(MAX) NULL,
    [Knowledge_FailureMode_Title] NVARCHAR(MAX) NULL,
    [Knowledge_FailureMode_Image] NVARCHAR(MAX) NULL,
    [Knowledge_FailureMode_Image_Alt_Tag] NVARCHAR(MAX) NULL,
    [Knowledge_FailureMode_Description] NVARCHAR(MAX) NULL,

    -- Audit Fields
    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),

    CONSTRAINT [Pk_Knowledge_FailureMode] PRIMARY KEY CLUSTERED ([Knowledge_FailureMode_Id] ASC)
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
