USE [master]
GO
/****** Object:  Database [BDSISCLIN]    Script Date: 14/11/2016 19:15:23 ******/
CREATE DATABASE [BDSISCLIN]
GO
ALTER DATABASE [BDSISCLIN] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDSISCLIN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDSISCLIN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDSISCLIN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDSISCLIN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDSISCLIN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDSISCLIN] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDSISCLIN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDSISCLIN] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BDSISCLIN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDSISCLIN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDSISCLIN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDSISCLIN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDSISCLIN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDSISCLIN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDSISCLIN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDSISCLIN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDSISCLIN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDSISCLIN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDSISCLIN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDSISCLIN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDSISCLIN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDSISCLIN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDSISCLIN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDSISCLIN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDSISCLIN] SET RECOVERY FULL 
GO
ALTER DATABASE [BDSISCLIN] SET  MULTI_USER 
GO
ALTER DATABASE [BDSISCLIN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDSISCLIN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDSISCLIN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDSISCLIN] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDSISCLIN', N'ON'
GO
USE [BDSISCLIN]
GO
/****** Object:  StoredProcedure [dbo].[p1]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[p1]
as
begin
select r.nome 'Responsável Legal', c.nome 'Cliente', r.endereco 'Endereco' from cliente c inner join responsavel r on
c.cpf_responsavel = r.cpf
end


GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](14) NULL,
	[email] [varchar](110) NULL,
	[endereco] [varchar](200) NULL,
	[cidade] [varchar](25) NULL,
	[estado] [varchar](25) NULL,
	[nome] [varchar](70) NOT NULL,
	[telefone] [varchar](16) NULL,
	[dataNascimento] [date] NULL,
	[adicionalInfo] [varchar](400) NULL,
	[cpf_responsavel] [varchar](14) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CPF_CLIENTE_UNICO] UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Consultorio]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Consultorio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](10) NULL,
 CONSTRAINT [PK_Consultorio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Medico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](14) NOT NULL,
	[email] [varchar](110) NULL,
	[endereco] [varchar](200) NULL,
	[cidade] [varchar](25) NULL,
	[estado] [varchar](25) NULL,
	[nome] [varchar](70) NULL,
	[telefone] [varchar](16) NULL,
	[dataNascimento] [date] NULL,
	[crm] [varchar](25) NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CPF_MEDICO_UNICO] UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Responsavel]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Responsavel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cpf] [varchar](14) NOT NULL,
	[email] [varchar](110) NULL,
	[endereco] [varchar](200) NULL,
	[cidade] [varchar](25) NULL,
	[estado] [varchar](25) NULL,
	[nome] [varchar](70) NULL,
	[telefone] [varchar](16) NULL,
	[dataNascimento] [date] NULL,
 CONSTRAINT [PK_Responsavel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [CPF_UNICO] UNIQUE NONCLUSTERED 
(
	[cpf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sessoes]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sessoes](
	[dataSessao] [date] NULL,
	[horaInicio] [datetime] NULL,
	[horaFim] [datetime] NULL,
	[tipoDeSessao] [varchar](15) NULL,
	[id_medico_responsavel] [int] NULL,
	[id_cliente] [int] NULL,
	[sessaoCompleta] [smallint] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_consultorio] [int] NULL,
	[id_tipodetratamento] [int] NULL,
	[valorsessao] [decimal](18, 2) NULL,
	[qtdesessoes] [int] NULL,
	[nroSessao] [int] NULL,
	[sessaoQuitada] [int] NULL,
	[id_tratamento_posterior] [int] NULL,
 CONSTRAINT [PK_Sessoes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipodetratamento]    Script Date: 14/11/2016 19:15:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipodetratamento](
	[Nome] [varchar](20) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[valor] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tipodetratamento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Responsavel] FOREIGN KEY([cpf_responsavel])
REFERENCES [dbo].[Responsavel] ([cpf])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Responsavel]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [FK_Sessoes_Cliente] FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Cliente] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [FK_Sessoes_Cliente]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [FK_Sessoes_Consultorio] FOREIGN KEY([id_consultorio])
REFERENCES [dbo].[Consultorio] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [FK_Sessoes_Consultorio]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [FK_Sessoes_Medico] FOREIGN KEY([id_medico_responsavel])
REFERENCES [dbo].[Medico] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [FK_Sessoes_Medico]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [FK_Sessoes_Sessoes1] FOREIGN KEY([id_tratamento_posterior])
REFERENCES [dbo].[Sessoes] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [FK_Sessoes_Sessoes1]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [FK_Sessoes_tipodetratamento] FOREIGN KEY([id_tipodetratamento])
REFERENCES [dbo].[tipodetratamento] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [FK_Sessoes_tipodetratamento]
GO
ALTER TABLE [dbo].[Sessoes]  WITH CHECK ADD  CONSTRAINT [tratamento_tratamento_post_fk] FOREIGN KEY([id_tratamento_posterior])
REFERENCES [dbo].[Sessoes] ([id])
GO
ALTER TABLE [dbo].[Sessoes] CHECK CONSTRAINT [tratamento_tratamento_post_fk]
GO
USE [master]
GO
ALTER DATABASE [BDSISCLIN] SET  READ_WRITE 
GO
USE [BDSISCLIN]
GO
CREATE TRIGGER RETORNARID
ON Sessoes
FOR INSERT
AS
select id from inserted
