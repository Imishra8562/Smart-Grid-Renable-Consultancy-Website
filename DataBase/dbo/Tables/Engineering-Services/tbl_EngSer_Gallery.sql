CREATE TABLE [dbo].[tbl_EngSer_Gallery]
(
	[EngSer_Gallery_Id] INT IDENTITY(1,1) NOT NULL,
	[FK_Engineering_Services_Id] INT  NULL,
    [EngSer_Gallery_Code] NVARCHAR(MAX) NULL,
	[EngSer_Gallery_Title] NVARCHAR(MAX) NULL,
	[EngSer_Gallery_Description] NVARCHAR(MAX) NULL,
    [EngSer_Gallery_Image_Url] NVARCHAR(MAX) NULL,

	[Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),

CONSTRAINT [PK_tbl_EngSer_Gallery] PRIMARY KEY CLUSTERED ([EngSer_Gallery_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
