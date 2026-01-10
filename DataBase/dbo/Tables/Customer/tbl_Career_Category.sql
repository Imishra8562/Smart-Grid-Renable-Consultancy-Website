CREATE TABLE [dbo].[tbl_Career_Category]
(
	[Career_Category_Id]  INT IDENTITY(1,1) NOT NULL,
    [Career_Category_Title] NVARCHAR(MAX) NULL,  
    [Career_Category_Code] NVARCHAR(MAX) NULL,  
    [Career_Category_Image] NVARCHAR(MAX) NULL,  
    [Career_Category_Description] NVARCHAR(MAX) NULL,  

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Career_Category] PRIMARY KEY CLUSTERED ([Career_Category_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
