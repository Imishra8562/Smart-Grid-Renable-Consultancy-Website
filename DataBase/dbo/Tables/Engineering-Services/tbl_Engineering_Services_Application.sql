CREATE TABLE [dbo].[tbl_Engineering_Services_Application]
(
    [Engineering_Services_Application_Id] INT IDENTITY(1,1) NOT NULL,
    [FK_Engineering_Services_Id] INT NOT NULL,
    [Application_Name] NVARCHAR(MAX) NULL,
    [Application_Description] NVARCHAR(MAX) NULL,
    [Icon_Class] NVARCHAR(MAX) NULL,
    [Display_Order] INT NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),

CONSTRAINT [Pk_Engineering_Services_Application] PRIMARY KEY CLUSTERED ([Engineering_Services_Application_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
