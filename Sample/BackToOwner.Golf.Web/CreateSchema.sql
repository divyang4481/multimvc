
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK3E04EA61C75EFC56]') AND parent_object_id = OBJECT_ID('EmailAddress'))
alter table EmailAddress  drop constraint FK3E04EA61C75EFC56


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKB38EA114C75EFC56]') AND parent_object_id = OBJECT_ID('Mobiles'))
alter table Mobiles  drop constraint FKB38EA114C75EFC56


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK185E090DC75EFC56]') AND parent_object_id = OBJECT_ID('Badge'))
alter table Badge  drop constraint FK185E090DC75EFC56


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK185E090D36DFB73F]') AND parent_object_id = OBJECT_ID('Badge'))
alter table Badge  drop constraint FK185E090D36DFB73F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK95BE9D8AA84F6C62]') AND parent_object_id = OBJECT_ID('Declaration'))
alter table Declaration  drop constraint FK95BE9D8AA84F6C62


    if exists (select * from dbo.sysobjects where id = object_id(N'Owner') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Owner

    if exists (select * from dbo.sysobjects where id = object_id(N'EmailAddress') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table EmailAddress

    if exists (select * from dbo.sysobjects where id = object_id(N'Mobiles') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Mobiles

    if exists (select * from dbo.sysobjects where id = object_id(N'Badge') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Badge

    if exists (select * from dbo.sysobjects where id = object_id(N'Lot') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Lot

    if exists (select * from dbo.sysobjects where id = object_id(N'Declaration') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Declaration

    if exists (select * from dbo.sysobjects where id = object_id(N'Resource') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Resource

    create table Owner (
        Id UNIQUEIDENTIFIER not null,
       Version INT not null,
       FirstName NVARCHAR(255) not null,
       LastName NVARCHAR(255) not null,
       Gender NVARCHAR(6) not null,
       Language NVARCHAR(2) not null,
       PasswordHash NVARCHAR(255) not null,
       PasswordSalt NVARCHAR(255) not null,
       RegistrationDate DATETIME not null,
       primary key (Id)
    )

    create table EmailAddress (
        OwnerId UNIQUEIDENTIFIER not null,
       EmailValue NVARCHAR(255) null,
       EmailIndex INT not null,
       primary key (OwnerId, EmailIndex)
    )

    create table Mobiles (
        OwnerId UNIQUEIDENTIFIER not null,
       PhoneNumberValue NVARCHAR(255) null,
       PhoneNumberIndex INT not null,
       primary key (OwnerId, PhoneNumberIndex)
    )

    create table Badge (
        Nbr NVARCHAR(9) not null,
       Version INT not null,
       OwnerId UNIQUEIDENTIFIER null,
       LotId UNIQUEIDENTIFIER null,
       primary key (Nbr)
    )

    create table Lot (
        Id UNIQUEIDENTIFIER not null,
       Version INT not null,
       RegistrationDate DATETIME not null,
       Name NVARCHAR(255) not null,
       Description NVARCHAR(MAX) null,
       Amount INT not null,
       primary key (Id)
    )

    create table Declaration (
        Id UNIQUEIDENTIFIER not null,
       Version INT not null,
       EmailAddress NVARCHAR(255) null,
       FirstName NVARCHAR(255) null,
       LastName NVARCHAR(255) null,
       Language INT null,
       PhoneNumber NVARCHAR(255) not null,
       Message NVARCHAR(255) null,
       RegistrationDate DATETIME not null,
       BadgeNbr NVARCHAR(9) null,
       primary key (Id)
    )

    create table Resource (
        Id UNIQUEIDENTIFIER not null,
       Version INT not null,
       Language NVARCHAR(2) not null,
       Label NVARCHAR(255) not null,
       Value NVARCHAR(MAX) not null,
       primary key (Id)
    )

    alter table EmailAddress 
        add constraint FK3E04EA61C75EFC56 
        foreign key (OwnerId) 
        references Owner

    alter table Mobiles 
        add constraint FKB38EA114C75EFC56 
        foreign key (OwnerId) 
        references Owner

    alter table Badge 
        add constraint FK185E090DC75EFC56 
        foreign key (OwnerId) 
        references Owner

    alter table Badge 
        add constraint FK185E090D36DFB73F 
        foreign key (LotId) 
        references Lot

    alter table Declaration 
        add constraint FK95BE9D8AA84F6C62 
        foreign key (BadgeNbr) 
        references Badge

    create index ULabelLanguage on Resource (Language, Label)
