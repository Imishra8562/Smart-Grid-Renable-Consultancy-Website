CREATE TABLE [dbo].[tbl_Index_Slider]
(
	[Index_Slider_Id] INT IDENTITY(1,1) NOT NULL,    
    [Index_Slider_Code] NVARCHAR(MAX) NULL, 
    [Index_Slider_Image] NVARCHAR(MAX) NULL,
    [Index_Slider_Alt_Tag] NVARCHAR(MAX) NULL,
    [Index_Slider_Headline] NVARCHAR(MAX) NULL,
    [Index_Slider_SubHeadline] NVARCHAR(MAX) NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()), 
    [Created_By] INT NOT NULL, 
    [Created_IP] NVARCHAR(MAX) NULL, 
    [Modified_On] DATETIME NULL, 
    [Modified_By] INT NULL,    
    [Modified_IP] NVARCHAR(MAX) NULL, 
    [Is_Active] BIT NOT NULL DEFAULT (1)
CONSTRAINT [Pk_Index_Slider] PRIMARY KEY CLUSTERED ([Index_Slider_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
