CREATE TABLE [dbo].[tbl_Industries]
(
	[Industries_Id] INT IDENTITY(1,1) NOT NULL, 
    [Industries_Code] NVARCHAR(MAX) NULL,  
    [Industries_Name] NVARCHAR(MAX) NULL,  
    [Industries_Page_Title] NVARCHAR(MAX) NULL,
    [Industries_Meta_Keyword] NVARCHAR(MAX) NULL,  
    [Industries_Meta_Description] NVARCHAR(MAX) NULL, 
    [Industries_News_Keyword] NVARCHAR(MAX) NULL,  
    [Industries_News_Description] NVARCHAR(MAX) NULL, 
    [Industries_Og_Image] NVARCHAR(MAX) NULL, 
    [Industries_Og_Title] NVARCHAR(MAX) NULL,  
    [Industries_Og_Description] NVARCHAR(MAX) NULL, 
    [Industries_Image] NVARCHAR(MAX) NULL, 
    [Industries_Image_Alt_Tag] NVARCHAR(MAX) NULL, 
    [Industries_Description] NVARCHAR(MAX) NULL, 
    [Industries_Url_Link] NVARCHAR(MAX) NULL, 

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Industries] PRIMARY KEY CLUSTERED ([Industries_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]