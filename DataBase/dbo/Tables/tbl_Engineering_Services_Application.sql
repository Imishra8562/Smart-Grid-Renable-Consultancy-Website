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

CONSTRAINT [Pk_Engineering_Services_Application]
PRIMARY KEY CLUSTERED ([Engineering_Services_Application_Id] ASC),

CONSTRAINT [FK_EngServices_Application]
FOREIGN KEY ([FK_Engineering_Services_Id])
REFERENCES [dbo].[tbl_Engineering_Services]([Engineering_Services_Id])
) ON [PRIMARY];
