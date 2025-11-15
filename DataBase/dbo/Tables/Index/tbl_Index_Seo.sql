CREATE TABLE [dbo].[tbl_Index_Seo]
(
    [Index_Seo_Id] INT IDENTITY(1,1) NOT NULL,    
    [Index_Seo_Code] NVARCHAR(MAX) NULL, 
    [Index_Seo_Page_Title] NVARCHAR(MAX) NULL,
    [Index_Seo_Meta_Keyword] NVARCHAR(MAX) NULL,
    [Index_Seo_Meta_Description] NVARCHAR(MAX) NULL,
    [Index_Seo_Og_Image] NVARCHAR(MAX) NULL,
    [Index_Seo_Image_Alt_Tag] NVARCHAR(MAX) NULL,
    [Index_Seo_Og_Title] NVARCHAR(MAX) NULL,
    [Index_Seo_Og_Description] NVARCHAR(MAX) NULL,
    [Index_Seo_Slug] NVARCHAR(MAX) NULL,


    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [Pk_Index_Seo] PRIMARY KEY CLUSTERED ([Index_Seo_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
