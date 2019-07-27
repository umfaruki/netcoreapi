## netcoreapi
dotnet core api practice with swagger
Fluent NHibernate with dot net core api

##### Database script
```
CREATE TABLE [dbo].[Booking] (
    [Id]           INT            NOT NULL,
    [Name]         NVARCHAR (150) NULL,
    [CreationDate] DATETIME       NULL,
    [UpdatedDate]  DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[BookingPart] (
    [Id]           INT            NOT NULL,
    [Title]        NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [CreationTime] NCHAR (10)     NULL,
    [Status]       INT            NULL,
    [CreationDate] DATETIME       NULL,
    [UpdatedDate]  DATETIME       NULL,
    [BookingId]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BookingPart_ToBooking] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Booking] ([Id])
);

```


You can access swagger with /swagger url
