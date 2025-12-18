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

CONSTRAINT [Pk_Engineering_Services_GalleryImage]
PRIMARY KEY CLUSTERED ([Engineering_Services_GalleryImage_Id] ASC),

CONSTRAINT [FK_EngServices_GalleryImage]
FOREIGN KEY ([FK_Engineering_Services_Id])
REFERENCES [dbo].[tbl_Engineering_Services]([Engineering_Services_Id])
) ON [PRIMARY];
