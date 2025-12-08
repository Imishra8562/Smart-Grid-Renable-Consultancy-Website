CREATE TABLE [dbo].[tbl_Demo_Follow_Up]
(
	[Demo_Follow_Up_Id] INT IDENTITY(1,1) NOT NULL, 
    [Demo_Follow_Up_Code] NVARCHAR(MAX) NULL, 
    [FK_Software_Demo_Id] INT NULL, 
    [Demo_Follow_Up_By] NVARCHAR(MAX) NULL,  
    [Query_Response] NVARCHAR(MAX) NULL, 
    [Next_Follow_Date] DATETIME NULL, 
    [Next_Follow_Time] DATETIME NULL, 
    [Description] NVARCHAR(MAX) NULL, 

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Demo_Follow_Up] PRIMARY KEY CLUSTERED ([Demo_Follow_Up_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]