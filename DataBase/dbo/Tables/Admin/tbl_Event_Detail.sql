CREATE TABLE [dbo].[tbl_Event_Detail]
(
	[Event_Detail_Id] INT IDENTITY(1,1) NOT NULL, 
    [FK_Event_Id] INT NULL,
    [Event_Code] NVARCHAR(MAX) NULL,  
    [Event_Image] NVARCHAR(MAX) NULL,  
    [Description] NVARCHAR(MAX) NULL,  

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Event_Detail] PRIMARY KEY CLUSTERED ([Event_Detail_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
