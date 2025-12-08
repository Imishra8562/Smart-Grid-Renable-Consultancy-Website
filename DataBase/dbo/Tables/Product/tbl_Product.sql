CREATE TABLE [dbo].[tbl_Product]
(
	[Product_Id] INT IDENTITY(1,1) NOT NULL, 
    [Product_Code] NVARCHAR(MAX) NULL,  
    [FK_Industries_Id] INT NULL, 
    [Product_Name] NVARCHAR(MAX) NULL,  
    [Product_Page_Title] NVARCHAR(MAX) NULL,
    [Product_Meta_Keyword] NVARCHAR(MAX) NULL,  
    [Product_Meta_Description] NVARCHAR(MAX) NULL, 
    [Product_News_Keyword] NVARCHAR(MAX) NULL,  
    [Product_News_Description] NVARCHAR(MAX) NULL, 
    [Product_Og_Image] NVARCHAR(MAX) NULL, 
    [Product_Og_Title] NVARCHAR(MAX) NULL,  
    [Product_Og_Description] NVARCHAR(MAX) NULL, 
    [Product_Image] NVARCHAR(MAX) NULL, 
    [Product_Image_Alt_Tag] NVARCHAR(MAX) NULL, 
    [Product_Description] NVARCHAR(MAX) NULL, 
    [Product_Rating] NVARCHAR(MAX) NULL, 
    [Product_Review_Count] NVARCHAR(MAX) NULL, 
    [Product_Url_Link] NVARCHAR(MAX) NULL, 

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Product] PRIMARY KEY CLUSTERED ([Product_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]