CREATE TABLE [dbo].[tbl_Product_Features]
(
[Product_Features_Id] INT IDENTITY (1,1) NOT NULL,
[Product_Features_Code] NVARCHAR (MAX) NULL,
[FK_Product_Id] INT NULL,
[Product_Features_Name]  NVARCHAR(MAX) NULL,
[Product_Features_Images]  NVARCHAR(MAX) NULL,
[Product_Features_Decriptions]  NVARCHAR(MAX) NULL,

[Created_On] DATETIME NOT NULL DEFAULT(GETDATE()),
[Created_By] INT NOT NULL,
[Created_IP] NVARCHAR(MAX) NULL,
[Modified_On] DATETIME NULL DEFAULT(NULL),
[Modified_By] INT NULL DEFAULT(NULL),
[Modified_IP] NVARCHAR(MAX) NULL,
[Is_Active] BIT NOT NULL DEFAULT(1)

 CONSTRAINT[PK_tbl_Product_Features] PRIMARY KEY CLUSTERED ([Product_Features_Id] ASC) 
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
 