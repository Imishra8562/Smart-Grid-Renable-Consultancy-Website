CREATE TABLE [dbo].[tbl_Knowledge_Base_Category]
(
	[Knowledge_Base_Category_Id] INT IDENTITY(1,1) NOT NULL, 
    [Category_Name] NVARCHAR(MAX) NULL,  
    [Category_Description] NVARCHAR(MAX) NULL, 

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Knowledge_Base_Category] PRIMARY KEY CLUSTERED ([Knowledge_Base_Category_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
