USE [master]
GO
/****** Object:  Database [CommonGestionTrabajadores]    Script Date: 04/03/2021 2:10:42 ******/
CREATE DATABASE [CommonGestionTrabajadores]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CommonGestionTrabajadores', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CommonGestionTrabajadores.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CommonGestionTrabajadores_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CommonGestionTrabajadores_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CommonGestionTrabajadores] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CommonGestionTrabajadores].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ARITHABORT OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET RECOVERY FULL 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET  MULTI_USER 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CommonGestionTrabajadores] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CommonGestionTrabajadores] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CommonGestionTrabajadores', N'ON'
GO
ALTER DATABASE [CommonGestionTrabajadores] SET QUERY_STORE = OFF
GO
USE [CommonGestionTrabajadores]
GO
/****** Object:  Table [dbo].[JefesEquipo]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JefesEquipo](
	[Id] [int] NOT NULL,
	[TelefonoEmpresa] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_JefesEquipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proyectos]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proyectos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FechaLimite] [date] NULL,
 CONSTRAINT [PK_Proyectos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tecnicos]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tecnicos](
	[Id] [int] NOT NULL,
	[JefeEquipoId] [int] NOT NULL,
	[TareaActual] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tecnicos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposTecnologia]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposTecnologia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposTecnologia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trabajadores]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trabajadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [nvarchar](10) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Direccion] [nvarchar](50) NOT NULL,
	[FechaBaja] [datetime] NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Trabajadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrabajadoresDTecnico]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrabajadoresDTecnico](
	[Id] [int] NOT NULL,
	[AnyosExperiencia] [int] NOT NULL,
 CONSTRAINT [PK_TrabajadoresDTecnico] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrabajadoresDTecnicoProyectos]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrabajadoresDTecnicoProyectos](
	[TrabajadorDTecnicoId] [int] NOT NULL,
	[ProyectoId] [int] NOT NULL,
 CONSTRAINT [PK_TrabajadoresDTecnicoProyectos] PRIMARY KEY CLUSTERED 
(
	[TrabajadorDTecnicoId] ASC,
	[ProyectoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrabajadoresDTecnicoTecnologias]    Script Date: 04/03/2021 2:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrabajadoresDTecnicoTecnologias](
	[TrabajadoresDTecnicoId] [int] NOT NULL,
	[TiposTecnologiaId] [int] NOT NULL,
 CONSTRAINT [PK_TrabajadoresDTecnicoTecnologias] PRIMARY KEY CLUSTERED 
(
	[TrabajadoresDTecnicoId] ASC,
	[TiposTecnologiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[JefesEquipo] ([Id], [TelefonoEmpresa]) VALUES (1014, N'666777888')
INSERT [dbo].[JefesEquipo] ([Id], [TelefonoEmpresa]) VALUES (1015, N'666777888')
INSERT [dbo].[JefesEquipo] ([Id], [TelefonoEmpresa]) VALUES (1016, N'666777888')
GO
SET IDENTITY_INSERT [dbo].[TiposTecnologia] ON 

INSERT [dbo].[TiposTecnologia] ([Id], [Nombre]) VALUES (1, N'.NET')
INSERT [dbo].[TiposTecnologia] ([Id], [Nombre]) VALUES (2, N'Java')
INSERT [dbo].[TiposTecnologia] ([Id], [Nombre]) VALUES (3, N'CSS')
INSERT [dbo].[TiposTecnologia] ([Id], [Nombre]) VALUES (4, N'HTML')
INSERT [dbo].[TiposTecnologia] ([Id], [Nombre]) VALUES (5, N'SQL')
SET IDENTITY_INSERT [dbo].[TiposTecnologia] OFF
GO
SET IDENTITY_INSERT [dbo].[Trabajadores] ON 

INSERT [dbo].[Trabajadores] ([Id], [Dni], [Nombre], [Apellidos], [FechaNacimiento], [Direccion], [FechaBaja], [Borrado]) VALUES (1014, N'12345678-B', N'Jorge', N'dfgdfgdgf', CAST(N'2020-11-02T00:00:00.000' AS DateTime), N'C/Zaragoza 45', NULL, 1)
INSERT [dbo].[Trabajadores] ([Id], [Dni], [Nombre], [Apellidos], [FechaNacimiento], [Direccion], [FechaBaja], [Borrado]) VALUES (1015, N'12345678-B', N'Jorge', N'Pérez', CAST(N'2021-03-01T00:00:00.000' AS DateTime), N'C/Zaragoza 45', NULL, 1)
INSERT [dbo].[Trabajadores] ([Id], [Dni], [Nombre], [Apellidos], [FechaNacimiento], [Direccion], [FechaBaja], [Borrado]) VALUES (1016, N'23423423-B', N'pruebas', N'pruebas', CAST(N'2021-03-01T00:00:00.000' AS DateTime), N'pruebas 23', NULL, 1)
SET IDENTITY_INSERT [dbo].[Trabajadores] OFF
GO
INSERT [dbo].[TrabajadoresDTecnico] ([Id], [AnyosExperiencia]) VALUES (1014, 5)
INSERT [dbo].[TrabajadoresDTecnico] ([Id], [AnyosExperiencia]) VALUES (1015, 3)
INSERT [dbo].[TrabajadoresDTecnico] ([Id], [AnyosExperiencia]) VALUES (1016, 11)
GO
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1014, 1)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1014, 2)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1014, 3)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1014, 4)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1015, 3)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1015, 4)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1016, 1)
INSERT [dbo].[TrabajadoresDTecnicoTecnologias] ([TrabajadoresDTecnicoId], [TiposTecnologiaId]) VALUES (1016, 2)
GO
ALTER TABLE [dbo].[Trabajadores] ADD  CONSTRAINT [DF_Trabajadores_Borrado]  DEFAULT ((0)) FOR [Borrado]
GO
ALTER TABLE [dbo].[JefesEquipo]  WITH CHECK ADD  CONSTRAINT [FK_JefesEquipo_TrabajadoresDTecnico] FOREIGN KEY([Id])
REFERENCES [dbo].[TrabajadoresDTecnico] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JefesEquipo] CHECK CONSTRAINT [FK_JefesEquipo_TrabajadoresDTecnico]
GO
ALTER TABLE [dbo].[Tecnicos]  WITH CHECK ADD  CONSTRAINT [FK_Tecnicos_JefesEquipo] FOREIGN KEY([JefeEquipoId])
REFERENCES [dbo].[JefesEquipo] ([Id])
GO
ALTER TABLE [dbo].[Tecnicos] CHECK CONSTRAINT [FK_Tecnicos_JefesEquipo]
GO
ALTER TABLE [dbo].[Tecnicos]  WITH CHECK ADD  CONSTRAINT [FK_Tecnicos_TrabajadoresDTecnico] FOREIGN KEY([Id])
REFERENCES [dbo].[TrabajadoresDTecnico] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tecnicos] CHECK CONSTRAINT [FK_Tecnicos_TrabajadoresDTecnico]
GO
ALTER TABLE [dbo].[TrabajadoresDTecnico]  WITH CHECK ADD  CONSTRAINT [FK_TrabajadoresDTecnico_Trabajadores] FOREIGN KEY([Id])
REFERENCES [dbo].[Trabajadores] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrabajadoresDTecnico] CHECK CONSTRAINT [FK_TrabajadoresDTecnico_Trabajadores]
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoProyectos]  WITH CHECK ADD  CONSTRAINT [FK_TrabajadoresDTecnicoProyectos_Proyectos] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyectos] ([Id])
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoProyectos] CHECK CONSTRAINT [FK_TrabajadoresDTecnicoProyectos_Proyectos]
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoProyectos]  WITH CHECK ADD  CONSTRAINT [FK_TrabajadoresDTecnicoProyectos_TrabajadoresDTecnico] FOREIGN KEY([TrabajadorDTecnicoId])
REFERENCES [dbo].[TrabajadoresDTecnico] ([Id])
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoProyectos] CHECK CONSTRAINT [FK_TrabajadoresDTecnicoProyectos_TrabajadoresDTecnico]
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoTecnologias]  WITH CHECK ADD  CONSTRAINT [FK_TrabajadoresDTecnicoTecnologias_TiposTecnologia] FOREIGN KEY([TiposTecnologiaId])
REFERENCES [dbo].[TiposTecnologia] ([Id])
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoTecnologias] CHECK CONSTRAINT [FK_TrabajadoresDTecnicoTecnologias_TiposTecnologia]
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoTecnologias]  WITH CHECK ADD  CONSTRAINT [FK_TrabajadoresDTecnicoTecnologias_TrabajadoresDTecnico1] FOREIGN KEY([TrabajadoresDTecnicoId])
REFERENCES [dbo].[TrabajadoresDTecnico] ([Id])
GO
ALTER TABLE [dbo].[TrabajadoresDTecnicoTecnologias] CHECK CONSTRAINT [FK_TrabajadoresDTecnicoTecnologias_TrabajadoresDTecnico1]
GO
USE [master]
GO
ALTER DATABASE [CommonGestionTrabajadores] SET  READ_WRITE 
GO
