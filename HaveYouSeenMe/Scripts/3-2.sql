CREATE TABLE [dbo].[Setting]
(
    [Id] INT NOT NULL IDENTITY(1,1), 
    [Key] VARCHAR(50) NOT NULL, 
    [Value] VARCHAR(500) NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[PetType]
(
     [PetTypeID] INT NOT NULL IDENTITY(1,1),
     [PetTypeDescription] VARCHAR(50) NULL,
    CONSTRAINT [PK_PetType] PRIMARY KEY ([PetTypeID])
);

CREATE TABLE [dbo].[Status] 
(
    [StatusID] INT NOT NULL IDENTITY(1,1),
    [Description] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Status] PRIMARY KEY ([StatusID])
);

CREATE TABLE [dbo].[Pet]
(
    [PetID] INT NOT NULL IDENTITY(1,1), 
    [PetName] VARCHAR(100) NOT NULL, 
    [PetAgeYears] INT NULL, 
    [PetAgeMonths] INT NULL,
    [StatusID] INT NOT NULL, 
    [LastSeenOn] DATE NULL, 
    [LastSeenWhere] VARCHAR(500) NULL, 
    [Notes] VARCHAR(1500) NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_Pet] PRIMARY KEY ([PetID]) ,
    CONSTRAINT [FK_Pet_Status] FOREIGN KEY ([StatusID]) 
        REFERENCES [Status] ([StatusID]),
    CONSTRAINT [FK_Pet_User] FOREIGN KEY ([UserId]) 
        REFERENCES [UserProfile] ([UserId])
);



CREATE TABLE [dbo].[PetPhoto]
(
    [PhotoID] INT NOT NULL IDENTITY(1,1), 
    [PetID] INT NOT NULL, 
    [Photo] VARCHAR(500) NOT NULL 
        CONSTRAINT [DF_PhotoFile] DEFAULT '/content/pets/no-image.png', 
    [Notes] VARCHAR(500) NULL,
    CONSTRAINT [PK_PetPhoto] PRIMARY KEY ([PhotoID]),
    CONSTRAINT [FK_PetPhoto_Pet] FOREIGN KEY ([PetID]) 
        REFERENCES [Pet] ([PetID])
);

CREATE TABLE [dbo].[Message]
(
    [MessageID] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [MessageDate] DATETIME NOT NULL, 
    [From] VARCHAR(150) NOT NULL, 
    [Email] VARCHAR(150) NOT NULL, 
    [Subject] VARCHAR(150) NULL, 
    [Message] VARCHAR(1500) NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY ([MessageID]),
    CONSTRAINT [FK_Message_User] FOREIGN KEY ([UserId]) 
        REFERENCES [UserProfile] ([UserId])
);
