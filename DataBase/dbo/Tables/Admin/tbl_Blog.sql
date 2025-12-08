CREATE TABLE [dbo].[tbl_Blog]
(
	[Blog_Id] INT IDENTITY (1,1) NOT NULL,
    [FK_Blog_Category_Id] INT NULL,
    [Blog_Code] NVARCHAR (Max)  NULL,
    [Page_Title]  NVARCHAR(MAX) NULL,
    [Meta_Keyword] NVARCHAR(MAX) NULL,
    [Meta_Description] NVARCHAR(MAX) NULL,
    [News_Keyword] NVARCHAR(MAX) NULL,
    [News_Description] NVARCHAR(MAX) NULL,
    [Og_Title] NVARCHAR(MAX) NULL,
    [Og_Description] NVARCHAR(MAX) NULL,
    [Meta_Og_Image] NVARCHAR(MAX) NULL,
    [Blog_Image] NVARCHAR(MAX) NULL,
    [Meta_Alt_tag] NVARCHAR(MAX) NULL,
    [Blog_Heading] NVARCHAR(MAX) NULL,
    [Blog_Description] NVARCHAR(MAX) NULL,
    [Blog_Link] NVARCHAR(MAX) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Blog] PRIMARY KEY CLUSTERED ([Blog_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
