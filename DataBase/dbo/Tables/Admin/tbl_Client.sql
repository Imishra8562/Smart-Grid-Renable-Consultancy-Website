CREATE TABLE [dbo].[tbl_Client]
(
	[Client_Id] INT IDENTITY(1,1) NOT NULL, 
    [Client_Code] NVARCHAR(MAX) NULL, 
    [FK_Product_Id] INT NULL, 
    [Client_Name] NVARCHAR(MAX) NULL,  
    [Client_Designation] NVARCHAR(MAX) NULL,  
    [Company_Logo] NVARCHAR(MAX) NULL, 
    [Company_Name] NVARCHAR(MAX) NULL, 
    [Client_Text_Description] NVARCHAR(MAX) NULL, 
    [Client_Video_Thumbnail] NVARCHAR(MAX) NULL, 
    [Client_Video_Description] NVARCHAR(MAX) NULL, 

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Client] PRIMARY KEY CLUSTERED ([Client_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
