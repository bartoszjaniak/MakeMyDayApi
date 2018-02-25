
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2018 21:22:15
-- Generated from EDMX file: C:\Users\bartoszjaniak\Projekty\MakeMyDayApi\MakeMyDayApi\DataBase\DataBase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bjaniak_makemyday];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Accounts_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Persons];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_Guest_List_Events]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event_Guest_List] DROP CONSTRAINT [FK_Event_Guest_List_Events];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_Guest_List_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Event_Guest_List] DROP CONSTRAINT [FK_Event_Guest_List_Persons];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Events_Persons];
GO
IF OBJECT_ID(N'[dbo].[FK_Friends_Persons_A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK_Friends_Persons_A];
GO
IF OBJECT_ID(N'[dbo].[FK_Friends_Persons_B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Friends] DROP CONSTRAINT [FK_Friends_Persons_B];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_Members_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups_Members] DROP CONSTRAINT [FK_Groups_Members_Groups];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_Members_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups_Members] DROP CONSTRAINT [FK_Groups_Members_Persons];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Event_Guest_List]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Event_Guest_List];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Groups_Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups_Members];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Person] int IDENTITY(1,1) NOT NULL,
    [Guid] nvarchar(36)  NOT NULL,
    [Login] varchar(50)  NOT NULL,
    [Password] varchar(50)  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Description] varchar(1024)  NULL,
    [Organizer] int  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [Longitude] float  NOT NULL,
    [Latitude] float  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Lastname] varchar(50)  NULL,
    [InviteKey] varchar(6)  NOT NULL
);
GO

-- Creating table 'Event_Guest_List'
CREATE TABLE [dbo].[Event_Guest_List] (
    [Events1_Id] int  NOT NULL,
    [Persons1_Id] int  NOT NULL
);
GO

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [Persons2_Id] int  NOT NULL,
    [Persons1_Id] int  NOT NULL
);
GO

-- Creating table 'Groups_Members'
CREATE TABLE [dbo].[Groups_Members] (
    [Groups_Id] int  NOT NULL,
    [Persons_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Person] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Person] ASC);
GO

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Events1_Id], [Persons1_Id] in table 'Event_Guest_List'
ALTER TABLE [dbo].[Event_Guest_List]
ADD CONSTRAINT [PK_Event_Guest_List]
    PRIMARY KEY CLUSTERED ([Events1_Id], [Persons1_Id] ASC);
GO

-- Creating primary key on [Persons2_Id], [Persons1_Id] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([Persons2_Id], [Persons1_Id] ASC);
GO

-- Creating primary key on [Groups_Id], [Persons_Id] in table 'Groups_Members'
ALTER TABLE [dbo].[Groups_Members]
ADD CONSTRAINT [PK_Groups_Members]
    PRIMARY KEY CLUSTERED ([Groups_Id], [Persons_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Person] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Accounts_Persons]
    FOREIGN KEY ([Person])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Organizer] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Events_Persons]
    FOREIGN KEY ([Organizer])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Persons'
CREATE INDEX [IX_FK_Events_Persons]
ON [dbo].[Events]
    ([Organizer]);
GO

-- Creating foreign key on [Events1_Id] in table 'Event_Guest_List'
ALTER TABLE [dbo].[Event_Guest_List]
ADD CONSTRAINT [FK_Event_Guest_List_Events]
    FOREIGN KEY ([Events1_Id])
    REFERENCES [dbo].[Events]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Persons1_Id] in table 'Event_Guest_List'
ALTER TABLE [dbo].[Event_Guest_List]
ADD CONSTRAINT [FK_Event_Guest_List_Persons]
    FOREIGN KEY ([Persons1_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Guest_List_Persons'
CREATE INDEX [IX_FK_Event_Guest_List_Persons]
ON [dbo].[Event_Guest_List]
    ([Persons1_Id]);
GO

-- Creating foreign key on [Persons2_Id] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friends_Persons]
    FOREIGN KEY ([Persons2_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Persons1_Id] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [FK_Friends_Persons1]
    FOREIGN KEY ([Persons1_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Friends_Persons1'
CREATE INDEX [IX_FK_Friends_Persons1]
ON [dbo].[Friends]
    ([Persons1_Id]);
GO

-- Creating foreign key on [Groups_Id] in table 'Groups_Members'
ALTER TABLE [dbo].[Groups_Members]
ADD CONSTRAINT [FK_Groups_Members_Groups]
    FOREIGN KEY ([Groups_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Persons_Id] in table 'Groups_Members'
ALTER TABLE [dbo].[Groups_Members]
ADD CONSTRAINT [FK_Groups_Members_Persons]
    FOREIGN KEY ([Persons_Id])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Groups_Members_Persons'
CREATE INDEX [IX_FK_Groups_Members_Persons]
ON [dbo].[Groups_Members]
    ([Persons_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------