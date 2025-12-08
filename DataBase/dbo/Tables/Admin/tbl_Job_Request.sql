CREATE TABLE [dbo].[tbl_Job_Request]
(
	[Job_Request_Id] INT IDENTITY(1,1) NOT NULL, 
    [Name] NVARCHAR(MAX) NULL,  
    [Email] NVARCHAR(MAX) NULL, 
    [Phone_No] NVARCHAR(MAX) NULL,  
    [Upload_Resume] NVARCHAR(MAX) NULL, 
    [Job_Position] NVARCHAR(MAX) NULL, 
    [Message] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
     

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [PK_tbl_Job_Request] PRIMARY KEY CLUSTERED ([Job_Request_Id] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
