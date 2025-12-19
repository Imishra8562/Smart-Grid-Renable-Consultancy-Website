CREATE TABLE [dbo].[tbl_Engineering_Services_Tab]
(
    [Engineering_Services_Tab_Id] INT IDENTITY(1,1) NOT NULL,
    [FK_Engineering_Services_Id] INT NOT NULL,
    [Tab_Code] NVARCHAR(MAX) NULL,
    [Tab_Title] NVARCHAR(MAX) NULL,
    [Tab_Content] NVARCHAR(MAX) NULL,
    [Display_Order] INT NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),


CONSTRAINT [Pk_Engineering_Services_Tab] PRIMARY KEY CLUSTERED ([Engineering_Services_Tab_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
