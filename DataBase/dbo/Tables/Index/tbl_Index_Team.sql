CREATE TABLE [dbo].[tbl_Index_Team]
(
    [FK_Index_Seo_Id] INT NULL,
	[Index_Team_Id]                   INT IDENTITY(1,1) NOT NULL,    
    [Index_Team_Member_Name]          NVARCHAR(MAX) NULL, 
    [Index_Team_Member_Designation]   NVARCHAR(MAX) NULL,
    [Index_Team_Member_Image]         NVARCHAR(MAX) NULL,
    [Index_Team_Member_Code]          NVARCHAR(MAX) NULL,
    [Index_Team_Member_Facebook_Url]  NVARCHAR(MAX) NULL,
    [Index_Team_Member_Twitter_Url]   NVARCHAR(MAX) NULL,
    [Index_Team_Member_Linkedin_Url]  NVARCHAR(MAX) NULL,
    [Index_Team_Member_Instagram_Url] NVARCHAR(MAX) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [Pk_Tbl_Index_Team] PRIMARY KEY CLUSTERED ([Index_Team_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
