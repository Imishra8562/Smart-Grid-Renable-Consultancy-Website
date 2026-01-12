CREATE TABLE [dbo].[tbl_Knowledge_Base]
(	
    [Knowledge_Base_Id] INT IDENTITY(1,1) NOT NULL,
    --[FK_Knowledge_Base_Category_Id] INT NULL,
    [Knowledge_Base_Code] NVARCHAR(MAX) NULL,  
    [Knowledge_Base_Name] NVARCHAR(MAX) NULL,  
    [Knowledge_Base_Page_Title] NVARCHAR(MAX) NULL,
    [Knowledge_Base_Meta_Keyword] NVARCHAR(MAX) NULL,  
    [Knowledge_Base_Meta_Description] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_News_Keyword] NVARCHAR(MAX) NULL,  
    [Knowledge_Base_News_Description] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Og_Image] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Og_Title] NVARCHAR(MAX) NULL,  
    [Knowledge_Base_Og_Description] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Image] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Image_Alt_Tag] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Description] NVARCHAR(MAX) NULL, 
    [Knowledge_Base_Url_Link] NVARCHAR(MAX) NULL, 


    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [Pk_Knowledge_Base] PRIMARY KEY CLUSTERED ([Knowledge_Base_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
