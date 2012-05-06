--
-- tables
--

create table [Client]
(
	[Id] uniqueidentifier not null primary key,
	[Name] nvarchar(255) not null
)

create table [Project] (
    [Id] uniqueidentifier not null primary key,
	[Sku] nvarchar(50) unique not null,
    [Name] nvarchar(255) not null,
    [ClientId] uniqueidentifier not null,
    [StandardProject] bit not null,
    [DefaultTaskStatus] int not null,
)

create table [Consultant]
(
	[Id] uniqueidentifier not null primary key,
	[Sku] nvarchar(50) unique not null,
	[Name] nvarchar(255) not null
)

create table [Ware]
(
	[Id] uniqueidentifier not null primary key,
	[Sku] nvarchar(50) unique not null,
	[Name] nvarchar(255) not null
)

create table [Task]
(
	[Id] uniqueidentifier not null primary key,
	[ProjectId] uniqueidentifier not null,
	[ConsultantId] uniqueidentifier not null,
	[Timestamp] datetime not null,
	[DurationInMinutes] int not null,
	[Description] nvarchar(max) not null,
	[Mileage] bit not null,
	[Status] int not null,
	[CreatedAt] datetime not null,
	[CreatedBy] nvarchar(255) not null,
	[UpdatedAt] datetime not null,
	[UpdatedBy] nvarchar(255) not null
)

create table [TaskWare]
(
	[TaskId] uniqueidentifier not null,
	[WareId] uniqueidentifier not null,
	[Quantity] int not null
)

--
-- constraints
--

alter table [Project] 
	add constraint ProjectClientId_ClientId
	foreign key (ClientId) 
	references [Client]

alter table [Task] 
	add constraint TaskProjectId_ProjectId
	foreign key (ProjectId) 
	references [Project]

alter table [Task] 
	add constraint TaskConsultantId_ConsultantId
	foreign key (ConsultantId) 
	references [Consultant]

alter table [TaskWare] 
	add constraint TaskWareTaskId_TaskId
	foreign key (TaskId) 
	references [Task]

alter table [TaskWare] 
	add constraint TaskWareWareId_WareId
	foreign key (WareId) 
	references [Ware]
