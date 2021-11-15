CREATE TABLE [dbo].[Водительское удостоверение](
	[Фамилия] [varchar](50) NULL,
	[Имя] [varchar](50) NULL,
	[Отчество] [varchar](50) NULL,
	[Дата рождения] [date] NULL,
	[Место рождения] [varchar](50) NULL,
	[Дата выдачи] [date] NULL,
	[Дата окончания] [date] NULL,
	[Выдал] [varchar](50) NULL,
	[Серия и номер] [varchar](50) NULL,
	[Категории] [varchar](50) NULL,
	[Действительно с] [date] NULL,
	[Действительно до] [date] NULL,
	[Группа крови] [varchar](50) NULL,
	[Номер в реестре] [int] NULL
) ON [PRIMARY]