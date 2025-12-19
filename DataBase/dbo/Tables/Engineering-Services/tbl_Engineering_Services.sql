CREATE TABLE [dbo].[tbl_Engineering_Services]
(
    [Engineering_Services_Id] INT IDENTITY(1,1) NOT NULL,
    [Engineering_Services_Code] NVARCHAR(MAX) NULL,
    [Engineering_Services_Name] NVARCHAR(MAX) NULL,
    [Engineering_Services_Page_Title] NVARCHAR(MAX) NULL,
    [Engineering_Services_Meta_Keyword] NVARCHAR(MAX) NULL,
    [Engineering_Services_Meta_Description] NVARCHAR(MAX) NULL,
    [Engineering_Services_News_Keyword] NVARCHAR(MAX) NULL,
    [Engineering_Services_News_Description] NVARCHAR(MAX) NULL,
    [Engineering_Services_Og_Image] NVARCHAR(MAX) NULL,
    [Engineering_Services_Og_Title] NVARCHAR(MAX) NULL,
    [Engineering_Services_Og_Description] NVARCHAR(MAX) NULL,
    [Engineering_Services_Image] NVARCHAR(MAX) NULL,
    [Engineering_Services_Image_Alt_Tag] NVARCHAR(MAX) NULL,
    [Engineering_Services_Description] NVARCHAR(MAX) NULL,
    [Engineering_Services_Url_Link] NVARCHAR(MAX) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),
CONSTRAINT [Pk_Engineering_Services] PRIMARY KEY CLUSTERED ([Engineering_Services_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
