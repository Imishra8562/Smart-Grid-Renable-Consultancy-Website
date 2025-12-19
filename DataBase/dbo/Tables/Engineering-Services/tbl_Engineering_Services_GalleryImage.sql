CREATE TABLE [dbo].[tbl_Engineering_Services_GalleryImage]
(
    [Engineering_Services_GalleryImage_Id] INT IDENTITY(1,1) NOT NULL,
    [FK_Engineering_Services_Id] INT NOT NULL,
    [Image_Url] NVARCHAR(MAX) NULL,
    [Image_Alt_Text] NVARCHAR(MAX) NULL,
    [Display_Order] INT NULL,

    [Created_On] DATETIME NOT NULL DEFAULT (GETDATE()),
    [Created_By] INT NOT NULL,
    [Created_IP] NVARCHAR(MAX) NULL,
    [Modified_On] DATETIME NULL,
    [Modified_By] INT NULL,
    [Modified_IP] NVARCHAR(MAX) NULL,
    [Is_Active] BIT NOT NULL DEFAULT (1),
CONSTRAINT [PK_Engineering_Services_GalleryImage] PRIMARY KEY CLUSTERED ([Engineering_Services_GalleryImage_Id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
