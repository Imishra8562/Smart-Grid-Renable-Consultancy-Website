CREATE TABLE [dbo].[tbl_Index_Features]
(
	[Index_Features_Id] INT IDENTITY(1,1) NOT NULL,    
    [Index_Features_Code] NVARCHAR(MAX) NULL, 
    [Index_Features_Image] NVARCHAR(MAX) NULL,
    [Index_Features_Title] NVARCHAR(MAX) NULL,
    [Index_Features_Headline1] NVARCHAR(MAX) NULL,
    [Index_Features_SubHeadline1] NVARCHAR(MAX) NULL,
    [Index_Features_Headline2] NVARCHAR(MAX) NULL,
    [Index_Features_SubHeadline2] NVARCHAR(MAX) NULL,
    [Index_Features_Headline3] NVARCHAR(MAX) NULL,
    [Index_Features_SubHeadline3] NVARCHAR(MAX) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [Pk_Index_Features] PRIMARY KEY CLUSTERED ([Index_Features_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
