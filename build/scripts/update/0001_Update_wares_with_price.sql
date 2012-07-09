alter table [TaskWare] add
	[Price] float not null default(0)

alter table [Consultant] add
	[UserId] nvarchar(50) not null default(''),
	[PasswordHash] nvarchar(255) not null default(''),
	[PasswordSalt] nvarchar(255) not null default('')