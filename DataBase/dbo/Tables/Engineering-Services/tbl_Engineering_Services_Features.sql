CREATE TABLE [dbo].[tbl_Engineering_Services_Features]
(
    [Engineering_Services_Features_Id] INT IDENTITY(1,1) NOT NULL,
    --[Engineering_Services_Feature_Code] NVARCHAR(100) NULL,
    [FK_Engineering_Services_Id] INT NULL,
    [Engineering_Services_Features_Name] NVARCHAR(300) NULL,
    [Engineering_Services_Features_Description] NVARCHAR(MAX) NULL,
    [Engineering_Services_Features_IconClass] NVARCHAR(200) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),

CONSTRAINT [PK_Engineering_Services_Features] PRIMARY KEY CLUSTERED ([Engineering_Services_Features_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
